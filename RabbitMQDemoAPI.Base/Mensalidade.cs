using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Base
{
    public class Mensalidade
    {
        [Key]
        public string Identificador { get; set; }
        public string Matricula { get; set; }
        public string Referencia { get; set; }
        public decimal Valor { get; set; }
    }
}
