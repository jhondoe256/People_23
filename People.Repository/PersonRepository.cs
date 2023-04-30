
//This object only exist to Hold a Collection of type Person
// The 'collection' we will use here is List<Person>
public class PersonRepository
{
    // _PersonDb is our database
    // on this database we can perform different actions
    //C.R.U.D
    private List<Person> _PersonDb = new List<Person>();
    //I need to make an _count -> to auto-increment the value of
    //each persons Unique Identifier (ID)
    private int _count = 0;


    //Create, returns a 'bool' to show if it works or not
    public bool AddPersonToDatabase(Person person)
    {
        if (person is null)
        {
            return false;
        }
        else
        {
            //increment the count
            _count++;
            //assing the value to the person.Id property
            person.Id = _count;
            //add the person to the database
            _PersonDb.Add(person);
            //indicate to the user that everything worked.
            return true;
        }
    }
    //Read All -> just give back to the user everything in the database
    public List<Person> GetPeople()
    {
        return _PersonDb;
    }

    //Read By Id -> get the Person by his/her unique identifier
    public Person GetPerson(int personId)
    {
        foreach (Person personInDb in _PersonDb)
        {
            if (personInDb.Id == personId)
            {
                return personInDb;
            }
        }
        return null;
    }

    //Read -> get person by lastName
    public Person GetPerson(string lastName)
    {
        return _PersonDb.SingleOrDefault(p => p.LastName == lastName)!;
    }

    //Update
    public bool UpdatePersonData(int personId, Person newPersonData)
    {
        //find the person in the database
        Person personInDatabase = GetPerson(personId);
        //if the personInDatabase exists, then will make changes to that person
        if (personInDatabase != null)
        {
            //we can make changes b/c person exists!
            personInDatabase.FirstName = newPersonData.FirstName;
            personInDatabase.LastName = newPersonData.LastName;
            personInDatabase.Address = newPersonData.Address;
            personInDatabase.City = newPersonData.City;
            personInDatabase.State = newPersonData.State;
            personInDatabase.PhoneNumber = newPersonData.PhoneNumber;
            personInDatabase.DateOfBirth = newPersonData.DateOfBirth;

            return true;
        }
        return false;
    }


    //Delete
    public bool DeletePerson(int personId)
    {
        Person personToDelete = GetPerson(personId);
        return _PersonDb.Remove(personToDelete);
    }
}
