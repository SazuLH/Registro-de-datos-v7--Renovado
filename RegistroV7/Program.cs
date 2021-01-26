using System;
using System.Collections.Generic;

namespace RegistroV7
{
    class Program
    {
        static PersonSet personSet;
        static void Main(string[] args)        
        {
            string filePath = @"C:\Users\ODILIS\Desktop\Registro\RegistroV7\"+args[0]+".txt";
            personSet = new PersonSet(filePath);
            int endProg = 0;
            do
            {
                int num;
                Console.WriteLine();
                Console.WriteLine("Main menu");
                Console.WriteLine("///////////////////////////////////////");
                Console.Write("(1). Capture data.\n");
                Console.Write("(2). List existing information.\n");
                Console.Write("(3). Scearch.\n");
                Console.Write("(4). Edit Data.\n");
                Console.Write("(5). Delete data.\n");
                Console.Write("(6). Exit\n");
                Console.WriteLine("///////////////////////////////////////");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (num)
                {
                    case 1:
                    SaveData(filePath);
                    Console.Clear();
                    break;
                    case 2:
                    Reading(filePath);
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey();
                    break;
                    case 3:
                    string idFinder;
                    Console.WriteLine("\n Enter the ID you want to search");
                    idFinder = Console.ReadLine();
                    Console.WriteLine();
                    SRC(idFinder);
                    Console.ReadKey();
                    break;
                    case 4:
                    Console.WriteLine("\n Enter the ID you want search");
                    idFinder = Console.ReadLine();
                    Console.WriteLine();
                    DataEdit(filePath, idFinder);
                    break;  

                    case 5:
                    Console.WriteLine("\n Enter the ID you want search");
                    idFinder = Console.ReadLine();
                    Console.WriteLine();
                    DataDelete(idFinder);
                    break;

                    case 6:
                     endProg++;
                    break;        
                        
        
                    default:
                    Console.WriteLine("Invalid input.");
                    break;
                }

            } while (endProg == 0);
            
            
        }

        static string StartData()
        {
            string id = "", names = "", lastNames = "";
            string limiter = ";";

            Console.Write("Identidy: ");
            id = OnlyId();
            Console.Write("Names: ");
            names = OnlyNames();
            Console.Write("Last names: ");
            lastNames = OnlylastNames();
            int DataBit = BitCode();
            string finalData = id + limiter + names + limiter + lastNames  + limiter + DataBit;

            return finalData;

        } 

        static string OnlyId()
        {
            var id = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if(key == ConsoleKey.Backspace && id.Length > 0)
                {
                    Console.Write("\b \b");
                    id = id[0..^1];
                }
                else if(char.IsDigit(keyInfo.KeyChar))
                {
                    Console.Write(keyInfo.KeyChar);
                    id += keyInfo.KeyChar;
                }
            }while(key != ConsoleKey.Enter);
            Console.WriteLine();
            return id;

        }

        static string OnlyNames()
        {
            var name = string.Empty;
            ConsoleKey key;
            do
            {
               var keyInfo = Console.ReadKey(intercept: true);
               key = keyInfo.Key;
               if(key == ConsoleKey.Backspace && name.Length > 0)
               {
                   Console.Write("\b \b");
                   name = name[0..^1];
               }
               else if (key == ConsoleKey.Spacebar)
               {
                   Console.Write(keyInfo.KeyChar);
                   name += keyInfo.KeyChar;
               }
               else if(char.IsLetter(keyInfo.KeyChar))
               {
                   Console.Write(keyInfo.KeyChar);
                   name += keyInfo.KeyChar;
               }
            }while(key != ConsoleKey.Enter);
            Console.WriteLine();
            return name;
        }

        static string OnlylastNames()
        {
            var Lname = string.Empty;
            ConsoleKey key;
            do
            {
               var keyInfo = Console.ReadKey(intercept: true);
               key = keyInfo.Key;
               if(key == ConsoleKey.Backspace && Lname.Length > 0)
               {
                   Console.Write("\b \b");
                   Lname = Lname[0..^1];
               }
               else if (key == ConsoleKey.Spacebar)
               {
                   Console.Write(keyInfo.KeyChar);
                   Lname += keyInfo.KeyChar;
               }
               else if(char.IsLetter(keyInfo.KeyChar))
               {
                   Console.Write(keyInfo.KeyChar);
                   Lname += keyInfo.KeyChar;
               }
            }while(key != ConsoleKey.Enter);
            Console.WriteLine();
            return Lname;
        }
        static string OnlyAge()
        {
            var age = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if(key == ConsoleKey.Backspace && age.Length > 0)
                {
                    Console.Write("\b \b");
                    age = age[0..^1];
                }
                else if(char.IsDigit(keyInfo.KeyChar))
                {
                    Console.Write(keyInfo.KeyChar);
                    age += keyInfo.KeyChar;
                }
            }while(key != ConsoleKey.Enter);
            Console.WriteLine();
            return age;

        }

        
        static void SaveData(string filePath)
        {
            int menu;
            int endProg = 0;

            do
            {
                string Regis = StartData();
                string[] r = Regis.Split(";");
                Person person = new Person(r[0],r[1],r[2],Convert.ToInt16(r[3]));
                Console.WriteLine("Save(1), Discart(2), Exit(3)");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                    personSet.Add(person);
                    break;

                    case 2:    
                    break;

                    case 3:
                    endProg++;
                    break;

                    default:
                    Console.WriteLine("Invalid entry. ");
                    break;
                }
            } while (endProg == 0);

        }
        
        static void Reading(string filePath)
        {
            List<Person> persons = personSet.PersonList();
            foreach(Person p in persons)
            {
                Console.WriteLine(p.ToString());
            }
            
        }

        static Person SRC( string id)
        {
            Person person = personSet.Contains(id);
            Console.WriteLine(person.ToString());
            return person;
        }

        
        static void DataEdit(string filePath, string id)
        {
            SRC(id);

            string Regis = StartData();
            string[] r = Regis.Split(";");
            Person Person = new Person(r[0],r[1],r[2],Convert.ToInt16(r[3]));
            personSet.Replace(id,Person);
        }

        static void DataDelete(string id)
        {

            SRC(id);
            personSet.Remove(id);

        }
       
        static int BitCode()
        {
            Console.Write("Sex(M/F)");
            char sex = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("Status(S/M)");
            char status = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("Grade(I/M/G/P)");
            char grade = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            while(age < 7 || age > 120)
            {
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine());
            }
            int data = age << 4;
            if (sex == 'F')
            {
               data = data | 1;
            }
            else if(sex == 'M')
            {
              data = data | 0;
            }
            if (status == 'S')
            {
              data = data | 0;
            }
            else if(status == 'M')
            {
              data = data | 1;
            }
            if (grade == 'M')
            {
              data = data | 1;
            }
            else if(grade == 'G')
            {
              data = data | 2;
            }
            else if(grade == 'P')
            {
              data = data | 3;
            }
            return data;
        }
}
}
