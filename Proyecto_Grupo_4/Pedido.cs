using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Grupo_4
{
    internal class Pedido
    {
        public int codigo { get; set; }
        public string cliente { get; set; }
        public string plato { get; set; }
        public string bebida { get; set; }
        public string hora { get; set; }
        public DateTime horaPreparado {  get; set; } 
        public DateTime horaPedido { get; set; }

    }
}
