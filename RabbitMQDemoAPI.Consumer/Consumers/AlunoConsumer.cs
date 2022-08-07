using MassTransit;
using RabbitMQDemoAPI.Base;
using RabbitMQDemoAPI.Consumer.Data;
using RabbitMQDemoAPI.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Consumer.Consumers
{
    public class AlunoConsumer : IConsumer<Aluno>
    {
        private readonly APIMensalidadeDbContext _context;
        public AlunoConsumer(APIMensalidadeDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<Aluno> context)
        {
            Aluno aluno = context.Message;
            List<Mensalidade> mensalidades = new();
            decimal valorMensalidade = Convert.ToDecimal(new Random().Next(650, 1100));
            for (int i = 1; i <= 6; i++)
            {
                mensalidades.Add(new Mensalidade
                {
                    Identificador = Guid.NewGuid().ToString(),
                    Referencia = $"{i.ToString().PadLeft(2, '0')}/{DateTime.Now.Year}",
                    Valor = valorMensalidade,
                    Matricula = aluno.Matricula
                });
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.AddRange(mensalidades);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
