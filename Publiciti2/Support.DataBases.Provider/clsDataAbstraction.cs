using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Data;
using System.Data.Common;


namespace Support.DataBases.Provider
{
    public abstract class DataAbstraction
    {
        public enum DataProvider
        {
            SQLServer,
            Oracle,
            DB2,
            MySQL,
            Postgres,
            SQLLite,
            Oracle10gExpress,
            DB2Express,
            OLEDB,
            ODBC
        }

        public abstract DbConnection Connection { get; set; }
        public abstract DbCommand Command { get; set; }
        public abstract DbTransaction Transaction { get; set; }
        public abstract Boolean BeginTransaction { get; set; }

        protected abstract void Open(DataProvider Provider, String ConnectionString, Boolean BeginTransaction = false);
        protected abstract void Close();
        public abstract DbDataReader ReadData(String SQLStatement, CommandType Type, params DataParameter[] Parameters);
        public abstract void Execute(String SQLStatement, CommandType Type, params DataParameter[] Parameters);
        public abstract void Commit();
        public abstract void RollBack();

    }
}