using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class SavingsAccount : Account
    {
        private const double SAVINGS_INTEREST_FACTOR = 1.5;

        public SavingsAccount(int acctNo, string acctHolderName) : base(acctNo, acctHolderName)
        {

        }

        public override string ToString()
        {
            return "Savings " + base.ToString();
        }


        /// <summary>
        /// Overriden property that guarantees the addition of the savings interest
        /// factor for every mutation of the interest rate of an account
        /// </summary>
        public override double AnnualInterestRate
        {
            get
            {
                return _annualIntrRate;
            }
            set
            {
                _annualIntrRate = value + SAVINGS_INTEREST_FACTOR;
            }
        }
    }
}
