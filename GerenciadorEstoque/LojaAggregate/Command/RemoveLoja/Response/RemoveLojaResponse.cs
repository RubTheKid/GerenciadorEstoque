namespace GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Response
{
    public sealed record RemoveLojaResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
