using Microsoft.AspNetCore.Authorization;
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

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EquipamentoController : ControllerBase
    {

        private IEquipamentoRepository equipamentoRepository { get; set; }


        public EquipamentoController()
        {
            equipamentoRepository = new EquipamentoRepository();
        }


               // [HttpGet("lista-meus-equipamentos")]
                //public IActionResult Get()
                //{
                //    try
                //    {
                //        int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
//
  //                      return Ok(equipamentoRepository.Listar(idUsuario));
    //                }
      //              catch (Exception erro)
        //            {
          //          return BadRequest(
           //             new
              //          {
                //            mensagem = " obrigatório id do usuario!",
                  //          erro = erro
                  //
                      //  }
                    //    );
                    //} 
                //}

                [HttpGet("lista-equipamentos")]
                public IActionResult Get()
                {
                    try
                    {
                        int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                        return Ok(equipamentoRepository.Listar(idUsuario));
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(
                        new
                        {
                            mensagem = " obrigatório id do usuario!",
                            erro = erro

                        }
                        );
                    } 
                }


                [HttpGet("equipamento/{id}")]
                public IActionResult GetById(int id)
                {
                    try
                    {
                        return Ok(equipamentoRepository.BuscarPorId(id));
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro);
                    }
                }


                [HttpPost]
                public IActionResult Post(Equipamento novoEvento)
                {
                    try
                    {
                        equipamentoRepository.Cadastrar(novoEvento);

                        return StatusCode(201);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }


                [HttpPut("atualizar/{id}")]
                public IActionResult Put(int id, Equipamento eventoAtualizado)
                {
                    try
                    {
                        equipamentoRepository.Atualizar(id,eventoAtualizado);

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
                        equipamentoRepository.Deletar(id);

                        return StatusCode(204);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }
            }
}
    
