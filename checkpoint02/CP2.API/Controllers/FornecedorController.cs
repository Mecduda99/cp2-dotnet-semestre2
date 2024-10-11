using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Método para obter todos os dados dos Fornecedores
        /// </summary>
        /// <returns>Lista de Fornecedores</returns>
        [HttpGet]
        [Produces(typeof(IEnumerable<FornecedorEntity>))]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel is not null)
                return Ok(objModel);

            return NotFound("Nenhum fornecedor encontrado");
        }

        /// <summary>
        /// Método para obter um Fornecedor por ID
        /// </summary>
        /// <param name="id">Identificador do fornecedor</param>
        /// <returns>Fornecedor específico</returns>
        [HttpGet("{id}")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return NotFound("Fornecedor não encontrado");
        }

        /// <summary>
        /// Método para criar um novo Fornecedor
        /// </summary>
        /// <param name="entity">Dados do fornecedor</param>
        /// <returns>Fornecedor criado</returns>
        [HttpPost]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                entity.Validate(); // Valida o DTO

                var objModel = _applicationService.SalvarDadosFornecedor(entity);

                if (objModel is not null)
                    return CreatedAtAction(nameof(GetPorId), new { id = objModel.Id }, objModel); // Retorna 201 Created

                return BadRequest("Não foi possível salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para atualizar um Fornecedor existente
        /// </summary>
        /// <param name="id">Identificador do fornecedor</param>
        /// <param name="entity">Dados atualizados do fornecedor</param>
        /// <returns>Fornecedor atualizado</returns>
        [HttpPut("{id}")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                entity.Validate(); // Valida o DTO

                var objModel = _applicationService.EditarDadosFornecedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível atualizar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para deletar um Fornecedor
        /// </summary>
        /// <param name="id">Identificador do fornecedor</param>
        /// <returns>Fornecedor deletado</returns>
        [HttpDelete("{id}")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return NotFound("Fornecedor não encontrado para deletar");
        }
    }
}
