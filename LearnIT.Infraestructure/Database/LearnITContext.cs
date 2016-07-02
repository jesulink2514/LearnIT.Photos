using System.Data.Entity;
using LearnIT.Domain;

namespace LearnIT.Infraestructure.Database
{
    public class LearnITContext:DbContext
    {
        public LearnITContext():base("name=LearnITDb")
        {
        }

        public DbSet<Photo> Photos { get; set; }
    }
}
