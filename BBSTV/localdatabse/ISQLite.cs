using System;
using SQLite.Net;

namespace BBSTV
{
	public interface ISQLite
	{

		SQLiteConnection GetConnection();
	}
}
