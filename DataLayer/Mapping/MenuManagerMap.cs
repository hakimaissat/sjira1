using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class MenuManagerMap : EntityTypeConfiguration<MenuManager>
    {
        public MenuManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuManagerId);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MenuManager");
            this.Property(t => t.MenuManagerId).HasColumnName("MenuManagerId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.MenuManagerTypeId).HasColumnName("MenuManagerTypeId");

            // Relationships
            this.HasOptional(t => t.MenuItem)
                .WithMany(t => t.MenuManagers)
                .HasForeignKey(d => d.MenuId);
            this.HasRequired(t => t.MenuManagerType)
                .WithMany(t => t.MenuManagers)
                .HasForeignKey(d => d.MenuManagerTypeId);

        }
    }
}
