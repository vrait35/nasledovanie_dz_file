using System;

namespace nasledovanie_practic
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = false;
            bool isAddFile = false;
            int selectStorage = -1;
            int sizeFile = 0;
            int legthFile = 0;
            File[] file=null;
            ConsoleKeyInfo key;
            int y = 1;
            Storage st = new Storage();
            double[] masSizeFile=null;
            int sizeMasFile = 0;
            while (true)
            {
                File.Show(ref y);
                 key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow) { if (y < 7) y++; }
                else if (key.Key == ConsoleKey.UpArrow) { if (y > 1) y--; }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (y == 1)//if add file
                    {
                        Console.Clear();
                        Console.Write("введите имя файла: ");
                        string fileName = Console.ReadLine();
                        while (!isTrue)
                        {
                            Console.WriteLine("введите размер файла: ");
                            isTrue = File.IsNumber(Console.ReadLine(), ref sizeFile);
                        }

                        masSizeFile = File.AddValueMas(masSizeFile, sizeFile, ref sizeMasFile);

                        isTrue = false;
                        if (legthFile > 0)
                        {
                            File[] buf = new File[legthFile];
                            for (int i = 0; i < legthFile; i++)
                            {
                                buf[i] = new File();
                                buf[i] = -file[i];
                            }
                            legthFile++;
                            file = new File[legthFile];
                            for (int i = 0; i < legthFile; i++)
                                file[i] = new File();
                            for (int i = 0; i < legthFile - 1; i++)
                            {
                                file[i] = -buf[i];
                            }
                            file[legthFile - 1].FileName = fileName;
                            file[legthFile - 1].Size = sizeFile;
                        }
                        else if (legthFile == 0)
                        {
                            legthFile++;
                            file = new File[legthFile];
                            for (int i = 0; i < legthFile; i++)
                            {
                                file[i] = new File(fileName, sizeFile);
                            }
                        }
                        Console.Clear();
                        isAddFile = true;
                    }//if add file
                    else if (y == 3)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (selectStorage < 0)
                        {
                            Console.WriteLine("выберите устройство!"); continue;
                        }
                        if (!isAddFile)
                        {
                            Console.WriteLine("добавьте файлы "); continue;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        for (int i = 0; i < legthFile; i++)
                            st.Transfer(file[i]);

                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("*********содержимое накопителя:");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        foreach (File mas in st.GetFile())
                        {
                            Console.WriteLine("Имя файла: {0} " +
                                " Рaзмер файла: {1}", mas.FileName, mas.Size);
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }// копирование на флеш устройство
                    else if (y == 2)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (selectStorage < 0)
                        {
                            Console.WriteLine("выберите тип устройства : ");
                            continue;
                        }
                        else
                        {
                            if (st is Flash || st is HDD)
                            {
                                Console.WriteLine("общая память {0} FLASH или HDD", st.Memory);
                            }
                            else if (st is DVD)
                            {
                                    Console.WriteLine("общая память {0} DVD С 1 стороной ", st.MemoryOne);                                
                                Console.WriteLine("общая память {0} DVD С 2 стороной ", st.MemoryDouble);
                            }
                        }
                    }
                    else if (y == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(0, 10);
                        Console.Clear();
                        while (!isTrue)
                        {
                            Console.Write("введите номер накопителя: 1-Flash, 2-DVD, 3-HDD : ");
                            isTrue = File.IsNumber(Console.ReadLine(), ref selectStorage);
                        }
                        isTrue = false;
                        if (selectStorage == 1) st = new Flash();
                        else if (selectStorage == 2) st = new DVD();
                        else if (selectStorage == 3) st = new HDD();
                        else Console.WriteLine("нету такого типа!");
                        Console.Clear();
                    }
                    else if (y == 7) Environment.Exit(0);
                    else if (y == 4)
                    {
                        if (!isAddFile || selectStorage < 0)
                        {
                            Console.SetCursorPosition(0, 10);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("выберите тип устройства! и добавьте файлы! ");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        double sum = 0;
                        foreach (double a in masSizeFile)
                            sum += a;
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (st is Flash)
                        {
                            double time = sum / (double)st.Speed;
                            Console.Write("время  копирования : " + time);
                        }
                        else if (st is DVD)
                        {
                            double time = sum / (double)st.SpeedWrite;
                            Console.Write("время  копирования : " + time);
                        }
                        else if (st is HDD)
                        {
                            double time = sum / (double)st.Speed;
                            Console.Write("время  копирования : " + time);
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }


                    else if (y == 5)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (!isAddFile || selectStorage < 0)
                        {
                            Console.WriteLine("выберите тип устройства и добавьте файлы: ");
                            continue;
                        }
                        else
                        {
                            double sum = 0;
                            foreach (double a in masSizeFile)
                                sum += a;
                            if (st is Flash || st is HDD)
                            {
                                double countStorange = (double)sum / st.Memory;
                                if (countStorange - (int)countStorange != 0)
                                    Console.WriteLine("нужно {0} FLASH или HDD ", (int)countStorange + 1);
                                else Console.WriteLine("нужно {0} FLASH или HDD ", (int)countStorange);
                            }
                            else if (st is DVD)
                            {
                                double countStorange = (double)sum / st.Memory;
                                if (countStorange - (int)countStorange != 0)
                                    Console.WriteLine("нужно {0} DVD С 1 стороной ", (int)countStorange + 1);
                                else Console.WriteLine("нужно {0} DVD С 1 стороной", (int)countStorange);

                                countStorange = (double)sum / st.Memory;
                                if (countStorange - (int)countStorange != 0)
                                    Console.WriteLine("нужно {0} DVD С 2 стороной ", (int)countStorange + 1);
                                else Console.WriteLine("нужно {0} DVD С 2 стороной", (int)countStorange);
                            }
                        }
                    }

                }
            }        
        }      
    }
}
