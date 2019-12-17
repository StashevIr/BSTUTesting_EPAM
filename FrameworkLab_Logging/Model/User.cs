using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkLab
{
	public class User
	{
		private readonly string _username;
		private readonly string _password;

		public User(string username, string password)
		{
			_username = username;
			_password = password;
		}

		public string GetUsername() { return _username; }
		public string GetPassword() { return _password; }
	}
}
