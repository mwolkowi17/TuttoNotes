﻿using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using TuttoNotes.Droid;

[assembly: Dependency(typeof(SQLiteDb))]

namespace TuttoNotes.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}

