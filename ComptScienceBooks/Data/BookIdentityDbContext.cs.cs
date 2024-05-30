using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace ComptScienceBooks.Data
{
    public class BookIdentityDbContext:IdentityDbContext<IdentityUser>
    {
        public BookIdentityDbContext(DbContextOptions options):base(options)
        {
                
        }
    }
}
