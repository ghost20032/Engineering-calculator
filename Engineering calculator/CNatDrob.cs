using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engineering_calculator
{
    internal class CNatDrob
    {
        private int Numerator;
        private int Denominator;

        public CNatDrob()
        {
            Numerator = 0;
            Denominator = 0;
        }
        public static CNatDrob Sokrdr(CNatDrob cNatDrob1)
        {
            int max = Math.Max(Math.Abs(cNatDrob1.Denominator), Math.Abs(cNatDrob1.Numerator));
            //поиск НОД числителя и знаменателя 
            for (int i = max; i >= 2; i--)
            {
                //поиск максимального числа, на которое числитель и на знаменатель
                //делятся без остатка
                if ((cNatDrob1.Numerator % i == 0) & (cNatDrob1.Denominator % i == 0))
                {
                    cNatDrob1.Numerator = cNatDrob1.Numerator / i;
                    cNatDrob1.Denominator = cNatDrob1.Denominator / i;
                }
            }
            //Определяемся со знаком, если знаменатель отрицательный, 
            //переносим минус наверх, в числитель
            if ((cNatDrob1.Denominator < 0))
            {
                cNatDrob1.Numerator = -1 * (cNatDrob1.Numerator);
                cNatDrob1.Denominator = -1 * (cNatDrob1.Denominator);
            }
            return (cNatDrob1);
        }
        public double getFrac()
        {
            double x1 = Numerator;
            return x1 / Denominator;
        }
        public CNatDrob(string dr)
        {
            string[] sum = dr.Split('/', ' ');
            Numerator = Convert.ToInt32(sum[0]);
            Denominator = Convert.ToInt32(sum[1]);
        }
        public static string sum = "";
        public static string subtraction = "";
        public static string multiplication = "";
        public static string division = "";
        public static CNatDrob operator +(CNatDrob cNatDrob1, CNatDrob CNatdrob2)
        {
            Console.WriteLine("Сложение");
            CNatDrob rs = new CNatDrob();
            rs.Numerator = (cNatDrob1.Numerator * CNatdrob2.Denominator) + (CNatdrob2.Numerator * cNatDrob1.Denominator);
            rs.Denominator = cNatDrob1.Denominator * CNatdrob2.Denominator;
            CNatDrob.Sokrdr(rs);
            sum = rs.Numerator + "/" + rs.Denominator;
            return rs;
        }
        
        public static CNatDrob operator -(CNatDrob cNatDrob1, CNatDrob CNatdrob2)
        {
            Console.WriteLine("Вычитание");
            CNatDrob rs = new CNatDrob();
            rs.Numerator = (cNatDrob1.Numerator * CNatdrob2.Denominator) - (CNatdrob2.Numerator * cNatDrob1.Denominator);
            rs.Denominator = cNatDrob1.Denominator * CNatdrob2.Denominator;
            CNatDrob.Sokrdr(rs);
            subtraction=rs.Numerator + "/" + rs.Denominator;
            return rs;
        }
        public static CNatDrob operator *(CNatDrob cNatDrob1, CNatDrob CNatdrob2)
        {
            Console.WriteLine("Умножение");
            CNatDrob rs = new CNatDrob();
            rs.Numerator = cNatDrob1.Numerator * CNatdrob2.Numerator;
            rs.Denominator = cNatDrob1.Denominator * CNatdrob2.Denominator;
            CNatDrob.Sokrdr(rs);
            multiplication=rs.Numerator + "/" + rs.Denominator;
            return rs;
        }
        public static CNatDrob operator /(CNatDrob cNatDrob1, CNatDrob CNatdrob2)
        {
            Console.WriteLine("Деление");
            CNatDrob rs = new CNatDrob();
            rs.Numerator = cNatDrob1.Numerator * CNatdrob2.Denominator;
            rs.Denominator = cNatDrob1.Denominator * CNatdrob2.Numerator;
            CNatDrob.Sokrdr(rs);
            division=rs.Numerator + "/" + rs.Denominator;
            return rs;
        }
        public static bool operator >(CNatDrob cNatDrob1, CNatDrob CNatdrob2)
        {
            if (cNatDrob1.getFrac() > CNatdrob2.getFrac())
                return true;
            else
                return false;
        }
        public static bool operator <(CNatDrob cNatDrob1, CNatDrob CNatdrob2)
        {
            if (cNatDrob1.getFrac() < CNatdrob2.getFrac())
                return true;
            else
                return false;
        }
    }
}

