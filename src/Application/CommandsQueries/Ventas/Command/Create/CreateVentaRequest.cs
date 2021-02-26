using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.Ventas.Command.Create
{
    public class Detalle
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal Cantidad { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal Valor { get; set; }
    }
    public class CreateVentaRequest : CommandRequest<VentaDto>, IValidatableObject
    {

        public CreateVentaRequest(bool transaction = true): base(transaction) 
        {
            
        }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public DateTime FechaVenta { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ClienteId { get; set; }
        public List<Detalle> Detalles { get; set; } = new List<Detalle>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));
            try
            {

                var cliente = _context.clientes.
                    AsNoTracking().
                    Where(x => x.Id == ClienteId).FirstOrDefault();
                if (cliente is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Cliente"), new[] { "ClienteId" }));
                    return errores;
                }
                foreach (var detalle in Detalles) 
                {
                    var item = _context.articulos.
                    AsNoTracking().
                    Where(x => x.Id == detalle.ArticuloId).FirstOrDefault();
                    if (item is null)
                    {
                        errores.Add(new ValidationResult(ErrorMessage.NotFound("Articulo") + " - " + detalle.ArticuloId, new[] { "ArticuloId" }));
                        return errores;
                    }
                }
                return errores;
            }
            catch (Exception e)
            {
                errores.Add(new ValidationResult(e.Message));
                return errores;
            }
        }
    }
}