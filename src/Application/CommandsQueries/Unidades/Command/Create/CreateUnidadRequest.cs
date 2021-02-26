using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.Unidades.Command.Create
{    
    public class CreateUnidadRequest : CommandRequest<UnidadDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MinLength(5, ErrorMessage = ErrorMessage.MinLength + "5.")]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLength + "50.")]
        public string Detalle { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var unidad = _context.unidades.
                    AsNoTracking().
                    Where(x => x.Detalle == Detalle).FirstOrDefault();
                
                if (!(unidad is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Unidad" }));
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
