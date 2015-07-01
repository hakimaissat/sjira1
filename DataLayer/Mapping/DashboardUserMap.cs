using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class DashboardUserMap : EntityTypeConfiguration<DashboardUser>
    {
        public DashboardUserMap()
        {
            // Primary Key
            this.HasKey(t => t.DashboardUserId);

            // Properties
            this.Property(t => t.ModifiedDate)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("DashboardUser");
            this.Property(t => t.DashboardUserId).HasColumnName("DashboardUserId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.DashboardId).HasColumnName("DashboardId");
            this.Property(t => t.Favorite).HasColumnName("Favorite");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Dashboard)
                .WithMany(t => t.Dashboard_Users)
                .HasForeignKey(d => d.DashboardId);
            //.WillCascadeOnDelete( false );

            this.HasRequired(t => t.ApplicationUser)
                .WithMany(t => t.Dashboard_Users)
                .HasForeignKey(d => d.UserId)
           .WillCascadeOnDelete( false );


        }
    }
}
