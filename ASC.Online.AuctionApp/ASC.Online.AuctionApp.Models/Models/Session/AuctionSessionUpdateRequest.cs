using System;

namespace ASC.Online.AuctionApp.Framework.Models.Models.Session
{
    public class AuctionSessionUpdateRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the session.
        /// </summary>
        /// <value>
        /// The name of the session.
        /// </value>
        public string SessionName { get; set; }
        /// <summary>
        /// Gets or sets the session description.
        /// </summary>
        /// <value>
        /// The session description.
        /// </value>
        public string SessionDescription { get; set; }

        /// <summary>
        /// Gets or sets the session start date.
        /// </summary>
        /// <value>
        /// The session start date.
        /// </value>
        public DateTime SessionStartDate { get; set; }

        /// <summary>
        /// Gets or sets the session end date.
        /// </summary>
        /// <value>
        /// The session end date.
        /// </value>
        public DateTime SessionEndDate { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        /// <value>
        /// The number of items.
        /// </value>
        public int NumberOfItems { get; set; }

        /// <summary>
        /// Gets or sets the session status.
        /// </summary>
        /// <value>
        /// The session status.
        /// </value>
        public string SessionStatus { get; set; }

        // <summary>
        /// Gets or sets the created member identifier.
        /// </summary>
        /// <value>
        /// The created member identifier.
        /// </value>
        public long CreatedMemberId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified member identifier.
        /// </summary>
        /// <value>
        /// The modified member identifier.
        /// </value>
        public long ModifiedMemberId { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }
    }
}
