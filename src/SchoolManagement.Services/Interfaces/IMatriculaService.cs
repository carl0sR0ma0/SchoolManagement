using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaDTO> Post(MatriculaDTO matriculaDTO);
        Task<MatriculaDTO> Update(MatriculaDTO matriculaDTO);
        Task Remove(long id);
        Task<MatriculaDTO> Get(long id);
        Task<List<MatriculaDTO>> Get();
        Task<MatriculaDTO> GetByRA(long ra);
        Task<List<MatriculaDTO>> GetMatriculasByTurma(long turmaId);
    }
}
