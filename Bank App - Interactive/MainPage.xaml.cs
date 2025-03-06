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

		// Open the new account
		selectedBank.OpenAccount(acctName);
    }

    private void OnBankChanged(object sender, EventArgs e)
    {
		_cvAccounts.ItemsSource = ((Bank)_pckBank.SelectedItem).Accounts;
    }
}
