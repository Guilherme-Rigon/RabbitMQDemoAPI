using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQDemoAPI.Consumer.Models
{
    public class Aluno
    {
        [Key]
        public string Matricula { get; set; }
        public string Curso { get; set; }
    }
}
