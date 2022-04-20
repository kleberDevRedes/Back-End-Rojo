using Projeto_Rojo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Interfaces
{
    interface ITipoUsuarioRepository
    {
        IEnumerable<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(int id);

        TipoUsuario Cadastrar(TipoUsuario e);

        void Atualizar(int id, TipoUsuario e);

        void Deletar(int id);
    }
}
