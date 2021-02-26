using Application.CommandQueries.Articulos;
using Application.CommandQueries.Clientes;
using AutoMapper;
using Ophelia.Application.Common.Mappings;
using Ophelia.Domain.Common;
using Ophelia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.CommandQueries.Ventas
{
    public partial class DetalleVentaDto : AuditableEntity, IMapFrom<DetalleVenta> 
    {
        public int VentaId { get; set; }
        public virtual VentaDto Venta { get; set; }
        public int ArticuloId { get; set; }
        public virtual ArticuloDto Articulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Valor { get; set; }
    }
    public partial class VentaDto : AuditableEntity, IMapFrom<Venta>
    {
        public VentaDto()
        {

        }
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public ClienteDto Cliente { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public decimal VlrVenta { get; set; }
        public List<DetalleVentaDto> Detalles { get; set; } = new List<DetalleVentaDto>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Venta, VentaDto>()
                .ForMember(d => d.NombreCliente, opt => opt.MapFrom(s => s.Cliente.NroDocumento + "-" + s.Cliente.PrimerNombre)); ;
        }
    }
}
