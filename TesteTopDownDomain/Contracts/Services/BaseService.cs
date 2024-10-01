using FluentValidation;
using System.ComponentModel.DataAnnotations;
using TesteTopDownDomain.Contracts.Interface;
using TesteTopDownDomain.Contracts.Models;
using TesteTopDownDomain.Notificacoes;

namespace TesteTopDownDomain.Contracts.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            Notificar(validationResult.ErrorMessage);            
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator.ToString());

            return false;            
        }
    }
}
