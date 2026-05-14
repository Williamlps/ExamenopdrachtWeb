using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvLib.DataObjects
{
    public class Uitlening
    {
        public int Id { get; set; }
        public DateTime DatumUitlening { get; set; }
        public DateTime DatumInlevering { get; set; }
        public int KlantId { get; set; }
    }
}
