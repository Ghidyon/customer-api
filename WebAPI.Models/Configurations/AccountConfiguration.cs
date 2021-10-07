using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account 
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Number = "1005345781",
                    Balance = 50.00m,
                    CustomerId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Account
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Number = "2333323424",
                    Balance = 510.99m,
                    CustomerId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
                }                
            );
        }
    }
}
