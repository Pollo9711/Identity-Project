using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExampleIdentityService.Context
{
    public class ExampleIdentityServiceDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int,
        IdentityUserClaim<int>,IdentityUserRole<int>,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public ExampleIdentityServiceDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
