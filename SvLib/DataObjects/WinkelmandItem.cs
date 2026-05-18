using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvLib.DataObjects
{
    public class WinkelmandItem
    {
        public int MateriaalMaatId { get; set; }
        public string MerkNaam { get; set; }
        public string MateriaalModel { get; set; }
        public string MaatNaam { get; set; }
        public int Aantal { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
