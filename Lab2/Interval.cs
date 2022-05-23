using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
namespace Lab2
{
    internal class Interval
    {
        private int leftedge, rightedge;

        public Interval(int leftedge, int rightedge)
        {
            this.leftedge = leftedge;
            this.rightedge = rightedge;
        }

        public int Leftedge
        {
            get { return leftedge; }
        }

        public int Rightedge
        {
            get { return rightedge; }
        }

        public int Length()
        {
            int length = rightedge - leftedge;
            return length;
        }

        public void Bias(int bias)
        {
            leftedge = leftedge + bias;
            rightedge = rightedge + bias;
            Console.WriteLine($"Нова лiва границя: {leftedge}. Нова права границя: {rightedge}");
        }

        public void ComprStretch(int coeff, int n)
        {
            if (n == 1)
            {
                leftedge = leftedge / coeff;
                rightedge = rightedge / coeff;

            }
            else if (n == 2)
            {
                leftedge = leftedge * coeff;
                rightedge = rightedge * coeff;
            }

            if (coeff >= 0)
            {
                Console.WriteLine($"Нова лiва границя: {leftedge}. Нова права границя: {rightedge}");
            }
            else if (coeff < 0)
            {
                int b = rightedge;
                int a = leftedge;

                rightedge = a;
                leftedge = b;

                Console.WriteLine($"Нова лiва границя: {leftedge}. Нова права границя: {rightedge}");
            }

        }

        public void Compare(int newleftedge, int newrightedge)
        {
            int c1 = newleftedge - leftedge;
            int c2 = newrightedge - rightedge;

            if (c1 < 0)
            {
                Console.Write($"Лiва границя бiльша на {Math.Abs(c1)}. ");
            }
            else if (c1 > 0)
            {
                Console.Write($"Лiва границя менша на {c1}. ");
            }
            else if (c1 == 0)
            {
                Console.Write("Лiвi границi однаковi. ");
            }

            if (c2 < 0)
            {
                Console.WriteLine($"Права границя бiльша на {Math.Abs(c2)}");
            }
            else if (c2 > 0)
            {
                Console.WriteLine($"Права границя менша на {c2}");
            }
            else if (c2 == 0)
            {
                Console.WriteLine("Правi границi однаковi");
            }
        }

        public void Sum(int newleft, int newright)
        {
            leftedge = leftedge + newleft;
            rightedge = rightedge + newright;
            Console.WriteLine($"Нова лiва границя: {leftedge}. Нова права границя {rightedge}");
        }

        public void Diff(int newleft, int newright)
        {
            leftedge = leftedge - newleft;
            rightedge = rightedge - newright;
            Console.WriteLine($"Нова лiва границя: {leftedge}. Нова права границя {rightedge}");
        }

        public void jsons(Interval ob)
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<Interval>(fs, ob);
                Console.WriteLine("Файл був створений");
            }
        }

        public void jsond()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Interval kk = JsonSerializer.Deserialize<Interval>(fs);
                Console.WriteLine("Права границя: " + kk.rightedge + ". Iнтервал вiдтворено");
            }
        }
    }
}
