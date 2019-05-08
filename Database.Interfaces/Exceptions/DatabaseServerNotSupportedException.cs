using System;

namespace Database.IDatabase.Exceptions
{
	public class DatabaseServerNotSupportedException : DatabaseException
	{
		public DatabaseServerNotSupportedException(string message, Exception inner = null) : base(message, 1001, inner)
		{ }
	}
}
