using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using ASC.Online.AuctionApp.SessionSetup.DataAccess.Models;
using AutoMapper;

namespace ASC.Online.AuctionApp.SessionSetup.Business.Profiles
{
    /// <summary>
    /// Automapper mapping profile for Sessions
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Sessions, AuctionSession>().ReverseMap();
            CreateMap<Sessions, AuctionSessionCreateRequest>().ReverseMap();
            CreateMap<Sessions, AuctionSessionUpdateRequest>().ReverseMap();
        }
    }
}
