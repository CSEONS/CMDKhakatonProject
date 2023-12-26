using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace VolgaIt
{
    public class Config
    {
        public static string ConnectionString {  get; set; }
        public static double AccesTokenExpiredTimePerMinute { get; internal set; }
        public static double RefreshTokenExpiredTimePerDays { get; internal set; }
    }
}