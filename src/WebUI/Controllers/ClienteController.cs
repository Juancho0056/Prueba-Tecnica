using Application.CommandQueries.Clientes;
using Application.CommandQueries.Clientes.Command.Create;
using Application.CommandQueries.Clientes.Command.Delete;
using Application.CommandQueries.Clientes.Command.Update;
using Application.CommandsQueries.Clientes.Queries.Get;
using Application.CommandsQueries.Clientes.Queries.GetAll;
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
    /// Controlador de Clientes. api/Cliente
    /// </summary>
    [OpenApiTagAttribute("Cliente",
           Description = "Controlador Clientes.")]
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Add Cliente
        /// </summary>
        /// <remarks>
        /// Create new record for Clientes
        /// </remarks>
        /// <param name="command">Instance for CreateClienteRequest</param>
        /// <returns></returns>
        // POST: api/Cliente/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateClienteRequest command)
        {
            return await base.Command<CreateClienteRequest, ClienteDto>(command);
        }
        /// <summary>
        /// Update Cliente
        /// </summary>
        /// <remarks>
        /// Update a specific record for Cliente
        /// </remarks>
        /// <param name="command">Instance for UpdateClienteRequest</param>
        /// <returns></returns>
        // POST: api/Cliente/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateClienteRequest command)
        {
            return await base.Command<UpdateClienteRequest, ClienteDto>(command);
        }
        ///// <summary>
        ///// Delete Cliente
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Cliente
        ///// </remarks>
        ///// <param name="command">Instance for DeleteClienteRequest</param>
        ///// <returns></returns>
        //// POST: api/Cliente/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteClienteRequest command)
        {
            return await base.Command<DeleteClienteRequest, ClienteDto>(command);
        }
        ///// <summary>
        ///// Get All Cliente
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Cliente filtered by the class paramater <code>GetAllClienteRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllClienteRequest</param>
        ///// <returns></returns>
        //// GET: api/Cliente/GetAll
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllClienteRequest command)
        {
            return await base.Query<GetAllClienteRequest, GetAllClienteResponse>(command);
        }
        ///// <summary>
        ///// Get Cliente
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Cliente
        ///// </remarks>
        ///// <param name="command">Instance for GetAllClienteRequest</param>
        ///// <returns></returns>
        //// GET: api/Cliente/Get
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetClienteRequest command)
        {
            return await base.Query<GetClienteRequest, ClienteDto>(command);
        }
    }
}

