using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
      public class UserProfileMap : EntityTypeConfiguration<UserProfile>
        {
            public UserProfileMap()
            {
                // Primary Key
                this.HasKey(t => t.UserId);

                // Properties
                this.Property(t => t.UserName)
                    .HasMaxLength(100);

                // Table & Column Mappings
                this.ToTable("UserProfile");
                this.Property(t => t.UserId).HasColumnName("UserId");
                this.Property(t => t.UserName).HasColumnName("UserName");
                this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");


            }
        }
    
}
