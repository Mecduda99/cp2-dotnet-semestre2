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
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Método para obter todos os dados dos Vendedores
        /// </summary>
        /// <returns>Lista de Vendedores</returns>
        [HttpGet]
        [Produces(typeof(IEnumerable<VendedorEntity>))]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel is not null && objModel.Any())
                return Ok(objModel);

            return NotFound("Nenhum vendedor encontrado");
        }

        /// <summary>
        /// Método para obter um Vendedor por ID
        /// </summary>
        /// <param name="id">Identificador do vendedor</param>
        /// <returns>Vendedor específico</returns>
        [HttpGet("{id}")]
        [Produces(typeof(VendedorEntity))]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return NotFound("Vendedor não encontrado");
        }

        /// <summary>
        /// Método para criar um novo Vendedor
        /// </summary>
        /// <param name="entity">Dados do vendedor</param>
        /// <returns>Vendedor criado</returns>
        [HttpPost]
        [Produces(typeof(VendedorEntity))]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                entity.Validate(); // Valida o DTO

                var objModel = _applicationService.SalvarDadosVendedor(entity);

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
        /// Método para atualizar um Vendedor existente
        /// </summary>
        /// <param name="id">Identificador do vendedor</param>
        /// <param name="entity">Dados atualizados do vendedor</param>
        /// <returns>Vendedor atualizado</returns>
        [HttpPut("{id}")]
        [Produces(typeof(VendedorEntity))]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                entity.Validate(); // Valida o DTO

                var objModel = _applicationService.EditarDadosVendedor(id, entity);

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
        /// Método para deletar um Vendedor
        /// </summary>
        /// <param name="id">Identificador do vendedor</param>
        /// <returns>Vendedor deletado</returns>
        [HttpDelete("{id}")]
        [Produces(typeof(VendedorEntity))]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return NotFound("Vendedor não encontrado para deletar");
        }
    }
}
