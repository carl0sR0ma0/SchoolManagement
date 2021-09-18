using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
   public interface ISerieService
    {
        Task<SerieDTO> Post(SerieDTO SerieDTO);
        Task<SerieDTO> Update(SerieDTO SerieDTO);
        Task Remove(long id);
        Task<SerieDTO> Get(long id);
        Task<List<SerieDTO>> Get();
        Task<List<SerieDTO>> GetSeriesByCourse(long cursoId);
    }
}
