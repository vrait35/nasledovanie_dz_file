using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie_practic
{
    public class Flash:Storage
    {
        
        public Flash() : base()
        {
            Memory = 4000;
            Speed = 5000;            
        } 
    }
}
