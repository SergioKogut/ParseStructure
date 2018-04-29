using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Разработать собственный структурный тип данных
для хранения целочисленных коэффициентов A и B
линейного уравнения A×X + B×Y = 0 в классе реализовать статический метод Parse(), которые принимает
строку со значениями коэффициентов, разделенных
запятой или пробелом
 */


namespace StructureType
{
    public struct Koeficient
    {
        public int a, b;
    }

    static class LinearEquation
    {
       
     internal   static void Parse(string text,ref int a, ref int b)
        {
            //перевірка чи стрічка містить ',' або ' '
            if (text.Contains(',') || text.Contains(' '))
            {
                // розділяємо стрічку      
                String[] parts = text.Split(',',' ');
                if (parts.Length == 2 )
                {
                    //перевіряємо чи нормально пройшов парсинг
                    if (!Int32.TryParse(parts[0],out a) || !Int32.TryParse(parts[1], out b))
                    {
                        throw new FormatException("Bad parse string to int !");
                    } 
                }
                else
                {
                    throw new FormatException("Bad string format.Too many or less parameters");
                }
            }
            else
            {
                throw new FormatException("Bad string format.");
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            // Console.WriteLine("\n Please, give me two Koefficients of linear equation a and b. \n Format: \"int32, int32\".");
            // string line = Console.ReadLine();
            string line = "23 17";
            Koeficient k = new Koeficient()
            try
            {
                LinearEquation.Parse(line, ref k.a, ref k.b);
                Console.WriteLine($"Koeficient a={k.a}, b={k.b}");
            }
            catch (FormatException e)
            {
                Console.WriteLine("The catch is: \"{0}\"", e.Message);
            }
            finally
            {
                Console.WriteLine("Process string  to koeficient ended good!");
            }
        }
    }
}