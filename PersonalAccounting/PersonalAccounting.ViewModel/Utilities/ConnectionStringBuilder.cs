using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Utilities
{
    public static class ConnectionStringBuilder
    {
        public static string CreateString(
            string serverName,
            string databaseName,
            string username,
            string password
)
        {
            return @"metadata=res://*/Model.Model1.csdl|res://*/Model.Model1.ssdl|res://*/Model.Model1.msl;" +
                   @"provider=System.Data.SqlClient;" +
                   @"provider connection string=""" +
                   $@"data source={serverName};" +
                   $@"initial catalog={databaseName};" +
                   $@"user id = {username};" +
                   $@"password = {password};" +
                   @"trustservercertificate=True;" +
                   @"MultipleActiveResultSets=True;" +
                   @"""";
        }
    }
}
