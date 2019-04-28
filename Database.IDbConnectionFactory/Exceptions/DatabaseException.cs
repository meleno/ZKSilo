using System;

namespace Database.IDbConnectionFactory.Exceptions
{
	public class DatabaseException : ApplicationException
	{
		public int ErrorCode { get; private set; }

		public DatabaseException(string message, Exception inner, int errorCode) : base(message, inner)
		{
			ErrorCode = errorCode;
		}
	}
}
