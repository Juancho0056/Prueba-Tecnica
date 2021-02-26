using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.TipoDocumentos.Command.Create
{    
    public class CreateTipoDocumentoRequest : CommandRequest<TipoDocumentoDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLength + "2.")]
        [MaxLength(2, ErrorMessage = ErrorMessage.MaxLength + "2.")]
        public string Id { get; set; }
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
                var tipodocumento = _context.tipodocumentos.
                    AsNoTracking().
                    Where(x => x.Detalle == Detalle).FirstOrDefault();
                
                if (!(tipodocumento is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Id" }));
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
