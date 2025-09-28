using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDeRendimiento.Modelo
{
    public class Abundamiento
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public double capacidad_colmada { get; set; }
        public double capacidad_ras { get; set; }
        public double espesor_carga_m { get; set; }
        public double espesor_descarga_m { get; set; }
        public double ancho_m { get; set; }
    }

}
