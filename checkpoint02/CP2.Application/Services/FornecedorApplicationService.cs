using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;
using System;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            var fornecedor = _repository.ObterPorId(id);

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado");

            return _repository.DeletarDados(id);
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            var fornecedor = _repository.ObterPorId(id);

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado");

            return fornecedor;
        }

        public FornecedorEntity CriarFornecedor(IFornecedorDto fornecedorDto)
        {
            fornecedorDto.Validate();

            var fornecedor = new FornecedorEntity
            {
                Nome = fornecedorDto.Nome,
                CNPJ = fornecedorDto.CNPJ,
                Endereco = fornecedorDto.Endereco,
                Telefone = fornecedorDto.Telefone,
                Email = fornecedorDto.Email,
                CriadoEm = DateTime.Now
            };

            return _repository.Inserir(fornecedor);
        }

        public FornecedorEntity AtualizarFornecedor(int id, IFornecedorDto fornecedorDto)
        {
            fornecedorDto.Validate();

            var fornecedorExistente = _repository.ObterPorId(id);

            if (fornecedorExistente == null)
                throw new Exception("Fornecedor não encontrado");

            fornecedorExistente.Nome = fornecedorDto.Nome;
            fornecedorExistente.CNPJ = fornecedorDto.CNPJ;
            fornecedorExistente.Endereco = fornecedorDto.Endereco;
            fornecedorExistente.Telefone = fornecedorDto.Telefone;
            fornecedorExistente.Email = fornecedorDto.Email;

            return _repository.Atualizar(fornecedorExistente);
        }
    }
}
