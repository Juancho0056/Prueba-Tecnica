using Application.CommandQueries.Unidades;
using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;

namespace Application.CommandQueries.Articulos
{
    public partial class ArticuloDto : AuditableEntity, IMapFrom<Articulo>
    {
        public ArticuloDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string UnidadDetalle { get; set; }
        public int UnidadId { get; set; }
        public virtual UnidadDto Unidad { get; set; }
        public decimal Precio { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Articulo, ArticuloDto>()
                .ForMember(d => d.UnidadDetalle, opt => opt.MapFrom(s => s.Unidad != null ?s.Unidad.Detalle: ""));
        }
    }
}
