using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class MenuItemTypeMap : EntityTypeConfiguration<MenuItemType>
    {
        public MenuItemTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuItemTypeId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.IconUrl)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MenuItemType");
            this.Property(t => t.MenuItemTypeId).HasColumnName("MenuItemTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.IconUrl).HasColumnName("IconUrl");
        }
    }
}
