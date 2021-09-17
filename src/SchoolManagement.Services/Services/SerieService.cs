using AutoMapper;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Services
{
    public class SerieService : ISerieService
    {
        private readonly IMapper _mapper;
        private readonly ISerieRepository _repository;

        public SerieService(IMapper mapper, ISerieRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<SerieDTO> Get(long id)
        {
            var serie = await _repository.Get(id);

            return _mapper.Map<SerieDTO>(serie); 
        }

        public async Task<List<SerieDTO>> Get()
        {
            var series = await _repository.Get();

            return _mapper.Map<List<SerieDTO>>(series);
        }

        public async Task<List<SerieDTO>> GetSeriesByCourse(long cursoId)
        {
            var allSeries = await _repository.GetSeriesByCourse(cursoId);

            return _mapper.Map<List<SerieDTO>>(allSeries);
        }

        public async Task<SerieDTO> Post(SerieDTO SerieDTO)
        {
            Serie serie = new Serie(SerieDTO.Nome, SerieDTO.Descricao, SerieDTO.CursoId);
            
            serie.Validate();

            var serieCreated = await _repository.Create(serie);
            return _mapper.Map<SerieDTO>(serieCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<SerieDTO> Update(SerieDTO serieDTO)
        {
            var serieExists = await _repository.Get(serieDTO.Id);

            if (serieExists == null)
                throw new DomainException("Não existe nenhuma Serie cadastrada com o Id informado!");

            var serie = _mapper.Map<Serie>(serieDTO);
            serie.Validate();

            var serieUpdated = await _repository.Update(serie);
            return _mapper.Map<SerieDTO>(serieUpdated);
        }
    }
}
