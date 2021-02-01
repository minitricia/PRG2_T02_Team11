using System;
using System.Collections.Generic;
using System.Text;

namespace PRG2_T02_Team11
{
    //============================================================
    // Student Number : S10208093K
    // Student Name : Lim Jin Hui, Tan Le Xuan Tricia
    // Module Group : T02
    //============================================================
    abstract class Person
    {
        public string Name { get; set;}
        public List<SafeEntry> SafeEntryList { get; set; }
        public List<TravelEntry> TravelEntryList { get; set; }
        public Person() { }
        public Person(string n)
        {
            Name = n;
            SafeEntryList = new List<SafeEntry>();
            TravelEntryList = new List<TravelEntry>();
        }
        public void AddTravelEntry(TravelEntry TE) 
        {
            TravelEntryList.Add(TE);
        }

        public void AddSafeEntry(SafeEntry SE)
        {
            SafeEntryList.Add(SE);
        }

        public abstract double CalculateSHNCharges();
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
