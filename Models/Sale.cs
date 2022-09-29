using ItemMarketplace.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemMarketplace.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public MarketStatus Status { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
    }
}
