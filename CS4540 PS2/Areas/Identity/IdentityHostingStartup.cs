using System;
using CS4540_PS2.Models;
using Learning_Outcome_Tracker.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CS4540_PS2.Areas.Identity.IdentityHostingStartup))]
namespace CS4540_PS2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityDBConnection")));

                services.AddDefaultIdentity<IdentityUser>
                (config => {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDB>();

                services.AddTransient<IEmailSender, EmailSender>();
            });
        }
    }
}