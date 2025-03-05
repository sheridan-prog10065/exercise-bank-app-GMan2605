using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        private string _accHoldername;

        private int _accNo;

        protected double _annualIntrRate;

        protected decimal _balance;


        #region Properties

        public string AccountHolderName
        {
            get
            {
                return _accHoldername;
            }
        }

        public int AccountNumber
        {
            get
            {
                return _accNo;
            }
        }

        public virtual double AnnualInterestRate
        {
            get
            {
                return _annualIntrRate;
            }
            set
            {
                _annualIntrRate = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        #endregion


    }
}
