using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;

namespace Application.CommandQueries.TipoDocumentos
{
    public partial class TipoDocumentoDto : AuditableEntity, IMapFrom<TipoDocumento>
    {
        public TipoDocumentoDto()
        {

        }
        public string Id { get; set; }
        public string Detalle { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TipoDocumento, TipoDocumentoDto>();
        }
    }
}
