using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
   public class DashboardTypeMap : EntityTypeConfiguration<DashboardType>
    {
        public DashboardTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DashboardTypeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("DashboardType");
            this.Property(t => t.DashboardTypeId).HasColumnName("DashboardTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Layout).HasColumnName("Layout");
        }
    }
}
