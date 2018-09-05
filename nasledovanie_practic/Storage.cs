using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie_practic
{
    public  class Storage
    {
        protected File [] _file;
        protected int _count=0; // служебный член
        public double Speed { get; set; }
        public double SpeedWrite { get; set; }
        public double SpeedRead { get; set; }
        public double MemoryDouble { get; set; }
        public double MemoryOne { get; set; }

        public Storage() {
            TakenSeat = 0;
            _count = 0;
            EmptySeat = 0;
            Memory = 0;
        }

        //наименование носителя
        public  string NameStorage { get; set; }

        //свободная память
        public double EmptySeat { get; set; }
        // 
        // //общая память
        public double Memory { get; set; }
        //
        // //занятое место
        public double TakenSeat { get; set; }

        public  string Model { get; set; }

        //скорость записи
        //public double Speed { get; set; }

        public virtual void Transfer(File file)
        {
           // TakenSeat += file.Size;
            //EmptySeat -= TakenSeat;
            if (_count > 0)
            {
                File[] buf = new File[_count];
                for(int i = 0; i < _file.Length; i++)
                {
                    buf[i] = new File();
                    buf[i] = -_file[i];                   
                }
                _file = new File[_count + 1];
                int ii = 0;
                for (; ii < _file.Length-1; ii++)
                {
                    _file[ii] = new File();
                    _file[ii] = -buf[ii];                    
                }
                _count++;
                _file[ii] = -file;
            }
            else
            {
                _count = 1;
                _file = new File[_count];
                for(int i = 0; i < _file.Length; i++)
                {
                    _file[i] = new File();
                    _file[i] =- file; //                                    
                   // Console.WriteLine("qwe: " + _file[i].FileName + _file[i].Size);
                }
            }
        }
        public  File[]  GetFile() { return _file; }
    }
}
