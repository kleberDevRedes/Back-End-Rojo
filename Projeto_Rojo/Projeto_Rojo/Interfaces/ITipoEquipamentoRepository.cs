using Projeto_Rojo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Interfaces
{
    interface ITipoEquipamentoRepository
    {
        IEnumerable<TipoEquipamento> Listar();

        TipoEquipamento BuscarPorId(int id);

        TipoEquipamento Cadastrar(TipoEquipamento e);

        void Atualizar(int id, TipoEquipamento novo);

        void Deletar(int id);
    }
}
