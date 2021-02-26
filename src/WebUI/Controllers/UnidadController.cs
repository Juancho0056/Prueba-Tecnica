using Application.CommandQueries.Unidades;
using Application.CommandQueries.Unidades.Command.Create;
using Application.CommandQueries.Unidades.Command.Delete;
using Application.CommandQueries.Unidades.Command.Update;
using Application.CommandsQueries.Unidades.Queries.Get;
using Application.CommandsQueries.Unidades.Queries.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace Ophelia.WebUI.Controllers
{
    /// <summary>
    /// Controlador de Unidades. api/Unidad
    /// </summary>
    [OpenApiTagAttribute("Unidad",
           Description = "Controlador Unidades.")]
    public class UnidadController : ApiController
    {
        /// <summary>
        /// Add Unidad
        /// </summary>
        /// <remarks>
        /// Create new record for Unidades
        /// </remarks>
        /// <param name="command">Instance for CreateUnidadRequest</param>
        /// <returns></returns>
        // POST: api/Unidad/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateUnidadRequest command)
        {
            return await base.Command<CreateUnidadRequest, UnidadDto>(command);
        }
        /// <summary>
        /// Update Unidad
        /// </summary>
        /// <remarks>
        /// Update a specific record for Unidad
        /// </remarks>
        /// <param name="command">Instance for UpdateUnidadRequest</param>
        /// <returns></returns>
        // POST: api/Unidad/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateUnidadRequest command)
        {
            return await base.Command<UpdateUnidadRequest, UnidadDto>(command);
        }
        ///// <summary>
        ///// Delete Unidad
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Unidad
        ///// </remarks>
        ///// <param name="command">Instance for DeleteUnidadRequest</param>
        ///// <returns></returns>
        //// POST: api/Unidad/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteUnidadRequest command)
        {
            return await base.Command<DeleteUnidadRequest, UnidadDto>(command);
        }
        ///// <summary>
        ///// Get All Unidad
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Unidad filtered by the class paramater <code>GetAllUnidadRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllUnidadRequest</param>
        ///// <returns></returns>
        //// GET: api/Unidad/GetAll
        [ProducesResponseType(typeof(UnidadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllUnidadRequest command)
        {
            return await base.Query<GetAllUnidadRequest, GetAllUnidadResponse>(command);
        }
        ///// <summary>
        ///// Get Unidad
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Unidad
        ///// </remarks>
        ///// <param name="command">Instance for GetAllUnidadRequest</param>
        ///// <returns></returns>
        //// GET: api/Unidad/Get
        [ProducesResponseType(typeof(UnidadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetUnidadRequest command)
        {
            return await base.Query<GetUnidadRequest, UnidadDto>(command);
        }
    }
}

