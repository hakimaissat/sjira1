using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class SharesFavoriteMap : EntityTypeConfiguration<SharesFavorite>
    {
        public SharesFavoriteMap()
        {
            // Primary Key
            this.HasKey(t => t.SharesFavoriteId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SharesFavorite");
            this.Property(t => t.SharesFavoriteId).HasColumnName("SharesFavoriteId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
