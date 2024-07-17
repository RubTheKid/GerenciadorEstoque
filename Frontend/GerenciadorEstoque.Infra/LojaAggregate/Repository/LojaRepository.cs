using GerenciadorEstoque.Domain.Entities.LojaAggregate;
using GerenciadorEstoque.Infra.LojaAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Infra.LojaAggregate.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly AppDb
        public Task<Loja> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
