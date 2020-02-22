using SimpleLibrary.Models;
using System.Data.Entity.ModelConfiguration;

namespace SimpleLibrary.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(20);

            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(30);

            HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
        }
    }
}