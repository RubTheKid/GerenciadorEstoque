using GerenciadorEstoque.Application.LojaAggregate.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Application.LojaAggregate.Queries;

public class GetLojaByIdQuery : IRequest<LojaDto>
{
    public Guid Id { get; }

    public GetLojaByIdQuery(Guid id)
    {
        Id = id;
    }
}
