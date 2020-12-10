using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using ASC.Online.AuctionApp.SessionSetup.Business.Components.Interface;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Contexts.Interfaces;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.SessionSetup.Business.Components
{
    /// <summary>
    /// Sessions component class
    /// </summary>
    /// <seealso cref="ASC.Online.AuctionApp.SessionSetup.Business.Components.Interface.ISessionComponent" />
    public class SessionComponent : ISessionComponent
    {
        #region Private Fields        
        /// <summary>
        /// The session context
        /// </summary>
        private readonly ISessionContext sessionContext;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;
        #endregion Private Fields

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionComponent"/> class.
        /// </summary>
        /// <param name="sessionContext">The session context.</param>
        /// <exception cref="System.ArgumentNullException">sessionContext</exception>
        public SessionComponent(ISessionContext sessionContext, IMapper mapper)
        {
            this.sessionContext = sessionContext ?? throw new ArgumentNullException(nameof(sessionContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion Constructor

        #region Private Methods        
        /// <summary>
        /// Checks if duplicate session exsists.
        /// </summary>
        /// <param name="sessionName">Name of the session.</param>
        /// <returns></returns>
        private bool CheckIfDuplicateSessionExsists(string sessionName)
        {
            return ((this.sessionContext?.AuctionSetupDbSet
                .Where(x => x.SessionName.ToUpper() == sessionName.ToUpper()).FirstOrDefault()) != null);
        }
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Gets all sessions asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AuctionSession>> GetAllSessionsAsync()
        {
            IEnumerable<Sessions> sessions = await this.sessionContext?.GetAllAsync();
            IEnumerable<AuctionSession> sessionsList = this.mapper.Map<IEnumerable<Sessions>, IEnumerable<AuctionSession>>(sessions);
            return sessionsList;
        }

        /// <summary>
        /// Gets the sesssion asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AuctionSession> GetSesssionAsync(long id)
        {
            Sessions sessionEntity = await this.sessionContext?.GetAsync(id);
            AuctionSession session = this.mapper.Map<Sessions, AuctionSession>(sessionEntity);
            return session;
        }

        /// <summary>
        /// Adds the session.
        /// </summary>
        /// <param name="auctionSession">The auction session.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AuctionSession> AddSession(AuctionSessionCreateRequest auctionSession)
        {
            if (this.CheckIfDuplicateSessionExsists(auctionSession.SessionName))
            {
                return null;
            }
            Sessions sessionEntity = this.mapper.Map<AuctionSessionCreateRequest, Sessions>(auctionSession);
            await this.sessionContext?.Add(sessionEntity);
            AuctionSession createdSession = this.mapper.Map<Sessions, AuctionSession>(sessionEntity);
            return createdSession;
        }

        /// <summary>
        /// Patches the update session.
        /// </summary>
        /// <param name="auctionSessionUpdateRequestss">The auction session update requestss.</param>
        /// <returns></returns>
        public async Task<bool> PatchUpdateSession(AuctionSessionUpdateRequest auctionSessionUpdateRequestss)
        {
            var allSessions = await this.sessionContext?.GetAllAsync();
            var selectedSession = allSessions.FirstOrDefault(x => x.Id == auctionSessionUpdateRequestss.Id);
            if (selectedSession != null)
            {
                this.sessionContext?.PatchUpdate();
                return true;
            }
            return false;
        }

        public async Task<AuctionSessionUpdateResponse> ValidateAuctionPatchDocument(long id, JsonPatchDocument<AuctionSessionUpdateRequest> patchDocument)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();
            var sessionEntity = await this.sessionContext?.GetAsync(id);
            this.sessionContext.AuctionSetupDbSet.Attach(sessionEntity);

            AuctionSessionUpdateRequest auctionSessionToPatch =
                this.mapper.Map<Sessions, AuctionSessionUpdateRequest>(sessionEntity);
            patchDocument.ApplyTo(auctionSessionToPatch, modelState);

            this.mapper.Map<AuctionSessionUpdateRequest, Sessions>(auctionSessionToPatch);
            return new AuctionSessionUpdateResponse()
            {
                UpdateRequest = auctionSessionToPatch,
                ActionModelState = modelState
            };
        }

        /// <summary>
        /// Puts the update session.
        /// </summary>
        /// <param name="auctionSessionUpdateRequest">The auction session update request.</param>
        /// <returns></returns>
        public async Task<bool> PutUpdateSession(AuctionSessionUpdateRequest auctionSessionUpdateRequest)
        {
            var allSessions = await this.sessionContext?.GetAllAsync();            
            Sessions sessionEntity = this.mapper.Map<AuctionSessionUpdateRequest, Sessions>(auctionSessionUpdateRequest);
           
            var selectedSession = allSessions.FirstOrDefault(x => x.Id == auctionSessionUpdateRequest.Id);
            if (selectedSession != null)
            {
                sessionEntity.CreatedBy = selectedSession.CreatedBy;
                sessionEntity.CreatedDate = selectedSession.CreatedDate;
                sessionEntity.CreatedMemberId = selectedSession.CreatedMemberId;
                this.sessionContext.PutUpdate(sessionEntity);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes the session.
        /// </summary>
        /// <param name="session">The session.</param>
        public void DeleteSession(AuctionSession session)
        {
            Sessions sessionEntity = this.mapper.Map<AuctionSession, Sessions>(session);
            this.sessionContext.Delete(sessionEntity);
        }
        #endregion Public Methods
    }
}
