using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication16
{
    class Program
    {
        static void Main()
        {
            bool q = true;
            double distance = 0;
            double spcord = 1, flycord = 1;
            string[] coor = Console.ReadLine().Split(' ');

            string[] sp = Console.ReadLine().Split(' ');

            string[] fly = Console.ReadLine().Split(' ');


            for (int i = 0; i < 3; i++)
            {
                if (sp[i] == fly[i] && (sp[i] == coor[i] || sp[i] == "0"))
                {
                    distance = Math.Sqrt(Math.Pow(Math.Abs(Convert.ToDouble(sp[(i + 1) % 3]) - Convert.ToDouble(fly[(i + 1) % 3])), 2) + Math.Pow(Math.Abs(Convert.ToDouble(sp[(i + 2) % 3]) - Convert.ToDouble(fly[(i + 2) % 3])), 2));
                    q = false;
                    break;
                }

                if ((sp[i] == "0" && fly[i] == coor[i]) || (fly[i] == "0" && sp[i] == coor[i]))
                {
                    double distance1 = Math.Sqrt(Math.Pow(Convert.ToDouble(sp[(i + 2) % 3]) - Convert.ToDouble(fly[(i + 2) % 3]), 2) + Math.Pow(2 * Convert.ToDouble(coor[(i + 1) % 3]) + Convert.ToDouble(coor[i]) - Convert.ToDouble(fly[(i + 1)%3]) - Convert.ToDouble(sp[(i+1)%3]), 2));
                    double distance2 = Math.Sqrt(Math.Pow(Convert.ToDouble(sp[(i + 1) % 3]) - Convert.ToDouble(fly[(i + 1) % 3]), 2) + Math.Pow(2 * Convert.ToDouble(coor[(i + 2) % 3]) + Convert.ToDouble(coor[i]) - Convert.ToDouble(fly[(i + 2)%3]) - Convert.ToDouble(sp[(i + 2) % 3]), 2));
                    double distance3 = Math.Sqrt(Math.Pow(Convert.ToDouble(sp[(i + 2) % 3]) - Convert.ToDouble(fly[(i + 2) % 3]), 2) + Math.Pow( Convert.ToDouble(coor[i]) + Convert.ToDouble(fly[(i + 1)%3]) + Convert.ToDouble(sp[(i + 1) % 3]), 2));
                    double distance4 = Math.Sqrt(Math.Pow(Convert.ToDouble(sp[(i + 1) % 3]) - Convert.ToDouble(fly[(i + 1) % 3]), 2) + Math.Pow(Convert.ToDouble(coor[i]) + Convert.ToDouble(fly[(i + 1) % 3]) + Convert.ToDouble(sp[(i + 2) % 3]), 2));
                    distance3 = Math.Min(distance3, distance4);
                    distance1 = Math.Min(distance1, distance2);
                    distance = Math.Min(distance1, distance3);
                    q = false;
                    break;
                }


            }
            if (q)
            {
                for(int i = 0; i < 3; i++)
                {
                    if ((sp[i] == coor[i] || sp[i] == "0")&&(q))
                    {
                        if (sp[i] == coor[i])
                            spcord = -1;

                        for(int j = 0;j<3; j++)
                        {
                            if (fly[j] == coor[j] || fly[j] == "0")
                            {
                                if (fly[j] == coor[j])
                                    flycord = -1;
                                if (spcord == -1)
                                {
                                    spcord = Convert.ToDouble(coor[i]) - Convert.ToDouble(fly[i]);

                                }
                                else
                                {
                                    spcord = Convert.ToDouble(fly[i]);
                                }
                                if (flycord == -1)
                                {
                                    flycord = Convert.ToDouble(coor[j]) - Convert.ToDouble(sp[j]);
                                }
                                else
                                    flycord = Convert.ToDouble(sp[j]);
                                double deltoz = Convert.ToDouble(sp[(2 * (i + j)) % 3])- Convert.ToDouble(fly[(2 * (i + j)) % 3]);
                                distance = Math.Sqrt(Math.Pow(flycord+spcord,2)+Math.Pow(deltoz,2));
                                q = false;
                                break;
                            }
                        }
                    }
                }
            }











            Console.WriteLine(distance);
        }
    }
}

