using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class GadgetTypeMap : EntityTypeConfiguration<GadgetType>
    {
        public GadgetTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.GadgetTypeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("GadgetType");
            this.Property(t => t.GadgetTypeId).HasColumnName("GadgetTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
