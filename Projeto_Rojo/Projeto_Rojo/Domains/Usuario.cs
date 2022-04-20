using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Rojo.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Equipamentos = new HashSet<Equipamento>();
        }

        public int IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Contato { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string RazaoSocial { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ImgUsuario ImgUsuario { get; set; }
        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
