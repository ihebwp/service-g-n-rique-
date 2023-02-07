using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        //public int Id { get; set; }
        [Key] // clé primaire 
        [StringLength(7)] // champ de  n caractere 
        public string PassportNumber { get; set; }

        public  FullName FullName { get; set; }

        [DataType (DataType.Date)]  //  Format des  donnés 

        [DisplayName("Date of Birth")]   // changer le  non  sur  le client  pas  forcement  sur  la  base 
        public DateTime BirthDate { get; set; }


        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        //[Range(0, 8)]
        public int TelNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string EmailAdress { get; set; }

        public ICollection<Flight> Flights
        { get; set; }
          


        public bool checkProfil(string nom, string prenom)
        {
            return FullName.FirstName.Equals(nom)&& FullName.LastName.Equals(prenom); 

        }
        // respeter le  polymorphyseme par signature  
        public bool checkProfil(string nom, string prenom, string email )
        {
            //return FirstName.Equals(nom) && LastName.Equals(prenom)&& EmailAdress.Equals(email);
            return checkProfil(FullName.FirstName, FullName.LastName)&& EmailAdress.Equals(email);
        }
        public bool Login(string FirstName, string LastName, string email=null)
        {
            if(email!=null)
            {
               return  checkProfil( FirstName, LastName,email);
            }
            else
            {
                return checkProfil(FirstName, LastName);
            }
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("Im passenger ");
        }

    }
}
