using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Jacques",
                    Email = "jacquesbmoraes@hotmail.com",
                    UserName = "jacquesbmoraes@hotmail.com",
                    Address = new Address
                    {
                        FirstName = "jacques",
                        LastName = "moraes",
                        Street = "av prefeito ary alcantara 1001",
                        City = "pelotas",
                        State = "rio grande do sul",
                        ZipCode = "96081-700"
                    }
                };
                await userManager.CreateAsync(user, "Jacque$40707");
            }
        }
    }
}
