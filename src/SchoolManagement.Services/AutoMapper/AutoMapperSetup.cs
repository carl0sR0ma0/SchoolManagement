using AutoMapper;
using SchoolManagement.Domain.Models;
using SchoolManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region "ViewModel To Domain"
            CreateMap<AlunoCreateViewModel, Aluno>();
            #endregion

            #region "Domain To ViewModel"
            CreateMap<Aluno, AlunoViewModel>();
            #endregion
        }
    }
}
