using System;

namespace Database.IDbConnectionFactory.Exceptions
{
	public class DatabaseServerNotSupportedException : DatabaseException
	{
		public DatabaseServerNotSupportedException(string message, Exception inner, int errorCode) : base(message, inner, errorCode)
		{ }
	}
}
