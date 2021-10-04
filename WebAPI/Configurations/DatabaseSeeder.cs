using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Configurations
{
    public class DatabaseSeeder
    {
        public static void Seed(WebAPIContext context)
        {
            context.Database.Migrate();
        }
    }
}
