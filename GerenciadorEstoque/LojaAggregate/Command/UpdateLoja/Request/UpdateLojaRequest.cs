using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request
{
    public sealed record UpdateNomeRequest : IRequest<UpdateLojaResponse>
    {
        public Guid LojaId { get; set; }
        public string NovoNome { get; set; }
    }

    public class UpdateEnderecoRequest : IRequest<UpdateLojaResponse>
    {
        public Guid LojaId { get; set; }
        public Endereco NovoEndereco { get; set; }
    }

    public class UpdateCodigoRequest : IRequest<UpdateLojaResponse>
    {
        public Guid LojaId { get; set; }
        public CodigoLoja NovoCodigo { get; set; }
    }

    public class UpdateTelefoneRequest : IRequest<UpdateLojaResponse>
    {
        public Guid LojaId { get; set; }
        public TelefoneLoja NovoTelefone { get; set; }
    }
}
