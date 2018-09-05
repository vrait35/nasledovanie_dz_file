using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie_practic
{
    public class DVD:Storage
    {
       
        public DVD():base()
        {
            SpeedWrite = 4000;
            SpeedRead = 4500;
            MemoryOne = 4700;
            MemoryDouble =0;
            Memory = MemoryOne;
            TakenSeat = 0;
            EmptySeat = Memory;
        }
        public DVD(int buf):this()
        {
            MemoryOne = 0;
            MemoryDouble = 9000;
            Memory = MemoryDouble;
            EmptySeat = Memory;
        }      
    }
}
