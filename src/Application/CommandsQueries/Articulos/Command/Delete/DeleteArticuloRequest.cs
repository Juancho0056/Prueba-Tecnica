using Application.CommandsQueries.Articulos;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.CommandQueries.Articulos.Command.Delete
{
    public class DeleteArticuloRequest : CommandRequest<ArticuloExistenciaDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var unidad = _context.articulos.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (unidad is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Articulo"), new[] { "Articulo" }));
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
