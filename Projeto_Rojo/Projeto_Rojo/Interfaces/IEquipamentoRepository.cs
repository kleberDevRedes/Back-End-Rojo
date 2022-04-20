using Microsoft.AspNetCore.Http;
using Projeto_Rojo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Interfaces
{
    interface IEquipamentoRepository
    {
        void SalvarPerfilBD(IFormFile foto, int id_e);
        void SalvarPerfilDir(IFormFile foto, int id_e);
        string ConsultarPerfilBD(int id_e);
        string ConsultarPerfilDir(int id_e);


        IEnumerable<Equipamento> Listar(int idUsuario);

        Equipamento BuscarPorId(int idEquipamento);

        Equipamento Cadastrar(Equipamento e);

        void Atualizar(int id, Equipamento e);

        void Deletar(int id);
    }
}
