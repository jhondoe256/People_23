
public class Person
{
    //* I want to construct a Person and its values on the fly
    //* an Empty constructor is the DEFAULT constructor
    public Person()
    {

    }

    //* But we can make our own constructors!
    //* Lets make a FULL CONSTRUCTOR!
    //* So, the values inbetween the (), is the values user will be 'passing in'
    public Person(
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string address,
        string city,
        string state,
        string phoneNumber
    )
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Address = address;
        City = city;
        State = state;
        PhoneNumber = phoneNumber;
    }
    //* A. The Name of the Method
    //* B. Its parameters is it signature

    //A.           B.               B.
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    //get = 'read only' -> the complier (computer) can only read the data
    //set = 'write' -> the compileer (computer) can write to the variable container
    // which is FirstName
    //* FirstName is a variable container that is w/n an object
    //* We call these Properties.
    //* It describes the object.
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //we need a way to just print out the first and last name of a person
    //This is a "read-only" property
    //? RESEARCH Getters and Setters
    public string FullName
    {
        //we just want to 'get' or compute a value
        get
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                return "Sorry, my name is Nobody!";
            }
            else
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PhoneNumber { get; set; }

    //Object can have Methods...
    //They are just 'actions' that the object (Person) can perform

    // void => 'return nothing'
    public void Greeting()
    {
        System.Console.WriteLine($"Hi, My name is: {FullName}!");
    }

    public string GreetAnotherPerson(Person person)
    {
        return $"Hello,{person.FullName}! My name is {FullName}.";
    }
}

