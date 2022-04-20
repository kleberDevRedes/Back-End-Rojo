using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Rojo.Domains;
using Projeto_Rojo.Interfaces;
using Projeto_Rojo.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipamentoController : ControllerBase
    {
        private ITipoEquipamentoRepository TipoEquipamentoRepository { get; set; }

        public TipoEquipamentoController()
        {
            TipoEquipamentoRepository = new TipoEquipamentoRepository();
        }


        [HttpGet("lista")]
        public IActionResult Get()
        {
            try
            {
                return Ok(TipoEquipamentoRepository.Listar());
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
                return Ok(TipoEquipamentoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        [HttpPost]
        public IActionResult Post(TipoEquipamento novotipoEquipamento)
        {
            try
            {

                TipoEquipamentoRepository.Cadastrar(novotipoEquipamento);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPut("atualizar/{id}")]
        public IActionResult Put(int id, TipoEquipamento novo)
        {
            try
            {

                TipoEquipamentoRepository.Atualizar(id, novo);


                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoEquipamentoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
