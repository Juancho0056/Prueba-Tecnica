using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.TipoDocumentos.Command.Delete
{
    public class DeleteTipoDocumentoRequest : CommandRequest<TipoDocumentoDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public string Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var tipodocumento = _context.tipodocumentos.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (tipodocumento is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("TipoDocumento"), new[] { "TipoDocumento" }));
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
