using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace PersonManagmentAPI.Model
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonContext(DbContextOptions options) : base(options) { }

    }
}
