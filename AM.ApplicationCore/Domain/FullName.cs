using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{

   // [Owned]  cette  annotation pour  configurer le Type Complex 
    public class FullName
    {
        [MinLength(3, ErrorMessage = "The minimum length is 3")]  // controle de saisie  
        [MaxLength(25, ErrorMessage = "The maximum  length is 3")] // controle de saisie 


        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
