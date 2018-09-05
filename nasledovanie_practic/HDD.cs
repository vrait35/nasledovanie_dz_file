using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie_practic
{
    public class HDD:Storage
    {
        //public double Speed { get; set; }
        public int CountSection { get; set; }
        public double SizeSection { get; set; }

        public HDD() : base()
        {
            Speed = 450;
            CountSection = 1;
            SizeSection = 1000;
            Memory = SizeSection;            
        }
        public HDD(int count,double size) : this()
        {
            Speed = 450;
            CountSection = count;
            SizeSection = size;
            Memory = SizeSection * CountSection;
        }
       
    }
}
