using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class DashboardMenuItemMap : EntityTypeConfiguration<DashboardMenuItem>
    {
        public DashboardMenuItemMap()
        {
            // Primary Key
            this.HasKey(t => t.DashboardMenuItemId);

            // Properties
            this.Property(t => t.ModifiedDate)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("DashboardMenuItem");
            this.Property(t => t.DashboardMenuItemId).HasColumnName("DashboardMenuItemId");
            this.Property(t => t.MenuItemId).HasColumnName("MenuItemId");
            this.Property(t => t.DashboardId).HasColumnName("DashboardId");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Dashboard)
                .WithMany(t => t.DashboardMenuItems)
                .HasForeignKey(d => d.DashboardId);
            this.HasRequired(t => t.MenuItem)
                .WithMany(t => t.DashboardMenuItems)
                .HasForeignKey(d => d.MenuItemId);

        }
    }
}
