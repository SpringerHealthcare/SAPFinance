namespace SAPFinanceODataService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Solicitation_Quotes
    {
        public tbl_Solicitation_Quotes()
        {
            tbl_Quote_Quantities = new HashSet<tbl_Quote_Quantities>();
        }

        [Key]
        public int Solicitation_Quotes_ID { get; set; }

        public int Solicitation_Action_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string QuoteRefNo { get; set; }

        public DateTime QuoteDate { get; set; }

        public int ValidDays { get; set; }

        public int Numeracy { get; set; }

        public int? QuoteOutcomeID { get; set; }

        [StringLength(1000)]
        public string QuoteComments { get; set; }

        public DateTime? ClosedDate { get; set; }

        public virtual ICollection<tbl_Quote_Quantities> tbl_Quote_Quantities { get; set; }
    }
}
