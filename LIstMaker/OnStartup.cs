using LIstMaker.Data;
using LIstMaker.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Text;

namespace ListMaker
{
    public class OnStartup
    {

        public static async void CheckForAdmin(WebApplication App)
        {
            using var scope = App.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<LIstMakerContext>();
            var logger = services.GetService<ILogger<OnStartup>>();
            if(!context.Users.Where(u => u.UserName == "admin").Any())
            {
                using var HMAC = new HMACSHA512();
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin",
                    isAdmin = true,
                    PasswordHash = HMAC.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                    PasswordSalt = HMAC.Key
                };
                context.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
