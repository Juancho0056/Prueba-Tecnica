using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;

namespace Application.CommandQueries.Clientes.Command.Update
{
    public class UpdateClienteRequest : CommandRequest<ClienteDto>, IValidatableObject
    {
        public int Id { get; set; }
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
        public bool? EstadoRegistro { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var cliente = _context.clientes.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (cliente is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Cliente"), new[] { "Id" }));
                    return errores;
                }
                var tipodocumento = _context.tipodocumentos.
                    AsNoTracking().
                    Where(x => x.Id == TipoDocumentoId).FirstOrDefault();

                if (tipodocumento is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Tipo Documento"), new[] { "TipoDocumentoId" }));
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
