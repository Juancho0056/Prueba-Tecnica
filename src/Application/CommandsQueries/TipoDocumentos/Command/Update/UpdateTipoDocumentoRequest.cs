using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;

namespace Application.CommandQueries.TipoDocumentos.Command.Update
{
    public class UpdateTipoDocumentoRequest : CommandRequest<TipoDocumentoDto>, IValidatableObject
    {
        public string Id { get; set; }
        [MinLength(5, ErrorMessage = ErrorMessage.MinLength + "5.")]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLength + "50.")]
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
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
