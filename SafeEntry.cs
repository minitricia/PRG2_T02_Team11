using System;
using System.Collections.Generic;
using System.Text;

namespace PRG2_T02_Team11
{
    //============================================================
    // Student Number : S10203209
    // Student Name : Tan Le Xuan, Tricia
    // Module Group : T02
    //============================================================

    class SafeEntry
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public BusinessLocation Location { get; set; }

        public SafeEntry() { }

        public SafeEntry(DateTime checkIn, BusinessLocation businessLocation)
        {
            CheckIn = checkIn;
            Location = businessLocation;
        }

        public void PerformCheckOut(string code)
        {
            CheckOut = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("CheckIn: " + CheckIn + Location);
        }
    }
}
