using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Rojo.Domains
{
    public partial class Equipamento
    {
        public Equipamento()
        {
            Alerta = new HashSet<Alertum>();
            Alteracaos = new HashSet<Alteracao>();
            ImgEquipamentos = new HashSet<ImgEquipamento>();
        }

        public int IdEquipamento { get; set; }
        public int? IdUsuario { get; set; }
        public int IdTipoEquipamento { get; set; }
        public int? NumeroDeSerie { get; set; }
        public string Modelo { get; set; }
        public int? GateWay { get; set; }
        public int? Mask { get; set; }
        public int? Dns { get; set; }
        public int? Porta { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Descricao { get; set; }

        public virtual TipoEquipamento IdTipoEquipamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Alertum> Alerta { get; set; }
        public virtual ICollection<Alteracao> Alteracaos { get; set; }
        public virtual ICollection<ImgEquipamento> ImgEquipamentos { get; set; }
    }
}
