using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePortal.Areas.Identity.Data
{
    public class ApplicationUserEntityConfiguration : BaseEntityConfiguration<ApplicationUser>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
}
