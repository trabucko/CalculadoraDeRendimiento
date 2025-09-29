using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDeRendimiento.Modelo
{
    public class HojaBulldozer
    {
        public string modelo { get; set; } // <-- Propiedad añadida
        public double longitud_m { get; set; }
        public double alto_m { get; set; }
        public string tipo_hoja { get; set; }
    }

}
