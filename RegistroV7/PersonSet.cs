using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace RegistroV7
{
    public class PersonSet:IPerson
    {
        private string filePath; 
        public PersonSet(string P)
        {
            filePath = P;
        }
        public bool Add(Person Person)
        {
            
           using (StreamWriter sw = File.AppendText(filePath))
         {
            sw.WriteLine(Person.ToWrite());
            sw.Close();           
         }
          return true;
        }

        public Person Contains(string id)
        {
          string Line = "";
            Person person = new Person("","","",0);
            using(StreamReader sr = new StreamReader(filePath))
            {
              if((Line = sr.ReadLine()) != null)
              {
                  if(Line.Contains(id)){
                    string[] r = Line.Split(";");
                    person = new Person(r[0],r[1],r[2],Convert.ToInt16(r[3]));
                  }
              } 
            }
            return person;
          
        }

        public List<Person> PersonList()
        {
            string Line = "";
            List<Person> persons = new List<Person>();
            using(StreamReader sr = new StreamReader(filePath))
            {
              while ((Line = sr.ReadLine()) != null)
              {
                string[] r = Line.Split(";");
                Person Person = new Person(r[0],r[1],r[2],Convert.ToInt16(r[3]));
                persons.Add(Person);
              } 
            }
            return persons;
        }

        public bool Remove(string id)
        {
            string[] lines = File.ReadAllLines(filePath);
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                for(int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if(lines[currentLine - 1].Contains(id))
                    {
                        continue;
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
            return true;
        }

        public bool Replace(string id, Person Person)
        {
           string[] lines = File.ReadAllLines(filePath);
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                for(int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if(lines[currentLine - 1].Contains(id))
                    {
                        writer.WriteLine(Person.ToWrite());
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
            return true;
        }
        
    }
}