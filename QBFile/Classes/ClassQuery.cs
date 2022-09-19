using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace QBFile.Classes
{
    public class ClassQuery : ClassConn
    {
        #region "Variables"

        public string adcode { get; set; }
        public string uscode { get; set; }
        public string seancode { get; set; }
        public string folderpath { get; set; }
        public string clscust { get; set; }
        public string clsdesc { get; set; }
        public string branchdesc { get; set; }

        public DataSet dsclsdesc { get; set; }
        public DataSet dsclscust { get; set; }
        public DataTable dtbrand { get; set; }
        public DataTable dtmop { get; set; }
        public DataTable dtcat { get; set; }
        public DataTable rmdtmop { get; set; }
        public DataTable rmdtcat { get; set; }

        #endregion

        #region "Queries"

        public void AuthUser()
        {
            using (OleDbConnection mdbcon = new OleDbConnection(mdbpath))
            {
                mdbcon.Open();
                cmd = new OleDbCommand("Select * from tblSecurity", mdbcon);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    adcode = dbdr.GetValue(1).ToString();
                    uscode = dbdr.GetValue(2).ToString();
                    seancode = dbdr.GetValue(3).ToString();
                }
            }
        }

        public void LoadConfigurations()
        {
            using (OleDbConnection mdbcon = new OleDbConnection(mdbpath))
            {
                mdbcon.Open();
                cmd = new OleDbCommand("Select * from tblConfig", mdbcon);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();

                    clsdesc = dbdr.GetValue(1).ToString();
                    clscust = dbdr.GetValue(2).ToString();
                    rmpath = dbdr.GetValue(3).ToString();
                    folderpath = dbdr.GetValue(4).ToString();
                    branchdesc = dbdr.GetValue(5).ToString();
                }
            }
        }

        public void GetClassDesc()
        {
            LoadComboBox("Select classdesc from tblClass");
            dsclsdesc = new DataSet();
            fillcmb.Fill(dsclsdesc);
        }

        public void GetClassCust()
        {
            LoadComboBox("Select classcustomer from tblClass");
            dsclscust = new DataSet();
            fillcmb.Fill(dsclscust);
        }

        public void LoadDGVClass()
        {
            LoadClass("Select classdesc as [Class Description], classcustomer as [Class Customer] from tblClass");
            dtbrand = new DataTable();
            ldbrand.Fill(dtbrand);
        }
        //mdb
        public void LoadDGVMOP()
        {
            LoadMOP("Select mopID as [ID], mopdesc as [Quick Book Description] from tblMOP Order by mopID");
            dtmop = new DataTable();
            ldmop.Fill(dtmop);
        }
        //dbf
        public void RMLoadDGVMOP()
        {
            LoadConfigurations();
            getRMCon();
            RMLoadMOP("Select TPAGO_NO as [RM Plu], TPAGO_NAME as [RM POS] from TIPOPAG Order by TPAGO_NO");
            rmdtmop = new DataTable();
            rmldmop.Fill(rmdtmop);
        }
        //mdb
        public void LoadDGVCAT()
        {
            LoadCAT("Select catID as [ID], catdesc as [Quick Book Description] from tblCategory Order by catID");
            dtcat = new DataTable();
            ldcat.Fill(dtcat);
        }
        //dbf
        public void RMLoadDGVCAT()
        {
            LoadConfigurations();
            getRMCon();
            RMLoadCAT("Select PAGE_TYPE as [RM Plu], PAGE_DESC as [RM POS] from PAGETYPE Order by PAGE_TYPE");
            rmdtcat = new DataTable();
            rmldcat.Fill(rmdtcat);
        }

        public void UpdateConfig(string dbpar, OleDbType Ftype, int Fsize, string fld, string Fvalues)
        {
            openConn();
            cmd = new OleDbCommand("UPDATE tblConfig SET " + fld + " = " + dbpar + " ", con);
            cmd.Parameters.Add(dbpar, Ftype, Fsize, fld).Value = Fvalues;
            cmd.ExecuteNonQuery();
            closeConn();
        }

        #endregion

        #region "Unused"

        #endregion
    }
}
