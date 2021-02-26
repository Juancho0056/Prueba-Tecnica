using Application.CommandsQueries.Articulos;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.Articulos.Command.Create
{   
    public class ArticuloRequest 
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MinLength(5, ErrorMessage = ErrorMessage.MinLength + "5.")]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLength + "50.")]
        public string Detalle { get; set; }
        public int UnidadId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal Precio { get; set; }
    }
    public class CreateArticuloRequest : CommandRequest<ArticuloExistenciaDto>, IValidatableObject
    {
        public CreateArticuloRequest(bool transaction = true) : base(transaction)
        {

        }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public ArticuloRequest Articulo { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal ExistenciaMinima { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal ExistenciaMaxima { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal CantDisponible { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var unidad = _context.unidades.
                    AsNoTracking().
                    Where(x => x.Id == Articulo.UnidadId).FirstOrDefault();

                if (unidad is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Unidad"), new[] { "UnidadId" }));
                    return errores;
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
