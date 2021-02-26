using Application.CommandQueries.Articulos;
using Application.CommandQueries.Articulos.Command.Create;
using Application.CommandQueries.Articulos.Command.Delete;
using Application.CommandQueries.Articulos.Command.Update;
using Application.CommandsQueries.Articulos;
using Application.CommandsQueries.Articulos.Queries.Get;
using Application.CommandsQueries.Articulos.Queries.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ophelia.WebUI.Controllers
{
    /// <summary>
    /// Controlador de Articulos. api/Articulo
    /// </summary>
    [OpenApiTagAttribute("Articulo",
           Description = "Controlador Articulos.")]
    public class ArticuloController : ApiController
    {
        /// <summary>
        /// Add Articulo
        /// </summary>
        /// <remarks>
        /// Create new record for Articulos
        /// </remarks>
        /// <param name="command">Instance for CreateArticuloRequest</param>
        /// <returns></returns>
        // POST: api/Articulo/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateArticuloRequest command)
        {
            return await base.Command<CreateArticuloRequest, ArticuloExistenciaDto>(command);
        }
        /// <summary>
        /// Update Articulo
        /// </summary>
        /// <remarks>
        /// Update a specific record for Articulo
        /// </remarks>
        /// <param name="command">Instance for UpdateArticuloRequest</param>
        /// <returns></returns>
        // POST: api/Articulo/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateArticuloRequest command)
        {
            return await base.Command<UpdateArticuloRequest, ArticuloExistenciaDto>(command);
        }
        ///// <summary>
        ///// Delete Articulo
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Articulo
        ///// </remarks>
        ///// <param name="command">Instance for DeleteArticuloRequest</param>
        ///// <returns></returns>
        //// POST: api/Articulo/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteArticuloRequest command)
        {
            return await base.Command<DeleteArticuloRequest, ArticuloExistenciaDto>(command);
        }
        ///// <summary>
        ///// Get All Articulo
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Articulo filtered by the class paramater <code>GetAllArticuloRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllArticuloRequest</param>
        ///// <returns></returns>
        //// GET: api/Articulo/GetAll
        [ProducesResponseType(typeof(ArticuloExistenciaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllArticuloRequest command)
        {
            return await base.Query<GetAllArticuloRequest, GetAllArticuloResponse>(command);
        }
        ///// <summary>
        ///// Get Articulo
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Articulo
        ///// </remarks>
        ///// <param name="command">Instance for GetAllArticuloRequest</param>
        ///// <returns></returns>
        //// GET: api/Articulo/Get
        [ProducesResponseType(typeof(ArticuloDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetArticuloRequest command)
        {
            return await base.Query<GetArticuloRequest, ArticuloDto>(command);
        }
    }
}

