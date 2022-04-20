using Microsoft.AspNetCore.Http;
using Projeto_Rojo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void SalvarPerfilBD(IFormFile foto, int id_usuario);
        void SalvarPerfilDir(IFormFile foto, int id_usuario);
        string ConsultarPerfilBD(int id_usuario);
        string ConsultarPerfilDir(int id_usuario);

        IEnumerable<Usuario> Listar();

        Usuario BuscarPorId(int id);

        Usuario Cadastrar(Usuario u);

        void Atualizar(int id, Usuario u);

        void Deletar(int id);
    }
}
