using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQDemoAPI.Consumer.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MensalidadeController : ControllerBase
    {
        private readonly APIMensalidadeDbContext _context;
        public MensalidadeController(APIMensalidadeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new OkObjectResult(_context.Mensalidades.AsAsyncEnumerable());
        }
    }
}
