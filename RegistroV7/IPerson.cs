using System.Collections.Generic;

namespace RegistroV7
{
    public interface IPerson
    {
        bool Add(Person Person);
        bool Remove(string id);
        Person Contains(string id);
        bool Replace(string id,Person Person);
        List<Person> PersonList();
    }
}