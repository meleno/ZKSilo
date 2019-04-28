using System;

namespace Database.IDb.ConnectionFactory.Exceptions
{
	public class DatabaseServerNotSupportedException : DatabaseException
	{
		public DatabaseServerNotSupportedException(string message, Exception inner, int errorCode) : base(message, inner, errorCode)
		{ }
	}
}
