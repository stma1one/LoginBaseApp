using LoginBaseApp.Helper;
using LoginBaseApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginBaseApp.ViewModels
{
  public class LoginPageViewModel: ViewModelBase
	{
		ILoginService db;
		private string _userName;
		private string _password;


		public string UserName
		{
			get => _userName;
			set
			{
				if (_userName != value)
				{
					_userName = value;
					OnPropertyChanged();
					//OnPropertyChanged(nameof(IsEnabled));
					(LoginCommand as Command).ChangeCanExecute();


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
					//OnPropertyChanged(nameof(IsEnabled));
					(LoginCommand as Command).ChangeCanExecute();
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
				if (isPassword != value)
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


		//public bool IsEnabled
		//{
		//	get => (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password));
		//}

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

		public LoginPageViewModel(ILoginService service)
		{
			db = service;
			ShowPasswordCommand = new Command(TogglePasswordVisiblity);
			LoginCommand = new Command(Login, CanLogin);//()=> (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password)));
			ShowPasswordIcon = FontHelper.CLOSED_EYE_ICON;
			
		}

		public bool CanLogin()
		{
			return (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password));
		}
		

		public ICommand ShowPasswordCommand
		{
			get;
		}

		public ICommand LoginCommand
		{
			get;
		}
		private void TogglePasswordVisiblity()
		{

			IsPassword = !IsPassword;
			if (IsPassword)
				ShowPasswordIcon = FontHelper.CLOSED_EYE_ICON;
			else
				ShowPasswordIcon = FontHelper.OPEN_EYE_ICON;



		}
		private void Login()
		{

			IsBusy = true;
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
			IsBusy = false;


		}

	}
}
