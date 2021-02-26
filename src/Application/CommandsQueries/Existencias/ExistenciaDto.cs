using Application.CommandQueries.Articulos;
using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;

namespace Application.CommandQueries.Existencias
{
    public partial class ExistenciaDto : AuditableEntity, IMapFrom<Existencia>
    {
        public ExistenciaDto()
        {

        }
        public int Id { get; set; }
        public ArticuloDto Articulo { get; set; }
        public int ArticuloId { get; set; }
        public decimal ExistenciaMinima { get; set; }
        public decimal ExistenciaMaxima { get; set; }
        public decimal CantDisponible { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Existencia, ExistenciaDto>();
        }
    }
}
