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
    class TraceTogetherToken
    {
        public string SerialNo
        {
            get; set;
        }
        public string CollectionLocation
        {
            get;set;
        }
        public DateTime ExpiryDate
        {
            get;set;
        }
        public TraceTogetherToken()
        {

        }
        public TraceTogetherToken(string SN, string CL, DateTime ED)
        {
            SerialNo = SN;
            CollectionLocation = CL;
            ExpiryDate = ED;
        }
        public bool IsEligibleForReplacement()
        {
            return true;
        }
        public void ReplaceToken(string SN, string CL)
        {
            SerialNo = SN;
            CollectionLocation = CL;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
