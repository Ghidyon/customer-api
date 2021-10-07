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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Email = "admin@domain.com",
                    FullName = "Zubby Gideon",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207, USA",
                    Phone = "08160451288",
                    DateOfBirth = new DateTime(2001, 4, 11)
                },
                new Customer
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Email = "seed@domain.com",
                    FullName = "Seed Gideon",
                    Address = "583 Wall Street. Gym Oak, MD 21207, USA",
                    Phone = "015484855",
                    DateOfBirth = new DateTime(1991, 4, 11)
                }
            );
        }
    }
}
