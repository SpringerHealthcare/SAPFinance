namespace SAPFinanceODataService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class vw_SAPFinance_QuoteLines
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity_ID { get; set; }

        public int Quantity { get; set; }

        public string Currency { get; set; }

        public decimal PricePerReprintLocal { get; set; }

        public decimal TotalPriceLocal { get; set; }

        public decimal TotalPriceEUR { get; set; }

        public bool Translated { get; set; }

        public bool Covered { get; set; }

        [StringLength(200)]
        public string TranslatedLanguage { get; set; }

        public int Solicitation_Quotes_ID { get; set; }

        [StringLength(250)]
        public string QuoteRefNo { get; set; }
    }
}