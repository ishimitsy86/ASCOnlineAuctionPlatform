namespace ASC.Online.AuctionApp.Framework.Models.Models.Item
{
    /// <summary>
    /// Auction Item DTO
    /// </summary>
    public class AuctionItem
    {
        public long ItemId { get; set; }
        public long SessionId { get; set; }
        public long OwnerId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Category { get; set; }
        public string ItemStatus { get; set; }
        public int Quantity { get; set; }
        public double DisplayPrice { get; set; }
        public double FairMarketValue { get; set; }
        public double MinimumBid { get; set; }
        public string ImageUrl { get; set; }
        public string SalesStaus { get; set; }
    }
}
