using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;

namespace ass6
{
    public partial class MainPage : ContentPage
    {

        BankAccount _Account;

        public MainPage()
        {
            InitializeComponent();
            Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            fnb.AddCustomer(myNewCustomer);

            var _Account = myNewCustomer.ApplyForBankAccount();
            _Account.DepositMoney(1500, DateTime.Now, "Stipend");
        }

        private void DepositButton_Clicked(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(Depositamount.Text.ToString());
            string reason = Reasondepositamount.Text.ToString();
            _Account.DepositMoney(amount, DateTime.Now, reason);
        }

        private void WithdrawButton_Clicked(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(Withdrawamount.Text.ToString());
            string reason = Reasonwithdrawamount.Text.ToString();
            _Account.WithdrawMoney(amount, DateTime.Now, reason);
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            string history = _Account.GetTransactionHistory();
            DisplayAlert("Transaction History", history, "OK");
        }
    }
}
