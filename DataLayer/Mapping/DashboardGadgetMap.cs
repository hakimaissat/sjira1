using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class DashboardGadgetMap : EntityTypeConfiguration<DashboardGadget>
    {
        public DashboardGadgetMap()
        {
            // Primary Key
            this.HasKey(t => t.DashboardGadgetId);

            // Properties
            this.Property(t => t.ModifiedDate)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("DashboardGadget");
            this.Property(t => t.DashboardGadgetId).HasColumnName("DashboardGadgetId");
            this.Property(t => t.GadgetId).HasColumnName("GadgetId");
            this.Property(t => t.DashboardId).HasColumnName("DashboardId");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Dashboard)
                .WithMany(t => t.Dashboard_Gadgets)
                .HasForeignKey(d => d.DashboardId);
            this.HasRequired(t => t.Gadget)
                .WithMany(t => t.Dashboard_Gadgets)
                .HasForeignKey(d => d.GadgetId);

        }
    }
}
