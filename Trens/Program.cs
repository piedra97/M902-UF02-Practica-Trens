using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Trens
{

    class Program
    {
        /*Part1
        static SemaphoreSlim sem = new SemaphoreSlim(1);
        static void Main(string[] args)
        {            
            Thread TTren1 = new Thread(Tren1);
            Thread TTren2 = new Thread(Tren2);

            TTren1.Start();
            TTren2.Start();
            Console.ReadLine();
        }

        static void Tren1()
        {
            for (int i=0;i<=100; i++)
            {
                if (i == 20)
                {
                    sem.Wait();
                }

                if ((i>20) && (i<60))
                    Console.WriteLine("\t\tTren 1({0})",i);
                else if(i == 60)
                {
                    sem.Release();
                }
                else
                    Console.WriteLine("Tren 1({0})", i);

                Thread.Sleep(100);
            }
        }

        static void Tren2()
        {
            for (int i=100; i>=0; i--)
            {
                if (i == 60)
                {
                    sem.Wait();
                }
                if ((i > 20) && (i < 60))
                    Console.WriteLine("\t\tTren 2({0})", i);
                else if(i == 20)
                {
                    sem.Release();
                }
                else
                    Console.WriteLine("\t\t\t\tTren 2({0})", i);

                Thread.Sleep(110);
            }
        }
    }*/

        /*Part2

        private static Thread TTren1;
        private static Thread TTren2;
        private static Thread crashColission;
        private static int pos1 = 0, pos2 = 100;
        private static Boolean crash = false;

        static void Main(string[] args)
        {
            TTren1 = new Thread(tren1);
            TTren2 = new Thread(tren2);
            crashColission= new Thread(colision);

            crashColission.Start();
            TTren1.Start();
            TTren2.Start();

            Console.ReadLine();

        }
        static void colision()
        {
            while (!crash)
            {
                if ((pos1 >= 20 && pos1 <= 60) && (pos2 <= 60 && pos2 >= 20))
                {
                    Console.WriteLine("Els trens han parat per evitar una colisio");
                    TTren1.Abort();
                    TTren2.Abort();
                    crash = true;
                }
            }
        }
        static void tren1()
        {
            for (int i = 0; i <= 100; i++)
            {
                pos1++;
                if ((i >= 20) && (i <= 60))
                {
                    Console.WriteLine("\t\tTren 1({0}) ", i);
                }
                else
                {
                    Console.WriteLine("Tren 1({0}) ", i);
                }
                Thread.Sleep(100);
            }
        }
        static void tren2()
        {
            for (int i = 100; i >= 0; i--)
            {
                pos2--;
                if ((i >= 20) && (i <= 60))
                {
                    Console.WriteLine("\t\tTren 2({0}) ", i);
                }
                else
                {
                    Console.WriteLine("\t\t\t\tTren 2({0}) ", i);
                }

                Thread.Sleep(110);
            }
        }

    }
}*/

        /*Part 3*/

        static SemaphoreSlim sem = new SemaphoreSlim(1);

        public class Tren
        {
            public int tempsRetard { get; set; }
            public int kmInicial { get; set; }
            public int decrementacio { get; set; }
            public int kmEsperar { get; set; }
            public int kmSortir { get; set; }
            public int numeroTren { get; set; }



            public Tren(int temps, int inicial, int decre, int esperar, int sortir, int numero)
            {
                temps = tempsRetard;
                inicial = kmInicial;
                decre = decrementacio;
                numero = numeroTren;
            }
        }
        static Tren tren;
        static void Main(string[] args)
        {
            
            int i = 0;
            while (i >= 2)
            {
                if (i == 1)
                {
                    Tren tren = new Tren(110, 100, -1, 60, 20, 1);
                }
                else
                {
                    Tren tren = new Tren(100, 0, 1, 20, 60, 2);
                }

                Thread TTren = new Thread(trenEnMarxa);
                TTren.Start(tren);
                i++;
            }
            Console.ReadLine();
        }

        static void trenEnMarxa(object tren)
        {
            Tren myTren = (Tren)tren;

            for (int i = myTren.kmInicial; i <= 100; i = i + myTren.decrementacio)
            {
                if (i == myTren.kmEsperar)
                {
                    sem.Wait();
                }

                if ((i > myTren.kmEsperar) && (i < myTren.kmSortir))
                {
                    Console.WriteLine("\t\tTren "+ myTren.numeroTren +" ({0})", i);
                }
                else if (i == myTren.kmSortir)
                {
                    sem.Release();
                }
                else
                    Console.WriteLine("Tren " + myTren.numeroTren +" ({0})", i);

                Thread.Sleep(myTren.tempsRetard);
            }



        }
    }
}


