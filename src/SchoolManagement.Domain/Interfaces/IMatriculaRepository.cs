﻿using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        Task<List<Matricula>> Get();
        Task<Matricula> Get(long id);
        Task Remove(long id);
        Task<Matricula> GetByRA(long ra);
        Task<List<Matricula>> GetMatriculasByTurma(long turmaId);
    }
}
