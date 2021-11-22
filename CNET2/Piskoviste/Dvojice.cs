using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piskoviste
{
    class Dvojice
    {
        public string VelkaPismena { get; set; }
        public string MalaPismena { get; set; }

        public Dvojice(string malymipismeny, string velkymipismeny)
        {
            VelkaPismena = velkymipismeny;
            MalaPismena = malymipismeny;
        }
    }
}
