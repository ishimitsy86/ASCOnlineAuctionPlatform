using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using ASC.Online.AuctionApp.SessionSetup.Business.Components.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.SessionSetup.Api.Controllers
{
    /// <summary>
    /// Sessions Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        #region Private Fields        
        /// <summary>
        /// The session component
        /// </summary>
        private readonly ISessionComponent sessionComponent;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<SessionsController> logger;
        #endregion Private Fields

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionsController"/> class.
        /// </summary>
        /// <param name="sessionComponent">The session component.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// sessionComponent
        /// or
        /// logger
        /// </exception>
        public SessionsController(ISessionComponent sessionComponent, ILogger<SessionsController> logger)
        {
            this.sessionComponent = sessionComponent ?? throw new ArgumentNullException(nameof(sessionComponent));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion Constructor

        #region Public Methods:Actions        
        /// <summary>
        /// Gets all sessions asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuctionSession>>> GetAllSessionsAsync()
        {
            logger.LogInformation("Started fetching Auction sessions....");
            var results = await this.sessionComponent?.GetAllSessionsAsync();
            return Ok(results);
        }

        /// <summary>
        /// Gets the session by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}", Name ="GetSessionById")]
        public async Task<ActionResult<AuctionSession>> GetSessionById(long id)
        {
            logger.LogInformation($"Session with id: {id}");
            var auctionSession = await this.sessionComponent?.GetSesssionAsync(id);
            if (auctionSession == null)
            {
                return NotFound();
            }
            return Ok(auctionSession);
        }

        /// <summary>
        /// Creates the session.
        /// </summary>
        /// <param name="auctionSessionCreateRequest">The auction session create request.</param>
        /// <returns></returns>
        [HttpPost]        
        public async Task<ActionResult<AuctionSession>> CreateSession([FromBody]AuctionSessionCreateRequest auctionSessionCreateRequest)
        {
            AuctionSession auctionSession = await this.sessionComponent?.AddSession(auctionSessionCreateRequest);
            if (auctionSession == null)
            {
                return NoContent();
            }
            return CreatedAtRoute(nameof(GetSessionById), new
            {
                varsion = HttpContext?.GetRequestedApiVersion().ToString(),
                id = auctionSession.Id
            }, auctionSession);
        }

        /// <summary>
        /// Partiallies the update session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="jsonPatchDocument">The json patch document.</param>
        /// <returns></returns>
        [HttpPatch("id/{id}")]
        public async Task<ActionResult> PartiallyUpdateSession(long id, [FromBody] JsonPatchDocument<AuctionSessionUpdateRequest> jsonPatchDocument)
        {
            var validatedResult = await this.sessionComponent?.ValidateAuctionPatchDocument(id, jsonPatchDocument);
            if (!validatedResult.ActionModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(validatedResult.UpdateRequest))
            {
                return BadRequest(ModelState);
            }
            var isUpdated = this.sessionComponent?.PatchUpdateSession(validatedResult.UpdateRequest).Result;
            if (isUpdated.HasValue && isUpdated.Value)
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        /// Updates the session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updateRequest">The update request.</param>
        /// <returns></returns>
        [HttpPut("id/{id}")]
        public async Task<ActionResult> UpdateSession(long id, [FromBody] AuctionSessionUpdateRequest updateRequest)
        {
            if (id != updateRequest.Id)
            {
                return BadRequest();
            }
            var isUpdated = await this.sessionComponent?.PutUpdateSession(updateRequest);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Deletes the session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSession(long id)
        {
            var sessionEntity = await this.sessionComponent?.GetSesssionAsync(id);
            if (sessionEntity == null)
            {
                return NotFound();
            }
            this.sessionComponent.DeleteSession(sessionEntity);
            return NoContent();
        }

        #endregion Public Methods:Actions

    }
}
