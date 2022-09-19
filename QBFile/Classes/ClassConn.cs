using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace QBFile.Classes
{
    public class ClassConn
    {
        #region "Declaration"

        public OleDbConnection con;
        public OleDbConnection rmcon;
        public OleDbCommand cmd;
        public OleDbCommand lessvatcmd;
        public OleDbDataReader dbdr;
        public OleDbDataAdapter fillcmb;
        public OleDbDataAdapter ldbrand;
        public OleDbDataAdapter ldmop;
        public OleDbDataAdapter ldcat;
        public OleDbDataAdapter rmldmop;
        public OleDbDataAdapter rmldcat;

        public string rmpath { get; set; }
        public string mdbpath;

        #endregion

        #region "Query"

        public ClassConn()
        {
            mdbpath = @"Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=|DataDirectory|\Preferences\QB.mdb;Jet OLEDB:Database Password=cpos6163";
        }

        public void openConn()
        {
            con = new OleDbConnection(mdbpath);
            //closeConn();
            if (con.State == ConnectionState.Closed)
            {
                con = new OleDbConnection(mdbpath);
                con.Open();
            }
        }

        public void closeConn()
        {
            con.Close();
            con.Dispose();
        }

        public void getRMCon()
        {
            string str;
            str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + rmpath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
            rmcon = new OleDbConnection(str);
            if (rmcon.State == ConnectionState.Closed)
            {
                rmcon = new OleDbConnection(str);
                rmcon.Open();
            }
        }

        public void LoadComboBox(string sql)
        {
            //fillcmb = new OleDbDataAdapter();
            openConn();
            fillcmb = new OleDbDataAdapter(sql,con);
        }

        public void LoadClass(string sql)
        {
            openConn();
            ldbrand = new OleDbDataAdapter(sql, con);
        }

        public void LoadMOP(string sql1)
        {
            openConn();
            ldmop = new OleDbDataAdapter(sql1, con);
        }

        public void LoadCAT(string sql2)
        {
            openConn();
            ldcat = new OleDbDataAdapter(sql2, con);
        }

        public void RMLoadMOP(string rmsql1)
        {
            rmldmop = new OleDbDataAdapter(rmsql1, rmcon);
        }

        public void RMLoadCAT(string rmsql2)
        {
            rmldcat = new OleDbDataAdapter(rmsql2, rmcon);
        }

        #endregion

        #region "Unused"
        //string ConnectionString = "";
        //SqlConnection con;

        //public void OpenConnection()
        //{
        //    con = new SqlConnection(ConnectionString);
        //    con.Open();
        //}

        //public void CloseConnection()
        //{
        //    con.Close();
        //}

        //public void ExecuteQueries(string Query_)
        //{
        //    SqlCommand cmd = new SqlCommand(Query_, con);
        //    cmd.ExecuteNonQuery();
        //}

        //public SqlDataReader DataReader(string Query_)
        //{
        //    SqlCommand cmd = new SqlCommand(Query_, con);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //}
        #endregion
    }
}
