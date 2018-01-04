using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinConverter.Data;
using Xamarin.Forms;

namespace BitcoinConverter
{
	public partial class MainPage : ContentPage
	{
        readonly ConvertManager manager = new ConvertManager();

		public MainPage()
		{
			InitializeComponent();
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        string currency = null;
	        var selectedIndex = CurrencyPicker.SelectedIndex;

	        if (selectedIndex != -1)
	        {
	            currency = CurrencyPicker.Items[selectedIndex];
	        }
	        var amountInput = AmountEntry.Text;
            var amount = decimal.Parse(amountInput);
            var result = await ConvertManager.ConvertCurrency(currency, amount);
	        await DisplayAlert("Success!", amount + " Bitcoins is: "+ result.ToString(CultureInfo.InvariantCulture) + currency, "Close");
	    }

	    private void CurrencyPicker_OnSelectedIndexChanged(object sender, EventArgs e)
	    {
	        
        }
	}
}
