using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório")
                .MinimumLength(10).WithMessage("O telefone deve ter no mínimo 10 caracteres");

            RuleFor(v => v.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado")
                .Must(HaveMinimumAge).WithMessage("O vendedor deve ter pelo menos 18 anos");

            RuleFor(v => v.Endereco)
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres");

            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação deve ser no passado ou presente");

            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("A comissão deve ser entre 0% e 100%");

            RuleFor(v => v.MetaMensal)
                .GreaterThanOrEqualTo(0).WithMessage("A meta mensal deve ser positiva");

            RuleFor(v => v.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro");
        }

        private bool HaveMinimumAge(DateTime dataNascimento)
        {
            int age = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
