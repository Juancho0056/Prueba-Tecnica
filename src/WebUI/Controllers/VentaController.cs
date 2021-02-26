using Application.CommandQueries.Ventas;
using Application.CommandQueries.Ventas.Command.Create;
using Application.CommandQueries.Ventas.Command.Delete;
using Application.CommandsQueries.Ventas.Queries.Get;
using Application.CommandsQueries.Ventas.Queries.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace Ophelia.WebUI.Controllers
{
    /// <summary>
    /// Controlador de Ventas. api/Venta
    /// </summary>
    [OpenApiTagAttribute("Venta",
           Description = "Controlador Ventas.")]
    public class VentaController : ApiController
    {
        /// <summary>
        /// Add Venta
        /// </summary>
        /// <remarks>
        /// Create new record for Ventas
        /// </remarks>
        /// <param name="command">Instance for CreateVentaRequest</param>
        /// <returns></returns>
        // POST: api/Venta/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateVentaRequest command)
        {
            return await base.Command<CreateVentaRequest, VentaDto>(command);
        }
        ///// <summary>
        ///// Delete Venta
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Venta
        ///// </remarks>
        ///// <param name="command">Instance for DeleteVentaRequest</param>
        ///// <returns></returns>
        //// POST: api/Venta/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteVentaRequest command)
        {
            return await base.Command<DeleteVentaRequest, VentaDto>(command);
        }
        ///// <summary>
        ///// Get All Venta
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Venta filtered by the class paramater <code>GetAllVentaRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllVentaRequest</param>
        ///// <returns></returns>
        //// GET: api/Venta/GetAll
        [ProducesResponseType(typeof(VentaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllVentaRequest command)
        {
            return await base.Query<GetAllVentaRequest, GetAllVentaResponse>(command);
        }
        ///// <summary>
        ///// Get Venta
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Venta
        ///// </remarks>
        ///// <param name="command">Instance for GetAllVentaRequest</param>
        ///// <returns></returns>
        //// GET: api/Venta/Get
        [ProducesResponseType(typeof(VentaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetVentaRequest command)
        {
            return await base.Query<GetVentaRequest, VentaDto>(command);
        }
    }
}

