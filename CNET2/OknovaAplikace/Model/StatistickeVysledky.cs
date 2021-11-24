using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OknovaAplikace.Model
{
    /// <summary>
    /// Výsledky frekvenční analýzy
    /// </summary>
    internal class StatistickeVysledky
    {
        /// <summary>
        /// zdroj slov pro analýzu
        /// </summary>
        public string Zdroj { get; set; }
        /// <summary>
        /// 10 nejběžnějších slov v daném zdroji
        /// </summary>
        public Dictionary<string,int> Nejcastejsich10 { get; set; }
    }
}
