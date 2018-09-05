using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasledovanie_practic
{
    public class File
    {
        private string fileName;
        private double size;       

        public string FileName { get => fileName; set => fileName = value; }
        public double Size { get => size; set => size = value; }
 
        public File(File buf)
        {
            FileName = buf.FileName;
            size = buf.Size;
        }
        public File(string name,double size)
        {
            Size = size;
            FileName = name;
        }
        public File() { }
        public static File  operator-(File fq){
            return new File { FileName=fq.FileName,Size=fq.Size };
        }
        public static bool IsNumber(string numberAsString, ref int number)
        {
            try
            {
                number = int.Parse(numberAsString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void Show(ref int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (y == 1) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 1);
            Console.Write("добавить файл для переноса");
            if (y == 2) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 2);
            Console.Write(" расчет общего количества памяти всех устройств");
            if (y == 3) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 3);
            Console.Write(" копирование информации на устройства ");
            if (y == 4) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 4);
            Console.Write(" расчет времени необходимого для копирования");
            if (y == 5) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 5);
            Console.Write("расчет необходимого количества носителей информации ");
            if (y == 6) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 6);
            Console.Write("выбрать устройство");

            if (y == 7) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 7);
            Console.Write("выход");
        }
        public static double[] AddValueMas(double[]mas,int value,ref int sizeMasFile)
        {          
            double[] buf1 = new double[sizeMasFile];
            if (sizeMasFile > 0)
            {
                Array.Copy(mas, buf1, sizeMasFile);
            }
            sizeMasFile++;
            mas = new double[sizeMasFile];
            for (int i = 0; i < sizeMasFile - 1; i++)
                mas[i] = buf1[i];
            mas[sizeMasFile - 1] = value;
            return mas;
        }
    }
}
