using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollUp
{
    public class RollUpResult
    {

        public List<Products> Selected { get; set; }
        public List<Products> Discarded { get; set; }

        public RollUpResult()
        {
            Selected = new List<Products>();
            Discarded = new List<Products>();
        }

    }
}