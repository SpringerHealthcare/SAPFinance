namespace SAPFinanceODataService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_SAPFinance_Quotes
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Solicitation_Quotes_ID { get; set; }

        [StringLength(250)]
        public string QuoteRefNo { get; set; }

        public DateTime QuoteDate { get; set; }

        public int article_id { get; set; }

        [StringLength(500)]
        public string article_title { get; set; }

        [StringLength(200)]
        public string citation { get; set; }

        [StringLength(500)]
        public string author { get; set; }

        [StringLength(150)]
        public string Journal_Title { get; set; }

        public int Sales_Person_ID { get; set; }

        [StringLength(62)]
        public string Salesperson { get; set; }

        public int adis_office_id { get; set; }

        [StringLength(10)]
        public string SAPCRM_Account_ID { get; set; }

        [StringLength(10)]
        public string SAPCRM_Contact_ID { get; set; }

        [StringLength(102)]
        public string Client { get; set; }

        [StringLength(200)]
        public string Company { get; set; }
    }
}
