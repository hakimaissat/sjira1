using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class DashboardMap : EntityTypeConfiguration<Dashboard>
    {
        public DashboardMap()
        {
            // Primary Key
            this.HasKey(t => t.DashboardId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Dashboard");
            this.Property(t => t.DashboardId).HasColumnName("DashboardId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Favorite).HasColumnName("Favorite");
            this.Property(t => t.SharedWithId).HasColumnName("SharedWithId");
            this.Property(t => t.OwnerId).HasColumnName("OwnerId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.DashboardTypeId).HasColumnName("DashboardTypeId");

            // Relationships
            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.Dashboards)
                .HasForeignKey(d => d.OwnerId);

            this.HasOptional(t => t.Parent)
                .WithMany(t => t.Childs)
                .HasForeignKey(d => d.ParentId);
            this.HasOptional(t => t.DashboardType)
                .WithMany(t => t.Dashboards)
                .HasForeignKey(d => d.DashboardTypeId);
            this.HasOptional(t => t.SharedWith)
                .WithMany(t => t.Dashboards)
                .HasForeignKey(d => d.SharedWithId);
            

        }
    }
}
