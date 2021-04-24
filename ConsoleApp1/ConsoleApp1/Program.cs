using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathDesktop = @"C:\Customers.dat";

            List<CustomersRate> customersRates = new List<CustomersRate>();
            
            string word = "да";

            while(word == "да")
            {
                Console.WriteLine("Введите вашу фамилию:");

                string family = Console.ReadLine();

                Console.WriteLine("Введите ваше имя:");

                string name = Console.ReadLine();               
                bool IsCheck = false;
                int rate = 0;

                while (!IsCheck)
                {
                    Console.WriteLine("Поставьте оценку обратной связи (от 1 до 10):");
                   IsCheck = CheckInt(Console.ReadLine(), out rate);
                }

                customersRates.Add(new CustomersRate() {FirstName = name, LastName = family, Rate = rate });

                Console.WriteLine("Еще добавим отзыв? (да/нет)");

                word = Console.ReadLine();
            }

            SerializeAndSave(PathDesktop, customersRates);



            //foreach(var customer in customersRates)
            //{
            //    Console.WriteLine(customer.FirstName);               
            //}
            Console.ReadLine();
        }


        static bool CheckInt(string strval, out int intval) 
        { bool IsInt; 
            IsInt = int.TryParse(strval, out intval) && intval > 0 && intval <= 10 ? true : false; 
            return IsInt; 
        }

        public static void SerializeAndSave(string path, List<CustomersRate> data)
        {
            var serializer = new XmlSerializer(typeof(List<CustomersRate>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, data);
            }
        }

        public List<CustomersRate> ReadAndDeserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(List<CustomersRate>));
            using (var reader = new StreamReader(path))
            {
                return (List<CustomersRate>)serializer.Deserialize(reader);
            }
        }
    }
}
