using System.Collections.Generic;

namespace ASC.Online.AuctionApp.ApiGateway
{
    public class IdentityServerConfig
    {
        public string Url { get; set; }
        public string GatewayProxyForwardPath { get; set; }
        public string IdentityScheme { get; set; }
        public List<ApiResource> Resources { get; set; }
        public string ProxyPrefix { get; set; }
        
    }
}
