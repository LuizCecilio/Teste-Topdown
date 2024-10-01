using TesteTopDownDomain.Notificacoes;

namespace TesteTopDownDomain.Contracts.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
