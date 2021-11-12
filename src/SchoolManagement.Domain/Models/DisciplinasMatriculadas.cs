using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class DisciplinasMatriculadas : Base
    {
        public long ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public long DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
