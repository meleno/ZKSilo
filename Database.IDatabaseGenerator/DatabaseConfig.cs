using System;

namespace Database.IDatabaseGenerator
{
	public struct DatabaseConfig : IEquatable<DatabaseConfig>
	{
		public string ServerAddress { get; set; }

		public ConnectionType ConnectionType { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public bool UseSSL { get; set; }

		public bool AcceptAllCertificates { get; set; }

		public string DatabaseName { get; set; }

		public ServerType ServerType { get; set; }

		public int DatabaseId { get; set; }

		public bool Equals(DatabaseConfig other)
		{
			return DatabaseId == other.DatabaseId;
		}

		public override int GetHashCode()
		{
			return DatabaseId.GetHashCode();
		}

		
	}
}
