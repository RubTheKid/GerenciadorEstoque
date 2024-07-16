using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request
{
    public sealed record UpdateLojaRequest : IRequest<UpdateLojaResponse>
    {
        public Guid LojaId { get; set; }
        public string NovoNome { get; set; }
        public Endereco NovoEndereco { get; set; }
        public CodigoLoja NovoCodigo { get; set; }
        public TelefoneLoja NovoTelefone { get; set; }
    }
}
