using Projeto_Rojo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Interfaces
{
    interface IAlteracaoRepository
    {
        IEnumerable<Alteracao> Listar();

        Alteracao BuscarPorId(int id);

        Alteracao Cadastrar(Alteracao e);

        void Atualizar(int id, Alteracao e);

        void Deletar(int id);
    }
}
