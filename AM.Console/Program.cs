// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");

//il  faut respecter  l'ordre
//plane P1 =  new plane(50, new DateTime(12/12/2023),1);



//initialiseur  d'objets 

 plane p2 = new plane
{
    Capacity = 100,
    ManifactureDate = DateTime.Now,
    PlaneId = 2
   
};

Passenger passenger1 = new Passenger
{

    FullName = new FullName
    {
        FirstName = "ons",
        LastName = "jabeur"
    },
   
    EmailAdress = "ons.jabeur@gmail.com"
};

Staff staff1 = new Staff
{
    FullName = new FullName
    {

        FirstName = "staf1",
        LastName = "saff1",

    },
    
    
   
    EmailAdress = "staff1@gmail.com"
};

Traveller traveller1 = new Traveller
{
    FullName= new FullName {
        FirstName = "Traveller",
        LastName = "Traveller1"
    },

    
    EmailAdress = "Traveller@gmail.com"

};
Console.WriteLine(passenger1.checkProfil("ons", "jabeur"));
Console.WriteLine(passenger1.checkProfil("ons", "jabeur", "staff1@gmail.com"));

passenger1.PassengerType();
staff1.PassengerType();
traveller1.PassengerType();
