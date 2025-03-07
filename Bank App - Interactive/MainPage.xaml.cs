using System.Collections.ObjectModel;

namespace BankApp;

public partial class MainPage : ContentPage
{
	private ObservableCollection<Bank> _banks;

	public MainPage()
	{
		InitializeComponent();

		_banks = new ObservableCollection<Bank>();

		CreateBanks();

		// Set the picker to be the banks
		_pckBank.ItemsSource = _banks;

	}

	private void CreateBanks()
	{
		_banks.Add(new Bank("Bank of Bob"));
        _banks.Add(new Bank("Spicy Lemon Banking"));
        _banks.Add(new Bank("Bokoblin Incorporated"));
	}

	private void OnOpenAcctClicked(object sender, EventArgs e)
    {
		// Get the currently selected bank to act upon
		Bank selectedBank = (Bank)_pckBank.SelectedItem;

		// Get the specified account name string from the user
		string acctName = _etryClientNameInput.Text;

		// Get the prefered account type
		string prefAcctType = (string)_pckAccountType.SelectedItem;

		// Open the new account
		selectedBank.OpenAccount(acctName, prefAcctType);
    }

    private void OnBankChanged(object sender, EventArgs e)
    {
		RefreshCVAccounts();
    }

	private void RefreshCVAccounts()
	{
		_cvAccounts.ItemsSource = null;
        _cvAccounts.ItemsSource = ((Bank)_pckBank.SelectedItem).Accounts;
    }

    private void OnDeposit(object sender, EventArgs e)
    {
		// Try to obtain the selected account in the collectionview
		Account selectedAccount;
        try
		{
            selectedAccount = (Account)_cvAccounts.SelectedItem;
        }
		catch (InvalidCastException) // Catch an invalid cast and preemptively end the call
		{
			return;
		}

		// Get the specified dollar amount
		double amount = double.Parse(_etryAmount.Text);

		// Deposit the money
		selectedAccount.Deposit(amount);

		RefreshCVAccounts(); // Refresh the collection view to display the new ToStrings
    }

    private void OnWithdraw(object sender, EventArgs e)
    {
		// Try to obtain the selected account in the collectionview
		Account selectedAccount;
		try
		{
			selectedAccount = (Account)_cvAccounts.SelectedItem;
		}
		catch (InvalidCastException) // Catch an invalid cast and preemptively end the call
        {
			return;
		}

		// Get the specified dollar amount
		double amount = double.Parse(_etryAmount.Text);

		// Withdraw the money
		selectedAccount.Withdraw(amount);

        RefreshCVAccounts(); // Refresh the collection view to display the new ToStrings
    }
}
