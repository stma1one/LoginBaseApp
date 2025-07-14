
using LoginBaseApp.Helper;
using LoginBaseApp.Models;
using LoginBaseApp.Service;

namespace LoginBaseApp.Views;

public partial class LoginPage : ContentPage
{
	DBMokup db;
	private string _userName;
	private string _password;

	public string UserName{
		get => _userName;
		set
		{
			if (_userName != value)
			{
				_userName = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsEnabled));
			}
		}
		}
	public string Password
	{
		get => _password;
		set
		{
			if (_password != value)
			{
				_password = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsEnabled));
			}
		}
	}
	
	public bool IsEnabled
	{
		get => (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password));
	}

	public LoginPage()
	{
		
		InitializeComponent();
		db = new DBMokup();
		BindingContext = this;
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

			errorLbl.IsVisible = false;
		if (db.Login(UsernameEntry.Text, PasswordEntry.Text))
		{
			errorLbl.Text = "התחברת";
			errorLbl.TextColor = Colors.Green;
			// Navigate to the next page or perform any other action
		}
		else
		{
			errorLbl.Text = "שגיאת התחברות";
			errorLbl.TextColor = Colors.Red;
		}


	}
}