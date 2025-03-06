using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        #region Fields

        private string _accHoldername;

        private int _accNo;

        protected double _annualIntrRate;

        protected decimal _balance;
        #endregion

        #region Constructors
        public Account(int accNo, string accHolderName)
        {
            _accHoldername = accHolderName;
            _accNo = accNo;
            _annualIntrRate = 0.0;
            _balance = 0.0m;
        }
        #endregion

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

        #region Methods
        
        public Decimal Deposit(double amount)
        {
            _balance += (decimal)amount;
            return _balance;
        }

        public decimal Withdraw(double amount)
        {
            _balance -= (decimal)amount;
            return _balance;
        }

        public void Load(string file)
        {

        }

        public void Save(string file)
        {

        }

        #endregion


    }
}
