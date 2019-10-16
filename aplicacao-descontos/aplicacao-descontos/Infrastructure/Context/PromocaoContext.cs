using aplicacaodescontos.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicacaodescontos.Infrastructure.Context
{
    public class PromocaoContext : DbContext
    {
        public DbSet<Promocao> Promocao { get; set; }

        public PromocaoContext(DbContextOptions<PromocaoContext> options)
            : base(options)
        {
        }   

    }
}
