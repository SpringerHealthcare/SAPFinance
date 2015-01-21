namespace SAPFinanceODataService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_SAPFinance_Terms
    {
        [Key]
        public int qualified_term_id { get; set; }

        public int article_id { get; set; }

        public int term_id { get; set; }

        [StringLength(1000)]
        public string term { get; set; }

        public int qualifier_id { get; set; }

        [StringLength(1000)]
        public string qualifier { get; set; }
    }
}
