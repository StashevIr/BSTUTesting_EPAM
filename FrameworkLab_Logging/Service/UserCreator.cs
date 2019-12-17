using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkLab
{
	public class UserCreator
	{
		public static User WithCredentialsFromProperty()
		{
			return new User(TestDataReader.GetData("User.Username"), TestDataReader.GetData("User.Password"));
		}

		public static User WithNonRegistratedUsername()
		{
			return new User(TestDataReader.GetData("User.ErrorUsername"), TestDataReader.GetData("User.Password"));
		}

		public static User WithErrorPassword()
		{
			return new User(TestDataReader.GetData("User.Username"), TestDataReader.GetData("User.ErrorPassword"));
		}
	}
}
