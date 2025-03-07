using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class ChequingAccount : Account
    {
        private const double CHEQUING_INTEREST_FACTOR = 0.25;

        public ChequingAccount(int acctNo, string acctHolderName) : base(acctNo, acctHolderName)
        {

        }

        public override string ToString()
        {
            return "Chequing " + base.ToString();
        }


        /// <summary>
        /// Overriden property that guarantees the addition of the
        /// chequing interest factor being added for every mutation of
        /// this chequing account's annual interest rate attribute field.
        /// </summary>
        public override double AnnualInterestRate
        {
            get
            {
                return _annualIntrRate;
            }
            set
            {
                _annualIntrRate = value + CHEQUING_INTEREST_FACTOR;
            }
        }
    }

}
