using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        public Account OpenAccount(string clientName, string accountType)
        {
            Account account = new Account(DetermineAccountNumber(), clientName);

            switch (accountType)
            {
                case "Chequing":
                    account = new ChequingAccount(DetermineAccountNumber(), clientName);
                    _accountList.Add(account);
                    break;
                case "Savings":
                    account = new SavingsAccount(DetermineAccountNumber(), clientName);
                    _accountList.Add(account);
                    break;
                default:
                    Debug.Assert(false, "Failed to find a matching account type to create. Defaulting to chequing");
                    account = new ChequingAccount(DetermineAccountNumber(), clientName);
                    _accountList.Add(account);
                    break;
            }
            
            // Return the account in case caller wants to verify (just style/implementaiton of the UML class diagram)
            return account;
        }

        public void LoadAccountData()
        {

        }

        public void SaveAccountData()
        {
            
        }

        public Account FindAccount(int accNo)
        {
            for (int iAccount = 0; iAccount < _accountList.Count(); iAccount++)
            {
                if (accNo == _accountList[iAccount].AccountNumber)
                {
                    return _accountList[iAccount];
                }
            }
            throw new Exception("No accounts were found");
        }

        private void CreateDefaultAccounts()
        {
            for (int iAccount=0; iAccount<5; iAccount++)
            {
                Account savingsAccount = new SavingsAccount(DetermineAccountNumber(), "Gavin");
                _accountList.Add(savingsAccount);

                Account chequingAccount = new ChequingAccount(DetermineAccountNumber(), "Gavin");
                _accountList.Add(chequingAccount);
            }
        }

        private int DetermineAccountNumber()
        {
            _nextId += 1;
            return _nextId + ID_START;
        }


        #endregion

    }
}
