using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvLib.DataObjects
{
    public class UitleningMateriaal
    {
        public int Id { get; set; }
        public int UitleningId { get; set; }
        public int MateriaalMaatId { get; set; }
        public int Aantal { get; set; }
    }
}
