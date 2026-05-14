using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvLib.DataObjects
{
    public class MateriaalMaat
    {
        public int Id { get; set; }
        public int MateriaalId { get; set; }
        public int MaatId { get; set; }
        public int Aantal { get; set; }
    }
}
