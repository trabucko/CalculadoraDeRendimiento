using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDeRendimiento.Modelo
{
    public class Material
    {
        public int id { get; set; }
        public string suelo { get; set; }
        public double abundamiento_a { get; set; }
        public double abundamiento_b { get; set; }
        public double enjuntamiento_a { get; set; }
        public double enjuntamiento_b { get; set; }
    }
}
