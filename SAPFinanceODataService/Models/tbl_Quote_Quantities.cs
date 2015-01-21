namespace SAPFinanceODataService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Quote_Quantities
    {
        [Key]
        public int Quantity_ID { get; set; }

        public int Solicitation_Quotes_ID { get; set; }

        public int Quantity { get; set; }

        public int Currency_ID { get; set; }

        public decimal PricePerReprintLocal { get; set; }

        public decimal TotalPriceLocal { get; set; }

        public decimal TotalPriceUS { get; set; }

        public bool Translated { get; set; }

        public bool Covered { get; set; }

        [StringLength(200)]
        public string TranslatedLanguage { get; set; }

        public virtual tbl_Solicitation_Quotes tbl_Solicitation_Quotes { get; set; }
    }
}
