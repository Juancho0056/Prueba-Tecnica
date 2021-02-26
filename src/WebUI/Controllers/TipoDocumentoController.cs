using Application.CommandQueries.TipoDocumentos;
using Application.CommandQueries.TipoDocumentos.Command.Create;
using Application.CommandQueries.TipoDocumentos.Command.Delete;
using Application.CommandQueries.TipoDocumentos.Command.Update;
using Application.CommandsQueries.TipoDocumentos.Queries.Get;
using Application.CommandsQueries.TipoDocumentos.Queries.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace Ophelia.WebUI.Controllers
{
    /// <summary>
    /// Controlador de Tipos de Documento. api/TipoDocumento
    /// </summary>
    [OpenApiTagAttribute("TipoDocumento",
           Description = "Controlador TipoDocumento.")]
    public class TipoDocumentoController : ApiController
    {
        /// <summary>
        /// Add TipoDocumento
        /// </summary>
        /// <remarks>
        /// Create new record for TipoDocumentos
        /// </remarks>
        /// <param name="command">Instance for CreateTipoDocumentoRequest</param>
        /// <returns></returns>
        // POST: api/TipoDocumento/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateTipoDocumentoRequest command)
        {
            return await base.Command<CreateTipoDocumentoRequest, TipoDocumentoDto>(command);
        }
        /// <summary>
        /// Update TipoDocumento
        /// </summary>
        /// <remarks>
        /// Update a specific record for TipoDocumento
        /// </remarks>
        /// <param name="command">Instance for UpdateTipoDocumentoRequest</param>
        /// <returns></returns>
        // POST: api/TipoDocumento/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateTipoDocumentoRequest command)
        {
            return await base.Command<UpdateTipoDocumentoRequest, TipoDocumentoDto>(command);
        }
        ///// <summary>
        ///// Delete TipoDocumento
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for TipoDocumento
        ///// </remarks>
        ///// <param name="command">Instance for DeleteTipoDocumentoRequest</param>
        ///// <returns></returns>
        //// POST: api/TipoDocumento/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteTipoDocumentoRequest command)
        {
            return await base.Command<DeleteTipoDocumentoRequest, TipoDocumentoDto>(command);
        }
        ///// <summary>
        ///// Get All TipoDocumento
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the TipoDocumento filtered by the class paramater <code>GetAllTipoDocumentoRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllTipoDocumentoRequest</param>
        ///// <returns></returns>
        //// GET: api/TipoDocumento/GetAll
        [ProducesResponseType(typeof(TipoDocumentoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllTipoDocumentoRequest command)
        {
            return await base.Query<GetAllTipoDocumentoRequest, GetAllTipoDocumentoResponse>(command);
        }
        ///// <summary>
        ///// Get TipoDocumento
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for TipoDocumento
        ///// </remarks>
        ///// <param name="command">Instance for GetAllTipoDocumentoRequest</param>
        ///// <returns></returns>
        //// GET: api/TipoDocumento/Get
        [ProducesResponseType(typeof(TipoDocumentoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetTipoDocumentoRequest command)
        {
            return await base.Query<GetTipoDocumentoRequest, TipoDocumentoDto>(command);
        }
    }
}

