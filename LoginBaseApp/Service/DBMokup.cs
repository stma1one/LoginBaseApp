using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBaseApp.Service
{
	public class DBMokup
	{
		List<Models.User> users = new List<Models.User>();

		public DBMokup()
		{
			users.Add(new Models.User { Username = "admin", Password = "admin" });
			users.Add(new Models.User { Username = "user1", Password = "password1" });
			users.Add(new Models.User { Username = "user2", Password = "password2" });
		}

		public bool Login(string username, string password)
		{
			var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
			return user != null;
		}
	}
}
