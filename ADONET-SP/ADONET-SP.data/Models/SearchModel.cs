using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_SP.data.Models
{
    public class SearchModel
    {
        public int? Offset { get; set; }
        public int? Count { get; set; }
        public string SearchTerm { get; set; }
    }
}
