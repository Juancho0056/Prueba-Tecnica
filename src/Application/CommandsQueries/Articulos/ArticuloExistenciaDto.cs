using Application.CommandQueries.Articulos;
using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandsQueries.Articulos
{
    public class ArticuloExistenciaDto: AuditableEntity, IMapFrom<Articulo>
    {
        public int Id { get; set; }
        public ArticuloDto Articulo { get; set; } = new ArticuloDto();
        public decimal ExistenciaMinima { get; set; }
        public decimal ExistenciaMaxima { get; set; }
        public decimal CantDisponible { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Existencia, ArticuloExistenciaDto>();
        }
    }
}
