
using LoginBaseApp.Models;

namespace LoginBaseApp.Views;

public partial class LoginPage : ContentPage
{
	User user;
	public LoginPage()
	{
		InitializeComponent();
	}

	private void TogglePasswordVisiblity(object sender, EventArgs e)
	{
		Button visBtn = sender as Button;
		PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
		if (PasswordEntry.IsPassword)
			visBtn.Text = "\ue8f5";
		else
			visBtn.Text = "\ue8f4";



	}
}