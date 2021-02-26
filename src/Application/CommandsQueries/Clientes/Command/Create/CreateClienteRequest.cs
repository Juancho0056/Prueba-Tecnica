using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.Clientes.Command.Create
{    
    public class CreateClienteRequest : CommandRequest<ClienteDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLength + "2.")]
        [MaxLength(20, ErrorMessage = ErrorMessage.MaxLength + "20.")]
        public string NroDocumento { get; set; }
        public string TipoDocumentoId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MinLength(5, ErrorMessage = ErrorMessage.MinLength + "5.")]
        [MaxLength(40, ErrorMessage = ErrorMessage.MaxLength + "40.")]
        public string PrimerNombre { get; set; }
        [MaxLength(40, ErrorMessage = ErrorMessage.MaxLength + "40.")]
        public string SegundoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var tipodocumento = _context.tipodocumentos.
                    AsNoTracking().
                    Where(x => x.Id == TipoDocumentoId).FirstOrDefault();

                if (tipodocumento is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Tipo Documento"), new[] { "TipoDocumentoId" }));
                    return errores;
                }
                var cliente = _context.clientes.
                    AsNoTracking().
                    Where(x => x.NroDocumento == NroDocumento).FirstOrDefault();
                
                if (!(cliente is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "NroDocumento" }));
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
