using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class BoardMap : EntityTypeConfiguration<Board>
    {
        public BoardMap()
        {
            // Primary Key
            this.HasKey(t => t.BoardId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Board");
            this.Property(t => t.BoardId).HasColumnName("BoardId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProjetId).HasColumnName("ProjetId");
            this.Property(t => t.BoardTypeId).HasColumnName("BoardTypeId");

            // Relationships
            this.HasOptional(t => t.BoardType)
                .WithMany(t => t.Boards)
                .HasForeignKey(d => d.BoardTypeId);
            this.HasOptional(t => t.Project)
                .WithMany(t => t.Boards)
                .HasForeignKey(d => d.ProjetId);

        }
    }
}
