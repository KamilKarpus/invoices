using System.Data;

namespace Infrastructure
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }
}