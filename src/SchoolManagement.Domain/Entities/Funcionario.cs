using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public abstract class Funcionario : Pessoa
    {
        public long CPTS { get; set; }
        public string Formacao { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
