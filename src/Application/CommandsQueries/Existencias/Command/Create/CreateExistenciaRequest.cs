using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.Existencias.Command.Create
{    
    public class CreateExistenciaRequest : CommandRequest<ExistenciaDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ArticuloId { get; set; }
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
                var existencia = _context.existencias.
                    AsNoTracking().
                    Where(x => x.ArticuloId == ArticuloId).FirstOrDefault();
                
                if (!(existencia is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Existencia" }));
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
