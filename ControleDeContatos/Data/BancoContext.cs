using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {           
        }

       public DbSet<Contato> Contatos{ get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
