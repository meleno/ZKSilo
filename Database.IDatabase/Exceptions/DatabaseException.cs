using System;

namespace Database.IDatabase.Exceptions
{
	public class DatabaseException : ApplicationException
	{
		public int ErrorCode { get; private set; }

		public DatabaseException(string message, int errorCode, Exception inner = null) : base(message, inner)
		{
			ErrorCode = errorCode;
		}
	}
}
