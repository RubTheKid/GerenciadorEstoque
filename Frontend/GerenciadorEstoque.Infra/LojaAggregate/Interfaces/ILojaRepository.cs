using GerenciadorEstoque.Domain.Entities.LojaAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Infra.LojaAggregate.Interfaces
{
    public interface ILojaRepository
    {
        Task<Loja> GetById(Guid id);
    }
}
