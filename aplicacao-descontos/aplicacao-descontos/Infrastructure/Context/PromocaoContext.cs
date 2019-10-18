using aplicacaodescontos.Domain;
using Microsoft.EntityFrameworkCore;

namespace aplicacaodescontos.Infrastructure.Context
{
    public class PromocaoContext : DbContext
    {
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Restricao> Restricao { get; set; }

        public PromocaoContext(DbContextOptions<PromocaoContext> options)
            : base(options)
        {
        }   

    }
}
