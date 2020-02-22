using SimpleLibrary.Models;
using System.Data.Entity.ModelConfiguration;

namespace SimpleLibrary.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(c => c.FirstName)
                .HasMaxLength(50);

            Property(c => c.LastName)
                .HasMaxLength(50);
        }
    }
}