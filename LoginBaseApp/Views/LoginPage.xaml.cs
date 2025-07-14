
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

	private bool messageIsVisible;

	public bool MessageIsVisible
	{
		get
		{
			// Return the current visibility state of the message
			return messageIsVisible;
		}
		set
		{
			if (messageIsVisible != value)
			{
				messageIsVisible = value;
				OnPropertyChanged();
			}
			}
	}
	private Color messageColor;

	public Color MessageColor
	{
		get
		{
			return messageColor;
		}
		set
		{
			if (messageColor != value)
			{
				messageColor = value;
				OnPropertyChanged();
			}
		}
	}

	private bool isPassword;

	public bool IsPassword
	{
		get
		{
			return isPassword;
		}
		set
		{
			if(isPassword != value)
			{
				isPassword = value;
				OnPropertyChanged();
			}
			
		}
	}

	private string showPasswordIcon;

	public string ShowPasswordIcon
	{
		get
		{
			return showPasswordIcon;
		}
		set
		{
			if (showPasswordIcon != value)
			{
			showPasswordIcon = value;
				OnPropertyChanged();
			}
		}
	}


	public bool IsEnabled
	{
		get => (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password));
	}

	private string loginMessage;

	public string LoginMessage
	{
		get
		{
			return loginMessage;
		}
		set
		{
			if (loginMessage != value)
			{
				loginMessage = value;
				OnPropertyChanged();
			}
		}
	}

	public LoginPage()
	{
		
		InitializeComponent();
		db = new DBMokup();
		BindingContext = this;
	}

	private void TogglePasswordVisiblity(object sender, EventArgs e)
	{
		
		IsPassword = !IsPassword;
		if (IsPassword)
			ShowPasswordIcon= FontHelper.CLOSED_EYE_ICON;
		else
			ShowPasswordIcon = FontHelper.OPEN_EYE_ICON;



	}

	private void OnLoginClick(object sender, EventArgs e)
	{
		//אם עובדים BINDING מומלץ לא לעבוד עם x:Name מטעמי קריאות ולהמיר הכל לBINIDNG
		MessageIsVisible = true;
		if (db.Login(UserName, Password))
		{
			LoginMessage = AppMessages.LoginMessage;
			MessageColor = Colors.Green;
			// Navigate to the next page or perform any other action
		}
		else
		{
			LoginMessage = AppMessages.LoginErrorMessage;
			MessageColor = Colors.Red;
		}


	}
}