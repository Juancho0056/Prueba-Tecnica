using Application.CommandQueries.TipoDocumentos;
using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;
using System;

namespace Application.CommandQueries.Clientes
{
    public partial class ClienteDto : AuditableEntity, IMapFrom<Cliente>
    {
        public ClienteDto()
        {

        }
        public int Id { get; set; }
        public string TipoDocumentoId { get; set; }
        public virtual TipoDocumentoDto TipoDocumento { get; set; }
        public string TipoDocumentoDetalle { get; set; }
        public string NroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NombreCliente { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cliente, ClienteDto>()
                .ForMember(d => d.TipoDocumentoDetalle, opt => opt.MapFrom(s => s.TipoDocumento != null ? s.TipoDocumento.Detalle : ""))
                .ForMember(d => d.NombreCliente, opt => opt.MapFrom(s => s.NroDocumento + "-"+ s.PrimerNombre));

        }
    }
}
