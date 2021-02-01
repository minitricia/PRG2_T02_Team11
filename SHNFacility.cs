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
    class SHNFacility 
    {
        public string FacilityName { get; set; }
        public int FacilityCapacity { get; set; }
        public int FacilityVacancy { get; set; }
        public double DistFromAirCheckpoint { get; set; }
        public double DistFromSeaCheckpoint { get; set; }
        public double DistFromLandCheckpoint { get; set; }
        public SHNFacility() { }
        public SHNFacility(string fN, int fC, double dfac, double dfsa, double dflc)
        {
            FacilityName = fN;
            FacilityCapacity = fC;
            DistFromAirCheckpoint = dfac;
            DistFromSeaCheckpoint = dfsa;
            DistFromLandCheckpoint = dflc;

        }
        // code is not working at the moment.
        public double CalculateTravelCost(string entryMode, DateTime entryDate, TravelEntry t, SHNFacility s)
        {
            t.EntryMode = entryMode;
            t.EntryDate = entryDate;
            double swabcost = 200;
            double transport = 80;
            double basefare = 50;

            double totalcost = swabcost + transport;

            if(entryMode == "Air")
            {
                double totaltransportcost = basefare * s.DistFromAirCheckpoint * 0.22;
                return totaltransportcost;
            }
            else if(entryMode == "Land")
            {
                double totaltransportcost = basefare * s.DistFromLandCheckpoint * 0.22;
                return totaltransportcost;
            }
            else if(entryMode == "Sea")
            {
                double totaltransportcost = basefare * s.DistFromSeaCheckpoint * 0.22;
                return totaltransportcost;
            }
            return totalcost;
        }

        public bool isAvailable() 
        {
            return false;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
