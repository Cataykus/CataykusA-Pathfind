using System;

namespace ConsoleAppPathfinding
{
    class Program
    {
        static int[,] r = {
                { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 },
                { 255, 253, 254, 254, 254, 254, 254, 254, 254, 254, 254, 255, 0, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 255, 254, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 255, 254, 254, 254, 254, 254, 254, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 255, 254, 254, 254, 254, 254, 254, 254, 254, 255 },
                { 255, 254, 254, 254, 254, 254, 255, 254, 254, 254, 254, 254, 254, 254, 255, 255 },
                { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 },
            };
        static int[,] map = new int[r.GetLength(0), r.GetLength(1)];
        static int x, y;
        static int x1, y1;
        static int ni;
        static int nk = r.GetLength(0) * r.GetLength(1);
        static void Main(string[] args)
        {
            for (ni = 0; ni < nk; ni++)
            {
                for (int i = 0; i < r.GetLength(0); i++)
                {
                    for (int j = 0; j < r.GetLength(1); j++)
                    {
                        if (r[i, j] == 253)
                        {
                            x = i;
                            y = j;
                        }
                        if (r[i, j] == ni)
                        {
                            if (r[i + 1, j] == 253)
                            {
                                BuildPath();
                            }
                            else if (r[i + 1, j] == 254)
                            {
                                r[i + 1, j] = ni + 1;
                            }

                            if (r[i - 1, j] == 253)
                            {
                                BuildPath();
                            }
                            else if (r[i - 1, j] == 254)
                            {
                                r[i - 1, j] = ni + 1;
                            }

                            if (r[i, j + 1] == 253)
                            {
                                BuildPath();
                            }
                            else if (r[i, j + 1] == 254)
                            {
                                r[i, j + 1] = ni + 1;
                            }

                            if (r[i, j - 1] == 253)
                            {
                                BuildPath();
                            }
                            else if (r[i, j - 1] == 254)
                            {
                                r[i, j - 1] = ni + 1;
                            }
                        };
                    }
                }
            }

            for (int i = 0; i < r.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < r.GetLength(1); j++)
                {
                    Console.Write(r[i, j]);
                }
            }

            Console.Read();
        }
        public static void BuildPath()
        {
            while (true)
            {
                int min = 255;

                if (min > r[x + 1, y])
                {
                    min = r[x + 1, y];
                    x1 = x + 1;
                    y1 = y;
                }

                if (min > r[x - 1, y])
                {
                    min = r[x - 1, y];
                    x1 = x - 1;
                    y1 = y;
                }

                if (min > r[x, y + 1])
                {
                    min = r[x, y + 1];
                    x1 = x;
                    y1 = y + 1;
                }

                if (min > r[x, y - 1])
                {
                    min = r[x, y - 1];
                    x1 = x;
                    y1 = y - 1;
                }


                x = x1;
                y = y1;

                if (r[x1, y1] == 0)
                {
                    DrawPath();
                    Console.WriteLine("Маршрут найден");
                    break;
                }
                else
                {
                    //[x1, y1] = 256;
                }
            }
        }
        static void DrawPath()
        {
            for (int i = 0; i < r.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < r.GetLength(1); j++)
                {
                    if (r[i, j] == 255) Console.Write(" # ");
                    else if (r[i, j] == 256) Console.Write(" + ");
                    else if (r[i, j] == 253) Console.Write(" S ");
                    else if (r[i, j] == 0) Console.Write(" F ");
                    else Console.Write(r[i, j] + " ");
                }
            }
        }
    }
}
