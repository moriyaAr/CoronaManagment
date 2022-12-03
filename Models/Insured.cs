using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoronaManagment.Models
{
    public class Vacine
    {
        public string InsuredID { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public string ReceivingDate { get; set; }
    }

    public class Disease
    {
        public string InsuredID { get; set; }
        public String StartingDate { get; set; }
        public String RecoveringDate { get; set; }

    }
    public class Insured
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InsuredID { get; set; }
        public string Addres { get; set; }
        public string BirthDate { get; set; }
        public string Tel { get; set; }
        public string Phone { get; set; }

        public List<Vacine> VacinesList = null; 
        
        public Disease disease;
    }
}