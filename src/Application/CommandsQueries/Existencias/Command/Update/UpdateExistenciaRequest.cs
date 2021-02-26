using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;

namespace Application.CommandQueries.Existencias.Command.Update
{
    public class UpdateExistenciaRequest : CommandRequest<ExistenciaDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ErrorMessage.OnlyNumeric)]
        public decimal CantDisponible { get; set; }
        public bool? EstadoRegistro { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var existencia = _context.existencias.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (existencia is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Existencia"), new[] { "Id" }));
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
