using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class WorkFlowMap : EntityTypeConfiguration<WorkFlow>
    {
        public WorkFlowMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkFlowId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("WorkFlow");
            this.Property(t => t.WorkFlowId).HasColumnName("WorkFlowId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.ProjectTypeId).HasColumnName("ProjectTypeId");

            // Relationships
            this.HasOptional(t => t.ProjectType)
                .WithMany(t => t.WorkFlows)
                .HasForeignKey(d => d.ProjectTypeId);

        }
    }
}
