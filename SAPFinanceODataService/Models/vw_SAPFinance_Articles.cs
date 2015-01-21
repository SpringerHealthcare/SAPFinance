namespace SAPFinanceODataService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class vw_SAPFinance_Articles
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int article_id { get; set; }

        public int article_type_id { get; set; }

        [StringLength(50)]
        public string article_type_desc { get; set; }

        [StringLength(500)]
        public string article_title { get; set; }

        [StringLength(200)]
        public string citation { get; set; }

        [StringLength(500)]
        public string author { get; set; }

        public int journal_id { get; set; }

        [StringLength(150)]
        public string journal_title { get; set; }

        public int publisher_id { get; set; }

        [StringLength(1000)]
        public string publisher { get; set; }

        public int? volume { get; set; }

        [StringLength(10)]
        public string issue { get; set; }

        public int no_of_pages { get; set; }

        public int? start_page { get; set; }

        public int? end_page { get; set; }

        public int pub_year { get; set; }

        public int pub_month { get; set; }

        public long? PMID { get; set; }

        public bool Medcomms { get; set; }

        [StringLength(100)]
        public string DOI { get; set; }

        public bool? CCBY { get; set; }

        [Column("CCBY-NC")]
        public bool? CCBYNC { get; set; }

        [StringLength(20)]
        public string ISBN_hardcover { get; set; }

        [StringLength(20)]
        public string ISBN_softcover { get; set; }

        [StringLength(20)]
        public string ISBN_ebook { get; set; }

        [StringLength(20)]
        public string ISSN_print { get; set; }

        [StringLength(20)]
        public string ISSN_electronic { get; set; }

        public int product_type_id { get; set; }

        [StringLength(60)]
        public string product_type { get; set; }

//        [StringLength(8000)]
//        public string drugs { get; set; }

//        [StringLength(1000)]
//        public string therapy_areas { get; set; }
    }
}