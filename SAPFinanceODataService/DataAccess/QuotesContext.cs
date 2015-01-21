namespace SAPFinanceODataService.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SAPFinanceODataService.Models;

    public partial class QuotesContext : DbContext
    {
        public QuotesContext()
            : base("name=QuotesContext")
        {
        }

        public virtual DbSet<tbl_Quote_Quantities> tbl_Quote_Quantities { get; set; }
        public virtual DbSet<tbl_Solicitation_Quotes> tbl_Solicitation_Quotes { get; set; }
        public virtual DbSet<vw_SAPFinance_Terms> tbl_term { get; set; }
        public virtual DbSet<vw_SAPFinance_Quotes> vw_SAPFinance_Quotes { get; set; }
        public virtual DbSet<vw_SAPFinance_QuoteLines> vw_SAPFinance_QuoteLines { get; set; }
        public virtual DbSet<vw_SAPFinance_Articles> vw_SAPFinance_Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Quote_Quantities>()
                .Property(e => e.TranslatedLanguage)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Solicitation_Quotes>()
                .Property(e => e.QuoteRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Solicitation_Quotes>()
                .Property(e => e.QuoteComments)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Solicitation_Quotes>()
                .HasMany(e => e.tbl_Quote_Quantities)
                .WithRequired(e => e.tbl_Solicitation_Quotes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vw_SAPFinance_Quotes>()
                .Property(e => e.QuoteRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<vw_SAPFinance_Quotes>()
                .Property(e => e.article_title)
                .IsUnicode(false);

            modelBuilder.Entity<vw_SAPFinance_Quotes>()
                .Property(e => e.citation)
                .IsUnicode(false);

            modelBuilder.Entity<vw_SAPFinance_Quotes>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<vw_SAPFinance_Quotes>()
                .Property(e => e.Journal_Title)
                .IsUnicode(false);
        }
    }
}
