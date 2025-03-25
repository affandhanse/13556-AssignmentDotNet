using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic_Appointment_System.Configurations
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "8b23f9ca-a0b8-4da2-b83a-83a235043957",
                    RoleId = "a76f06ef-4878-49cb-o7e2-6489cb3454ba",
                });
        }
    }
}