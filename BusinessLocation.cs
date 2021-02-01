using System;
using System.Collections.Generic;
using System.Text;

namespace PRG2_T02_Team11
{

    //============================================================
    // Student Number : S10203209D
    // Student Name : Tan Le Xuan Tricia
    // Module Group : T02
    //============================================================

    class BusinessLocation
    {
        public string BusinessName { get; set; }
        public string BranchCode { get; set; }
        public int MaximumCapacity { get; set; }
        public int VisitorsNow { get; set; }

        public BusinessLocation()
        {
            BusinessName = "";
            BranchCode = "";
            MaximumCapacity = 0;
            VisitorsNow = 0;
        }

        public BusinessLocation(string businessName, string branchCode, int maximumCapacity)
        {
            BusinessName = businessName;
            BranchCode = branchCode;
            MaximumCapacity = maximumCapacity;
        }

        public bool IsFull(string location)
        {
            if (VisitorsNow < MaximumCapacity)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return string.Format(" Business Name: " + BusinessName + "  Branch Code: "
                + BranchCode + "  Maximum Capacity: " + MaximumCapacity);
        }
    }
}
