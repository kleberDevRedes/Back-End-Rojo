using Microsoft.AspNetCore.Mvc;
using Projeto_Rojo.Domains;
using Projeto_Rojo.Interfaces;
using Projeto_Rojo.Repositories;
using System;

namespace Projeto_Rojo.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class AlteracaoController : ControllerBase
    {
        private IAlteracaoRepository alteracaoRepository { get; set; }

        public AlteracaoController()
        {
            alteracaoRepository = new AlteracaoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(alteracaoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(alteracaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        [HttpPost]
        public IActionResult Post(Alteracao novoEvento)
        {
            try
            {

                alteracaoRepository.Cadastrar(novoEvento);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPut("atualizar/{id}")]
        public IActionResult Put(int id, Alteracao eventoAtualizado)
        {
            try
            {

                alteracaoRepository.Atualizar(id,eventoAtualizado);


                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpDelete("deletar")]
        public IActionResult Delete(int id)
        {
            try
            {
                alteracaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
