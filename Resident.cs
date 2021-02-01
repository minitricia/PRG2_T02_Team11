using System;
using System.Collections.Generic;
using System.Text;

namespace PRG2_T02_Team11
{
    //============================================================
    // Student Number : S10208093K
    // Student Name : Lim Jin Hui
    // Module Group : T02
    //============================================================
    class Resident : Person
    {
        public string Address { get; set; }
        public DateTime lastLeftCountry { get; set; }
        public void token (TraceTogetherToken ttf) 
        { 
            
        }
        public Resident(string a, DateTime lLC , string n) : base(n)
        {
            Address = a;
            lastLeftCountry = lLC;
        }
        public override double CalculateSHNCharges() 
        {
            // not working
            return 200 + 80;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
