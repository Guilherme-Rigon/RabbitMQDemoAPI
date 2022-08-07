using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RabbitMQDemoAPI.Consumer.Models;
using RabbitMQDemoAPI.Publisher.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly ILogger<MatriculaController> _logger;
        private readonly IBus _bus;
        private readonly APIMatriculaDbContext _context;

        public MatriculaController(ILogger<MatriculaController> logger, IBus bus, APIMatriculaDbContext context)
        {
            _logger = logger;
            _bus = bus;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos.AsNoTracking().AsAsyncEnumerable());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            if (aluno is not null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Add(aluno);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        Uri uri = new Uri("rabbitmq://localhost/MatriculaQueue");
                        var endPoint = await _bus.GetSendEndpoint(uri);
                        await endPoint.Send(aluno);
                        return Ok();
                    }
                    catch(Exception e)
                    {
                        await transaction.RollbackAsync();
                        return BadRequest(e.Message + " -> " + e.InnerException);
                    }
                }
            }
            return BadRequest();
        }
    }
}
