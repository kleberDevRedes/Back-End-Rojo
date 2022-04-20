using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    public class ImgEquipamentoController : ControllerBase
    {
        private IEquipamentoRepository _equipamentoRepository { get; set; }

        public ImgEquipamentoController()
        {
            _equipamentoRepository = new EquipamentoRepository();
        }

        [HttpPost("imagem/bd")]
        public IActionResult postBD(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 5000000)
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                string extensao = arquivo.FileName.Split('.').Last();

                //if(extensao != "png")
                //    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos." });


                int idEquipamento = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _equipamentoRepository.SalvarPerfilBD(arquivo, idEquipamento);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }

        [HttpGet("imagem/bd")]
        public IActionResult getbd()
        {
            try
            {

                int idEquipamento = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _equipamentoRepository.ConsultarPerfilBD(idEquipamento);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("imagem/dir")]
        public IActionResult postDIR(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 5000) 
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png")
                    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos." });


                int idEquipamento = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _equipamentoRepository.SalvarPerfilDir(arquivo, idEquipamento);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("imagem/dir")]
        public IActionResult getDIR()
        {
            try
            {

                int idEquipamento = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _equipamentoRepository.ConsultarPerfilDir(idEquipamento);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
