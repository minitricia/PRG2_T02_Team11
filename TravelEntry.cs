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
    class TravelEntry : SHNFacility
    {
        public string LastCountryOfEmbarkation { get; set; }
        public string EntryMode { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ShnEndDate { get; set; }
        public void SHNStay(SHNFacility s)
        {
            int counter = 1;
            int minus = s.FacilityCapacity - 1;
            minus += s.FacilityVacancy;

            Console.WriteLine("[{0,1}] {1,-20} {2,16} {3,21} {4,21} {5,19}", counter, s.FacilityName, minus, s.DistFromAirCheckpoint,
            s.DistFromLandCheckpoint, s.DistFromSeaCheckpoint);
            
        }
        public bool IsPaid { get; set; }
        public TravelEntry() { }
        public TravelEntry(string lcoe, string em, DateTime ed)
        { 
            LastCountryOfEmbarkation = lcoe; 
            EntryMode = em; 
            EntryDate = ed;
        }
        public void AssignSHNFacility(SHNFacility s)
        {
            SHNStay(s);
        }
        public void CalculateSHNDuration() 
        {
            if (LastCountryOfEmbarkation == "New Zeland") 
            {
                DateTime today = EntryDate;
                DateTime plus0 = today.AddDays(0);
                ShnEndDate = plus0;
                Console.WriteLine("No SHN");
                Console.WriteLine();
                
            }
            else if (LastCountryOfEmbarkation == "Vietnam")
            {
                DateTime today = EntryDate;
                DateTime plus0 = today.AddDays(0);
                ShnEndDate = plus0;
                Console.WriteLine("No SHN");
                Console.WriteLine();
            }
            else if(LastCountryOfEmbarkation == "Macao SAR")
            {
                DateTime today = EntryDate;
                DateTime plus0 = today.AddDays(7);
                ShnEndDate = plus0;
                Console.WriteLine("7-day SHN at own accommodation");
                Console.WriteLine("Swab Test");
                Console.WriteLine("shnEndDate:{0}", plus0);
                Console.WriteLine();
            }
            else
            {
                DateTime today = EntryDate;
                DateTime plus0 = today.AddDays(14);
                ShnEndDate = plus0;
                Console.WriteLine("14-day SHN at own accommodation");
                Console.WriteLine("Swab Test");
                Console.WriteLine("shnEndDate:{0}", plus0);
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
