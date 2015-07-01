using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class GadgetMap : EntityTypeConfiguration<Gadget>
    {
        public GadgetMap()
        {
            // Primary Key
            this.HasKey(t => t.GadgetId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Gadget");
            this.Property(t => t.GadgetId).HasColumnName("GadgetId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.MenuAction).HasColumnName("MenuAction");
            this.Property(t => t.MenuIcon).HasColumnName("MenuIcon");
            this.Property(t => t.OwnerId).HasColumnName("OwnerId");
            this.Property(t => t.GadgetTypeId).HasColumnName("GadgetTypeId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.GadgetType)
                .WithMany(t => t.Gadgets)
                .HasForeignKey(d => d.GadgetTypeId);
            this.HasOptional(t => t.ApplicationUser)
                .WithMany(t => t.Gadgets)
                .HasForeignKey(d => d.OwnerId);

        }
    }
}
