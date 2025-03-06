using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Bank
    {
        /// <summary>
        /// List container for all accounts in this bank
        /// </summary>
        private List<Account> _accountList;

        private const int ID_START = 100;

        private int _nextId;

        public Bank()
        {
            _accountList = new List<Account>();
            _nextId = 0;

            // Create some default accounts upon creation
            CreateDefaultAccounts();
        }

        #region Methods
        public Account OpenAccount(string clientName)
        {
            return new Account(DetermineAccountNumber(), clientName);
        }

        public void LoadAccountData()
        {

        }

        public void SaveAccountData()
        {

        }

        public Account FindAccount(int accNo)
        {
            return new Account(0, "Gavin");
        }

        private void CreateDefaultAccounts()
        {
            for (int iAccount=0; iAccount<10; iAccount++)
            {
                Account account = new Account(DetermineAccountNumber(), "Gavin");
                _accountList.Add(account);
            }
        }

        private int DetermineAccountNumber()
        {
            return _nextId + ID_START;
        }


        #endregion

    }
}
