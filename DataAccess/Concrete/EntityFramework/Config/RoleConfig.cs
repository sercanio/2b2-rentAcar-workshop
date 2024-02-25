using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role() { Id = 1, Name = "User", Description = "Reguler application user registered with an email." },
                new Role() { Id = 2, Name = "Editor", Description = "A authorized user performs management tasks." },
                new Role() { Id = 3, Name = "Admin", Description = "A superuser can do enything in the app." });
        }
    }
}
