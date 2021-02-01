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
    class Vistor : Person
    {
        public string PassportNo
        {
            get; set;
        }
        public string Nationality
        {
            get; set;
        }
        public Vistor(string na, string pass, string nat) : base(na)
        {
            PassportNo = pass;
            Nationality = nat;
        }
        public override double CalculateSHNCharges()
        {
            return 1;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
