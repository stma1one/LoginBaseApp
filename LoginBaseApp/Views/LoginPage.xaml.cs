
using LoginBaseApp.Models;
using LoginBaseApp.Service;

namespace LoginBaseApp.Views;

public partial class LoginPage : ContentPage
{
	DBMokup db;
	User user;
	private string _username;
	private string _password;

	public string Username
	{
		get => _username;
		set
		{
			_username = value;
			OnPropertyChanged(nameof(Username));
			OnPropertyChanged(nameof(LoginEnabled));
		}
	}
	public string Password
	{
		get => _password;
		set
		{
			_password = value;
			OnPropertyChanged(nameof(Password));
			OnPropertyChanged(nameof(LoginEnabled));
		}
	}

	public bool LoginEnabled
	{
		get => !(string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text));
		
	}
	public LoginPage()
	{
		
		InitializeComponent();
		BindingContext = this;
		db = new DBMokup();
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

	private void OnLoginClick(object sender, EventArgs e)
	{

		if (db.Login(Username, Password))
		{
			DisplayAlert("Login Successful", "Welcome " + Username, "OK");
			// Navigate to the next page or perform any other action
		}
		else
		{
			DisplayAlert("Login Failed", "Invalid username or password", "OK");
		}


	}
}