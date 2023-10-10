using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePortal.Areas.Identity.Data.Employee
{
    public class EmployeeEntityConfiguration : BaseEntityConfiguration<EmployeeEntity>
    {
        public override void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.DepartmentName).HasMaxLength(255);
            builder.Property(u => u.CategoryName).HasMaxLength(255);
            builder.Property(u => u.SubCategoryName).HasMaxLength(255);
            builder.Property(u => u.LocationName).HasMaxLength(255);
            builder.Property(u => u.E1).HasMaxLength(50);
            builder.Property(u => u.E2).HasMaxLength(50);
            builder.Property(u => u.M1).HasMaxLength(50);
            builder.Property(u => u.M2).HasMaxLength(50);
        }
    }

}
