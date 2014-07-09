using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Data;
using System.Data.Common;

//Data providers namespace
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data.Odbc;


namespace Support.DataBases.Provider
{
    public class DataHelper: DataAbstraction, IDisposable
    {
        public override DbConnection Connection { get; set; }
        public override DbCommand Command { get; set; }
        public override DbTransaction Transaction { get; set; }
        public override bool BeginTransaction { get; set; }

        public String ExceptionMessage { get; set; }
        private String SufixParameter { get; set; }

        public DataHelper (DataAbstraction.DataProvider Provider, string ConnectionString, bool BeginTransaction = false)
        {
            this.Open(Provider, ConnectionString, BeginTransaction);
        }

        protected override void Open(DataAbstraction.DataProvider Provider, string ConnectionString, bool BeginTransaction = false)
        {
            this.BeginTransaction = BeginTransaction;
            switch (Provider)
            {
                case DataProvider.SQLServer:
                    this.Connection = new SqlConnection(ConnectionString);
                    break;
                case DataProvider.Oracle:
                    break;
                case DataProvider.DB2:
                    break;
                case DataProvider.MySQL:
                    //this.Connection = new MySqlConnection(ConnectionString);
                   break;
                case DataProvider.Postgres:
                    break;
                case DataProvider.SQLLite:
                    break;
                case DataProvider.Oracle10gExpress:
                    break;
                case DataProvider.DB2Express:
                    break;
                case DataProvider.OLEDB:
                    this.Connection = new OleDbConnection(ConnectionString);
                    break;
                case DataProvider.ODBC:
                    this.Connection = new OdbcConnection(ConnectionString);
                    break;
            }
            try
            {
                this.Connection.Open();
                if (this.BeginTransaction)
                    this.Transaction = this.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void Close()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
            if (Transaction!=null)
            {
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public override System.Data.Common.DbDataReader ReadData(string SQLStatement, System.Data.CommandType Type, params DataParameter[] Parameters)
        {
            DbDataReader dr = null;
            if (Connection!=null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    DbCommand cmd = null;
                    if (Connection is SqlConnection)
                        cmd = new SqlCommand(SQLStatement, (SqlConnection)Connection);
                    //else if (Connection is MySqlConnection)
                        //cmd = new SqlCommand(SQLStatement, (MySqlConnection)Connection);
                    cmd.CommandType = Type;
                    foreach (DataParameter prmItem in Parameters)
                    {
                        DbParameter prmNewParameter = null;
                        if (cmd is SqlCommand)
                        {
                            prmNewParameter = new SqlParameter();
                            SufixParameter = "@";
                        }
                        //else if (cmd is MySqlCommand)
                        //{
                        //    prmNewParameter = new MySqlParameter();
                        //    SufixParameter = "prm";
                        //}

                        prmNewParameter.ParameterName = SufixParameter + prmItem.ParameterName;
                        prmNewParameter.Value = prmItem.Value;
                        cmd.Parameters.Add(prmNewParameter);

                    }
                    try
                    {
                        dr = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage = ex.Message;
                    }
                   
                }
            }
            return dr;
        }


        public override void Execute (string SQLStatemet, System.Data.CommandType Type, params DataParameter[] Parameters)
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    DbCommand cmd = null;
                    if (Connection is SqlConnection)
                    {
                        if (Transaction != null)
                            cmd = new SqlCommand(SQLStatemet, (SqlConnection)Connection, (SqlTransaction)Transaction);
                        else
                            cmd = new SqlCommand(SQLStatemet, (SqlConnection)Connection);
                    }

                    //if (Connection is MySqlConnection)
                    //    cmd = new MySqlCommand(SQLStatemet, (MySqlConnection)Connection);

                    cmd.CommandType = Type;
                    foreach (DataParameter prmItem in Parameters)
                    {
                        DbParameter prmNewParameter = null;
                        if (cmd is SqlCommand)
                        {
                            prmNewParameter = new SqlParameter();
                            SufixParameter = "@";
                        }
                        //else if (cmd is MySqlCommand)
                        //{
                        //    prmNewParameter = new MySqlParameter();
                        //    SufixParameter = "prm";
                        //}
                        prmNewParameter.ParameterName = SufixParameter + prmItem.ParameterName;
                        prmNewParameter.Value = prmItem.Value;
                        prmNewParameter.Direction = prmItem.Direction;
                        cmd.Parameters.Add(prmNewParameter);
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();

                        Int32 intIndex = 0;
                        foreach (DbParameter prmItem in cmd.Parameters)
                        {
                            if (prmItem.Direction == ParameterDirection.Output || prmItem.Direction == ParameterDirection.InputOutput)
                            {
                                Parameters[intIndex].Value = prmItem.Value;
                            }
                            intIndex++;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public override void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
            }
        }

        public override void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            this.Close();
        }

    }
}