using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId=Guid.Parse("28235D4C-8428-47B8-96C3-7AE23EBAFCA9"),
                RoleId= Guid.Parse("7202D761-FC41-483D-8AC3-A055797EBFB0")

            },
            new AppUserRole
            {
                UserId= Guid.Parse("62A1399A-9802-41EA-9B25-68C523AF5783"),
                RoleId= Guid.Parse("1C48E849-E8D7-46EE-AA61-A6FDA42D7929"),
            });

        }
    }
}
