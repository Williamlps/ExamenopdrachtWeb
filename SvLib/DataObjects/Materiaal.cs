using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvLib.DataObjects
{
    public class Materiaal
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MerkId { get; set; }
        public int TypeMateriaalId { get; set; }
        public string Foto { get; set; }
    }
}
