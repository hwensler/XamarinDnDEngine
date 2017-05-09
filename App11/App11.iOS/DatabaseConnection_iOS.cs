﻿﻿using App11.iOS;
using SQLite;
using System;
using System.IO;
using App11.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]

namespace App11.iOS
{
	public class DatabaseConnection_iOS : IDatabaseConnection
	{
		public SQLiteConnection DbConnection()
		{
			var dbName = "CustomersDb.db3";
			string personalFolder =
			  System.Environment.
			  GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryFolder =
			  Path.Combine(personalFolder, "..", "Library");
			var path = Path.Combine(libraryFolder, dbName);
			return new SQLiteConnection(path);
		}
	}
}