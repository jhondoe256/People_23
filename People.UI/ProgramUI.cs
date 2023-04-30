
public class ProgramUI
{
    //MAKE GLOBALLY SCOPED REPOSITORY INSTANCE
    //we can use _pRepo anywhere we want inside this object
    private PersonRepository _pRepo = new PersonRepository();
    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine(
            "Welcome to the People App\n" +
            "1.  View All People\n" +
            "2.  View Person By Id\n" +
            "3.  Add Person\n" +
            "4.  Update Existing Person\n" +
            "5.  Delete Existing Person\n" +
            "================================\n" +
            "00. Exit Application");

            string userInput = Console.ReadLine()!;

            switch (userInput)
            {
                case "1":
                    ViewAllPeople();
                    break;
                case "2":
                    ViewPersonById();
                    break;
                case "3":
                    AddPerson();
                    break;
                case "4":
                    UpdateExistingPerson();
                    break;
                case "5":
                    DeleteExistingPerson();
                    break;
                case "00":
                    isRunning = ExitApp();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection.");
                    break;
            }

        }
    }

    private void DeleteExistingPerson()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a person Id.");

        int userInput = int.Parse(Console.ReadLine()!);

        Person personInDb = _pRepo.GetPerson(userInput);

        //if personInDb exists
        if (personInDb != null)
        {
            if (_pRepo.DeletePerson(personInDb.Id))
            {
                System.Console.WriteLine($"{personInDb.FullName} WAS DELETED!");
            }
            else
            {
                System.Console.WriteLine($"{personInDb.FullName} WAS NOT DELETED!");
            }
        }
        else
        {
            System.Console.WriteLine($"The person with the Id: {userInput} doesn't Exist!");
        }
        PressAnyKey();
    }

    private void UpdateExistingPerson()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a person Id.");

        int userInput = int.Parse(Console.ReadLine()!);

        Person personInDb = _pRepo.GetPerson(userInput);

        //if personInDb exists
        if (personInDb != null)
        {
            Console.Clear();
            Person newPersonData = new Person();

            //ask questions and assign values
            System.Console.Write("Please Enter a First Name: ");
            string userInputFirstName = Console.ReadLine()!;
            newPersonData.FirstName = userInputFirstName;

            System.Console.Write("Please Enter a Last Name: ");
            string userInputLastName = Console.ReadLine()!;
            newPersonData.LastName = userInputLastName;

            System.Console.WriteLine("Enter year Born YYYY");
            int userInputYearBorn = int.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Enter month Born MM");
            int userInputMonthBorn = int.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Enter day Born MM");
            int userInputDayBorn = int.Parse(Console.ReadLine()!);

            newPersonData.DateOfBirth = new DateTime(userInputYearBorn, userInputMonthBorn, userInputDayBorn);

            System.Console.Write("Please Enter an Address: ");
            string userInputAddress = Console.ReadLine()!;
            newPersonData.Address = userInputAddress;

            System.Console.Write("Please Enter a City: ");
            string userInputCity = Console.ReadLine()!;
            newPersonData.City = userInputCity;

            System.Console.Write("Please Enter a State: ");
            string userInputState = Console.ReadLine()!;
            newPersonData.State = userInputState;

            System.Console.Write("Please Enter a Phone Number: ");
            string userInputPhoneNumber = Console.ReadLine()!;
            newPersonData.PhoneNumber = userInputPhoneNumber;

            //the whole form is filled out, now we need to update to the database!
            if (_pRepo.UpdatePersonData(personInDb.Id, newPersonData))
            {
                System.Console.WriteLine($"{newPersonData.FullName} Was UPDATED in The Database");
            }
            else
            {
                System.Console.WriteLine($"{newPersonData.FullName} Was NOT UPDATED To The Database");
            }
        }
        else
        {
            System.Console.WriteLine($"The person with the Id: {userInput} doesn't Exist!");
        }
        PressAnyKey();
    }

    private void AddPerson()
    {
        Console.Clear();
        Person personData = new Person();

        //ask questions and assign values
        System.Console.Write("Please Enter a First Name: ");
        string userInputFirstName = Console.ReadLine()!;
        personData.FirstName = userInputFirstName;

        System.Console.Write("Please Enter a Last Name: ");
        string userInputLastName = Console.ReadLine()!;
        personData.LastName = userInputLastName;

        System.Console.WriteLine("Enter year Born YYYY");
        int userInputYearBorn = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter month Born MM");
        int userInputMonthBorn = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter day Born MM");
        int userInputDayBorn = int.Parse(Console.ReadLine()!);

        personData.DateOfBirth = new DateTime(userInputYearBorn, userInputMonthBorn, userInputDayBorn);

        System.Console.Write("Please Enter an Address: ");
        string userInputAddress = Console.ReadLine()!;
        personData.Address = userInputAddress;

        System.Console.Write("Please Enter a City: ");
        string userInputCity = Console.ReadLine()!;
        personData.City = userInputCity;

        System.Console.Write("Please Enter a State: ");
        string userInputState = Console.ReadLine()!;
        personData.State = userInputState;

        System.Console.Write("Please Enter a Phone Number: ");
        string userInputPhoneNumber = Console.ReadLine()!;
        personData.PhoneNumber = userInputPhoneNumber;

        //the whole form is filled out, now we need to add to the database!
        if (_pRepo.AddPersonToDatabase(personData))
        {
            System.Console.WriteLine($"{personData.FullName} Was Added To The Database");
        }
        else
        {
            System.Console.WriteLine($"{personData.FullName} Was NOT Added To The Database");
        }
        PressAnyKey();
    }

    private void ViewPersonById()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a person Id.");

        int userInput = int.Parse(Console.ReadLine()!);

        Person personInDb = _pRepo.GetPerson(userInput);

        //if personInDb exists
        if (personInDb != null)
        {
            Console.Clear();
            DisplayPersonData(personInDb);
        }
        else
        {
            System.Console.WriteLine($"The person with the Id: {userInput} doesn't Exist!");
        }
        PressAnyKey();
    }

    private void ViewAllPeople()
    {
        Console.Clear();
        foreach (Person p in _pRepo.GetPeople())
        {
            DisplayPersonData(p);
        }
        PressAnyKey();
    }

    private void DisplayPersonData(Person p)
    {
        Console.WriteLine(
        $"Id: {p.Id}\n" +
        $"Name: {p.FullName}\n" +
        $"DOB: {p.DateOfBirth}\n" +
        $"Address: {p.Address}\n" +
        $"City: {p.City}\n" +
        $"State: {p.State}\n" +
        $"Phone number: {p.PhoneNumber}\n" +
        "-----------------------------------\n");
    }

    private bool ExitApp()
    {
        System.Console.WriteLine("Thank's");
        PressAnyKey();
        return false;
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void Seed()
    {
        Person jim = new Person(
            "Jim",
            "Johnson",
            new DateTime(1989, 11, 12),
            "123 Old Head Lane",
            "Indianapolis",
            "Indiana",
            "1-111-155-5555"
            );


        Person steve = new Person(
            "Steve",
            "Jenkins",
            new DateTime(1999, 10, 12),
            "123 Address Lane",
            "Indianapolis",
            "Indiana",
            "1-111-111-1111"
            );

        Person becka = new Person(
        "Rebecca",
        "Jones",
        new DateTime(1999, 02, 14),
        "123 Beccas House",
        "Indianapolis",
        "Indiana",
        "1-111-222-2222"
        );

        //we need to add these to the database (_pRepo), but we don't have an instance of the 
        //Person Repository, so lets make a GLOBALLY SCOPED VERSION, AT THE TOP OF THIS FILE!

        _pRepo.AddPersonToDatabase(jim);
        _pRepo.AddPersonToDatabase(steve);
        _pRepo.AddPersonToDatabase(becka);
    }
}
