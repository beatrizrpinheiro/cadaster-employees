using Bootcamp1st.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp1st.Data
{
    public class EmployesContext : DbContext
    {
        public EmployesContext(DbContextOptions<EmployesContext> options)
            : base (options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = default!;
    }
}
