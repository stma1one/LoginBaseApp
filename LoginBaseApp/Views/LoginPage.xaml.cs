
using LoginBaseApp.Helper;
using LoginBaseApp.Models;
using LoginBaseApp.Service;

namespace LoginBaseApp.Views;

public partial class LoginPage : ContentPage
{
	DBMokup db;
	
	
	public LoginPage()
	{
		
		InitializeComponent();
		db = new DBMokup();
	}

	private void TogglePasswordVisiblity(object sender, EventArgs e)
	{
		Button? visBtn = sender as Button;
		PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
		if (PasswordEntry.IsPassword)
			visBtn!.Text= FontHelper.CLOSED_EYE_ICON;
		else
			visBtn!.Text = FontHelper.OPEN_EYE_ICON;



	}

	private void OnLoginClick(object sender, EventArgs e)
	{

		if (db.Login(UsernameEntry.Text, PasswordEntry.Text))
		{
			errorLbl.IsVisible = false;
			errorLbl.Text = "התחברת";
			errorLbl.TextColor = Colors.Green;
			// Navigate to the next page or perform any other action
		}
		else
		{
			errorLbl.IsVisible = false;
			errorLbl.Text = "שגיאת התחברות";
			errorLbl.TextColor = Colors.Red;
		}


	}
}