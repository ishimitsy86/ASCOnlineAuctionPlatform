using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASC.Online.AuctionApp.Framework.Models.Models.Session
{
    /// <summary>
    /// Auction Session update response DTO
    /// </summary>
    public class AuctionSessionUpdateResponse
    {
        /// <summary>
        /// Gets or sets the update request.
        /// </summary>
        /// <value>
        /// The update request.
        /// </value>
        public AuctionSessionUpdateRequest UpdateRequest { get; set; }

        /// <summary>
        /// Gets or sets the state of the action model.
        /// </summary>
        /// <value>
        /// The state of the action model.
        /// </value>
        public ModelStateDictionary ActionModelState { get; set; }
    }
}
