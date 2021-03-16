using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GHT.Core.Entities;
using GHT.Domine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHT.Domine.Seed
{
    public static class SeedGHT
    {

        public static void SeedGHTServerData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<GHTContext>();
                context.Database.Migrate();

                if (!context.Items.Any())
                {
                    context.Items.Add(new Items()
                    {
                        nameItems="PC torres",
                        unitValue= 2800,
                        residue =10

                    });
                    context.Items.Add(new Items()
                    {
                        nameItems = "Portatiles",
                        unitValue = 11220,
                        residue = 5

                    });
                    context.SaveChanges();
                }
            }
        }

    }
}
