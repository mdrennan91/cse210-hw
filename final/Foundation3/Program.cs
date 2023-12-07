using System;

class Program
{
    static void Main(string[] args)
    {
        Lecture lectureEvent = new Lecture("Programming Lecture", "An insightful lecture on the four basic principles of C#.", DateTime.Now, DateTime.Now.AddHours(2),
            new Address { _street = "111 Tech St", _city = "San Francisco", _state = "CA", _zipCode = "11111" }, "Brother Carter", 100);

        Reception receptionEvent = new Reception("Wedding Reception", "A celebration to remember.", DateTime.Now.AddDays(7), DateTime.Now.AddHours(4),
            new Address { _street = "222 Love St", _city = "Sacramento", _state = "CA", _zipCode = "22222" }, "rsvp_wedding@email.com");

        OutdoorGathering outdoorEvent = new OutdoorGathering("Wine Tasting", "Enjoy the outdoors with friends.", DateTime.Now.AddDays(14), DateTime.Now.AddHours(6),
            new Address { _street = "333 Vinyard St", _city = "Napa", _state = "CA", _zipCode = "333333" }, "We're expecting partly cloudy conditions. Come prepared!");

        // Lecture
        Console.WriteLine("Lecture Event:\n");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine("\nFull Details:\n");
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine("\nShort Description:\n");
        Console.WriteLine(lectureEvent.GetShortDescription());

        Console.WriteLine("\n----------------------------------\n");

        // Reception
        Console.WriteLine("Reception Event:\n");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine("\nFull Details:\n");
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine("\nShort Description:\n");
        Console.WriteLine(receptionEvent.GetShortDescription());

        Console.WriteLine("\n----------------------------------\n");

        // Outdoor Gathering
        Console.WriteLine("Outdoor Gathering Event:\n");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine("\nFull Details:\n");
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine("\nShort Description:\n");
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}