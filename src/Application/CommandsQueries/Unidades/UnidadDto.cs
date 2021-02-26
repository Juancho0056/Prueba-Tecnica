using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;

namespace Application.CommandQueries.Unidades
{
    public partial class UnidadDto : AuditableEntity, IMapFrom<Unidad>
    {
        public UnidadDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Unidad, UnidadDto>();
        }
    }
}
