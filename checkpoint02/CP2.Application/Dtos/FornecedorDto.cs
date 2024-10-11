using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório")
                .Length(14).WithMessage("O CNPJ deve ter 14 caracteres");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório")
                .MinimumLength(10).WithMessage("O telefone deve ter no mínimo 10 caracteres");

            RuleFor(f => f.Endereco)
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres");

            RuleFor(f => f.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro");
        }
    }
}
