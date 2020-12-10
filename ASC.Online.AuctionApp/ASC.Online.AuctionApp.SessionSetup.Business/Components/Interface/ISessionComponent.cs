using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.SessionSetup.Business.Components.Interface
{
    /// <summary>
    /// Operation contract interface for Sessions component
    /// </summary>
    public interface ISessionComponent
    {
        Task<IEnumerable<AuctionSession>> GetAllSessionsAsync();
        Task<AuctionSession> GetSesssionAsync(long id);
        Task<AuctionSession> AddSession(AuctionSessionCreateRequest auctionSession);
        Task<bool> PatchUpdateSession(AuctionSessionUpdateRequest auctionSessionUpdateRequestss);
        Task<bool> PutUpdateSession(AuctionSessionUpdateRequest auctionSessionUpdateRequest);
        void DeleteSession(AuctionSession session);
        Task<AuctionSessionUpdateResponse> ValidateAuctionPatchDocument(long id, JsonPatchDocument<AuctionSessionUpdateRequest> patchDocument);
    }
}
