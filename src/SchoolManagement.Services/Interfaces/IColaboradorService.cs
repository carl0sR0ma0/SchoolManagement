using SchoolManagement.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IColaboradorService
    {
        Task<ColaboradorDTO> Post(ColaboradorDTO colaboradorDTO);
        Task<ColaboradorDTO> Update(ColaboradorDTO colaboradorDTO);
        Task Remove(long id);
        Task<ColaboradorDTO> Get(long id);
        Task<List<ColaboradorDTO>> Get();
    }
}
