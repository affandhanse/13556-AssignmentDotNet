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
                    UserId = "a4e636da-e2f5-49eb-850f-b470e22812a9",
                    RoleId = "a76f06ef-4878-49cb-o7e2-6489cb3454ba",
                });
        }
    }
}