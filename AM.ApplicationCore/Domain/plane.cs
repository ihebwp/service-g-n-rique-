using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class plane
    {
        #region
        public string nom;

        public string GetNom() { return nom; }  
        public void SetNom(string value) { nom = value; }   


        //prop+2tab : Lignt version  
        public string Nom { get; set; }


        private int number;

        // prop: Full version 
        public int Number
        {
            get { return number; }
            set { number = value; }

        }

        //prop+2tab  : 

        public int salary { get; private set; }
        #endregion
        //des proprietes  de  Base 
        [Range(0,int.MaxValue)] // +plus  l infinie 
        public int Capacity { get; set; }
        public DateTime ManifactureDate { get; set; }


        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }


        public plane() {
        }  


        //des proprietes  de Navigation
        public ICollection<Flight> Flights
        { get; set; }

        public static implicit operator Plane(plane v)
        {
            throw new NotImplementedException();
        }
    }
}
