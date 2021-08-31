using SchoolManagement.Services.DTO;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<AlunoDTO> Post(AlunoDTO alunoDTO);
    }
}
