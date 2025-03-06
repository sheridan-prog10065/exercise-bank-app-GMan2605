using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{

    public class Bank
    {
        private string _bankName;

        /// <summary>
        /// List container for all accounts in this bank
        /// </summary>
        private ObservableCollection<Account> _accountList;

        private const int ID_START = 100;

        private int _nextId;

        public Bank(string bankName)
        {
            _bankName = bankName;
            _accountList = new ObservableCollection<Account>();
            _nextId = 0;

            // Create some default accounts upon creation
            CreateDefaultAccounts();
        }

        #region Properties

        public ObservableCollection<Account> Accounts
        {
            get
            {
                return _accountList;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{_bankName}";
        }

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
