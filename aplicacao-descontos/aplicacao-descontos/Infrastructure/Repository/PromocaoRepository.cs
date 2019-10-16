using aplicacaodescontos.Domain;
using aplicacaodescontos.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aplicacaodescontos.Infrastructure.Repository
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private PromocaoContext _context;

        public PromocaoRepository(PromocaoContext context)
        {
            _context = context;
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }


        public IEnumerable<Promocao> GetPromocoes()
        {
            return _context.Promocao.ToList();
        }

    }
}
