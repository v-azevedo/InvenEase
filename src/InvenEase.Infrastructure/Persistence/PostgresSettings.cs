using System.Text;

namespace InvenEase.Infrastructure.Persistence;

public class PostgresSettings
{
    public const string SectionName = "PostgresSettings";

    public string Host { get; init; } = null!;
    public int Port { get; init; }
    public string Database { get; init; } = null!;
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string SSLMode { get; init; } = null!;

    public string ConnectionString => new StringBuilder()
        .Append("Host=").Append(Host).Append(';')
        .Append("Port=").Append(Port).Append(';')
        .Append("Database=").Append(Database).Append(';')
        .Append("Username=").Append(Username).Append(';')
        .Append("Password=").Append(Password).Append(';')
        .Append("SSLMode=").Append(SSLMode).Append(';')
        .ToString();
}