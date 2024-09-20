using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffDirectory1.Areas.Identity.Data;
using StaffDirectory1.Models;

namespace StaffDirectory1.Areas.Identity.Data;

public class StaffContext : IdentityDbContext<StaffUser>
{
    public StaffContext(DbContextOptions<StaffContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<StaffUser<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });


        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },


            new IdentityRole { Id = "2", Name = "Staff", NormalizedName = "STAFF" },



            new IdentityRole { Id ="3", Name = "Student", NormalizedName = "STUDENT"}
            );

        var hasher = new PasswordHasher<StaffUser>();
        builder.Entity<StaffUser>().HasData(

            new StaffUser
            {
                Id = "1",
                FirstName = "harminton",
                NormalizedUserName = "HARMINTON",
                LastName = "Vasquez",
                
                Email = "ac150559@avcol.school.nz",
                NormalizedEmail = "AC150559@AVCOL.SCHOOL.NZ",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123")
            },
            new StaffUser
            {
                Id = "2",
                FirstName = "staff",
                NormalizedUserName = "STAFF@EXAMPLE.COM",
                LastName = "Member",
                Email = "staff@example.com",
                NormalizedEmail = "STAFF@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "staff123")
            },
            new StaffUser
            {
                Id = "3",
                FirstName = "Student",
                NormalizedUserName = "STUDENT@EXAMPLE.COM",
                LastName = "Member",
                Email = "Student@example.com",
                NormalizedEmail = "STUDENT@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Student123")
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = "1", UserId = "1" },
            new IdentityUserRole<string> { RoleId = "2", UserId = "2" },
            new IdentityUserRole<string> { RoleId = "3", UserId = "3" }

            );
    }
        //Customize the ASP.NET Identity model and override the defaults if needed.
        //For example, you can rename the ASP.NET Identity table names and more.
        //Add your customizations after calling base.OnModelCreating(builder);


    public DbSet<StaffDirectory.Models.Staff>? Staff { get; set; }

    public DbSet<StaffDirectory.Models.Subjects>? Subjects { get; set; }

    public DbSet<StaffDirectory.Models.TimeTable>? TimeTable { get; set; }

    public DbSet<StaffDirectory.Models.Students>? Students { get; set; }

    public DbSet<StaffDirectory.Models.Departments>? Departments { get; set; }

    public DbSet<StaffDirectory.Models.DepartmentStaff>? DepartmentStaff { get; set; }

    public DbSet<StaffDirectory.Models.PersonalInformation>? PersonalInformation { get; set; }
}

internal class StaffUser<T>
{
    public string? LoginProvider { get; internal set; }
    public string ProviderKey { get; internal set; }
}