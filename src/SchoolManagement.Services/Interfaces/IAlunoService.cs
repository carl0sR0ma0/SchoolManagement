using SchoolManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IAlunoService
    {
        AlunoCreateViewModel Post(AlunoCreateViewModel aluno);
    }
}
