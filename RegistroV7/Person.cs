namespace RegistroV7
{
    public class Person
    {
        private int HiddenData = 0;
        public string Id { get; }
        public string Name { get; }
        public string LastName { get; }
        public string FullName => $"{Name} {LastName}";
        public int Age => HiddenData >> 4;
        public Sex Sex => (Sex) ((HiddenData & 15) >> 3);
        public Status Status => (Status) ((HiddenData & 7) >> 2);
        public Grade Grade => (Grade) (HiddenData & 3);


        public Person(in string id, in string names, in string lastNames, in int data)
        {
            Id = id;
            Name = names;
            LastName = lastNames;
            HiddenData = data;
        }

        public Person CreateFromLine(string line)
        {
            string[] data = line.Split(";");
            return new Person(data[0], data[1], data[2], int.Parse(data[3]));
        }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {FullName};{Age}; Sex: {Sex}; Status: {Status}; Grade: {Grade}";
        
        }
        public string ToWrite()
        {
            return $"{Id};{Name};{LastName};{HiddenData}";
        }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }

    public enum Status
    {
        Single = 0,
        Married = 1
    }

    public enum Grade
    {
        Initial = 0,
        Media = 1,
        Grade = 2,
        PostGrade = 3
    }

}