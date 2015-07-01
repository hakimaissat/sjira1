using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class MenuItemMap : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuItemId);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MenuItem");
            this.Property(t => t.MenuItemId).HasColumnName("MenuItemId");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.MenuAction).HasColumnName("MenuAction");
            //this.Property(t => t.MenuManagerId).HasColumnName("MenuManagerId");
            this.Property(t => t.MenuItemTypeId).HasColumnName("MenuItemTypeId");

            // Relationships
            this.HasOptional(t => t.Parent)
                .WithMany(t => t.Child)
                .HasForeignKey(d => d.ParentId);
            this.HasOptional(t => t.MenuItemType)
                .WithMany(t => t.MenuItems)
                .HasForeignKey(d => d.MenuItemTypeId);
            //this.HasRequired(t => t.MenuManager)
            //    .WithMany(t => t.MenuItems)
            //    .HasForeignKey(d => d.MenuManagerId);

        }
    }
}
