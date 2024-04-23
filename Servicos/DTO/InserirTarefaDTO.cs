using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirTarefaDTO
    { 
        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public int IdCategoria { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DtValidade { get; set; }

    }
}
