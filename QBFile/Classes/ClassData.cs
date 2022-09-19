using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace QBFile.Classes
{
    public class ClassData : ClassQuery
    {
        private string rmstr;
        
        public ClassData()
        {
            LoadConfigurations();

            rmstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + rmpath +
                        ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
        }

        #region "Variables"

        public string repyear { get; set; }
        public string repmonth { get; set; }
        public string datestart { get; set; }
        public string dateend { get; set; }
        public string transdate { get; set; }

        public DateTime strdate { get; set; }
        public DateTime enddate { get; set; }
        public Int64 sessnum { get; set; }
        public Int64 sessnum1 { get; set; }

        public int cattype { get; set; }
        public double catprice1 { get; set; }
        public double catpricetotal { get; set; }
        public double lvdiscadj { get; set; }
        public double taxes { get; set; }
        public double sc { get; set; }
        public int mopnum { get; set; }
        public double mopprice { get; set; }
        public string classdesc { get; set; }
        public string classcust { get; set; }
        public string abb { get; set; }
        public double itemdisc { get; set; }
        public double checkdisc { get; set; }
        public double totaldisc { get; set; }
        public double os { get; set; }
        //MDB
        public string catdesc { get; set; }
        public double scatprice { get; set; }
        public string mopdesc { get; set; }
        public double smopprice { get; set; }
        public double catsum { get; set; }
        public double mopsum { get; set; }
        public double bookysum { get; set; }
        public double jk { get; set; }
        public double kj { get; set; }
        public double getcatsum { get; set; }
        public double getmopsum { get; set; }
        public double getoos { get; set; }
        public double Gtxt { get; set; }

        //public double catprice2 { get; set; }
        //public double catprice3 { get; set; }
        //public double catpricetotal { get; set; }

        public StreamWriter txtfile;

        #endregion

        #region "File Creation"

        public void GetSession()
        {
            enddate = Convert.ToDateTime(dateend);
            strdate = Convert.ToDateTime(datestart);
            repyear = strdate.ToString("yy");
            
                using (OleDbConnection rmconn = new OleDbConnection(rmstr))
                {
                    rmconn.Open();
                    OleDbCommand oleCmd = new OleDbCommand("SELECT SESSION_NO FROM REP" + repyear +
                                                           " WHERE date_start = #" + strdate + "# AND first_bill > 0 and last_bill > 0", rmconn);
                    dbdr = oleCmd.ExecuteReader();
                    if (dbdr.HasRows)
                    {
                        dbdr.Read();
                        sessnum = Convert.ToInt64(dbdr.GetValue(0).ToString());
                    }

                    oleCmd = new OleDbCommand("SELECT SESSION_NO FROM REP" + repyear +
                                                " WHERE date_start = #" + enddate + "# AND first_bill > 0 and last_bill > 0", rmconn);
                    dbdr = oleCmd.ExecuteReader();
                    if (dbdr.HasRows)
                    {
                        dbdr.Read();
                        sessnum1 = Convert.ToInt64(dbdr.GetValue(0).ToString());
                    }
                }

                repmonth = strdate.ToString("MM");

                txtfile = new StreamWriter(folderpath + "\\" + branchdesc + "_" + strdate.ToString("MMM dd, yyyy-") + enddate.ToString("MMM dd, yyyy") + ".txt");
                txtfile.WriteLine("Customer\tTransaction Date\tRefNumber\tClass\tItem\tPrice\tDeposit To\tVat");

                GetData();

                txtfile.Close();
        }

        public void GetData()
        {
            //Branch
            using (OleDbConnection rmconn = new OleDbConnection(mdbpath))
            {
                rmconn.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from tblConfig", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    classdesc = (!DBNull.Value.Equals(dbdr[1])) ? Convert.ToString(dbdr[1].ToString()) : " ";
                    classcust = (!DBNull.Value.Equals(dbdr[2])) ? Convert.ToString(dbdr[2].ToString()) : " ";
                }
                rmconn.Close();
            }
            //Sales Category DBF
            using (OleDbConnection rmconn = new OleDbConnection(rmstr))
            {
                rmconn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT b.Session_No, d.Page_Type, " +
                                "Sum(a.quanty * a.raw_price) " +
                                "FROM (((sdet" + repmonth + repyear + " a " +
                                "LEFT JOIN sls" + repmonth + repyear + " b ON a.bill_no = b.bill_no) " +
                                "LEFT JOIN menu c ON c.ref_no = a.ref_no) " +
                                "LEFT JOIN pages d ON d.page_num = c.page_num) " +
                                "LEFT JOIN pagetype e ON e.page_type = d.page_type " +
                                "WHERE b.pay_type <> 5 and b.Session_No BETWEEN " + sessnum + " AND " + sessnum1 + " " +
                                "GROUP BY d.Page_Type, b.Session_No", rmconn);

                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    while (dbdr.Read())
                    {
                        cattype = (!DBNull.Value.Equals(dbdr[1])) ? Convert.ToInt32(dbdr[1].ToString()) : 0;
                        catprice1 = (!DBNull.Value.Equals(dbdr[2])) ? Convert.ToDouble(ReturnData(dbdr[2].ToString())) : 0;

                        transdate = enddate.ToString("MM/dd/yyyy");

                        SaveFile();
                    }
                }
                rmconn.Close();
            }
            //Sales Category MDB
            using (OleDbConnection rmconn = new OleDbConnection(mdbpath))
            {
                rmconn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT tblCategory.catID, tblCategory.catdesc, Sum(tblSaveCat.scatprice) FROM tblCategory INNER JOIN tblSaveCat ON tblCategory.catID=tblSaveCat.scatID GROUP BY tblCategory.catID, tblCategory.catdesc", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    while (dbdr.Read())
                    {
                        catdesc = (!DBNull.Value.Equals(dbdr[1])) ? Convert.ToString(dbdr[1].ToString()) : " ";
                        scatprice = (!DBNull.Value.Equals(dbdr[2])) ? Convert.ToDouble(ReturnData(dbdr[2].ToString())) : 0;
                        CreateFile();
                    }
                }
                rmconn.Close();
            }
            //VAT and SC
            using (OleDbConnection rmconn1 = new OleDbConnection(rmstr))
            {
                rmconn1.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Sum(Taxes) FROM sls" + repmonth + repyear + " WHERE pay_type <> 5 AND Session_No BETWEEN " + sessnum + " AND " + sessnum1 + "", rmconn1);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    taxes = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                    CreateFile2();
                }

                cmd = new OleDbCommand("SELECT Sum(b.TIP_AMT) FROM sls" + repmonth + repyear + " a LEFT JOIN pmt" + repmonth + repyear + " b ON a.bill_no=b.bill_no WHERE b.pay_type <> 5 AND a.Session_No BETWEEN " + sessnum + " AND " + sessnum1 + "", rmconn1);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    sc = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                    CreateFile5();
                }

                rmconn1.Close();
            }
            //Total Discounts
            using (OleDbConnection rmconn = new OleDbConnection(rmstr))
            {
                rmconn.Open();
                //itemdisc
                OleDbCommand cmd = new OleDbCommand("SELECT ABS(Sum(a.ITEM_ADJ * a.QUANTY)) as ITD FROM sdet" + repmonth + repyear + " a LEFT JOIN sls"+ repmonth + repyear + " b ON a.BILL_NO=b.BILL_NO WHERE b.PAY_TYPE <> 5 AND b.SESSION_NO BETWEEN " + sessnum + " AND " + sessnum1 + " ", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    itemdisc = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                }
                //checkdisc
                cmd = new OleDbCommand("SELECT Sum(a.DISCOUNT) as CTD FROM sls" + repmonth + repyear + " a WHERE a.PAY_TYPE <> 5 AND a.SESSION_NO BETWEEN " + sessnum + " AND " + sessnum1 + " ", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    checkdisc = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                }
                totaldisc = (itemdisc + checkdisc);
                CreateFile1();
                rmconn.Close();
            }
            //Method of Payment DBF
            using (OleDbConnection rmconn2 = new OleDbConnection(rmstr))
            {
                rmconn2.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT t.TPAGO_NO, Sum(p.base_amt + p.tip_amt) " +
                    "FROM (SLS" + repmonth + repyear + " s " +
                    "LEFT JOIN PMT" + repmonth + repyear + " p" + " ON s.bill_no = p.bill_no) " + 
                    "LEFT JOIN TIPOPAG t ON p.pay_type = t.tpago_no " +
                    "WHERE p.pay_type <> 5 and s.Session_No BETWEEN " + sessnum + " AND " + sessnum1 + " " +
                    "GROUP BY s.Session_No, p.pay_type, t.TPAGO_NO", rmconn2);
                dbdr = cmd.ExecuteReader();
                if(dbdr.HasRows)
                {
                    while (dbdr.Read())
                    {
                        mopnum = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToInt32(dbdr[0].ToString()) : 0;
                        mopprice = (!DBNull.Value.Equals(dbdr[1])) ? Convert.ToDouble(ReturnData(dbdr[1].ToString())) : 0;
                        SaveFile3();
                    }
                }
                rmconn2.Close();
            }
            //Method of Payment MDB
            using (OleDbConnection rmconn = new OleDbConnection(mdbpath))
            {
                rmconn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT tblMOP.mopID, tblMOP.mopdesc, Sum(tblSaveMOP.smopprice) FROM tblMOP INNER JOIN tblSaveMOP ON tblMOP.mopID=tblSaveMOP.smopID GROUP BY tblMOP.mopID, tblMOP.mopdesc", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    while (dbdr.Read())
                    {
                        mopdesc = (!DBNull.Value.Equals(dbdr[1])) ? Convert.ToString(dbdr[1].ToString()) : " ";
                        smopprice = (!DBNull.Value.Equals(dbdr[2])) ? Convert.ToDouble(ReturnData(dbdr[2].ToString())) : 0;
                        CreateFile3();
                    }
                }
                rmconn.Close();
            }
            //Over or Short
            using (OleDbConnection rmconn = new OleDbConnection(mdbpath))
            {
                rmconn.Open();
                //Sales Category Sum except Booky
                OleDbCommand cmd = new OleDbCommand("SELECT Sum(scatprice) FROM tblSaveCat WHERE scatID <> 9", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    catsum = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                }
                //Booky
                cmd = new OleDbCommand("SELECT Sum(scatprice) FROM tblSaveCat WHERE scatID = 9", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    bookysum = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                }
                //Method of Payment Sum
                cmd = new OleDbCommand("SELECT Sum(smopprice) FROM tblSaveMOP", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    mopsum = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                }

                jk = (catsum + taxes + sc);
                kj = (totaldisc + (mopsum - bookysum));

                SaveFile4();

                //GetOverOrShortAmount
                cmd = new OleDbCommand("SELECT catsumup, mopsumup FROM tblOvershort", rmconn);
                dbdr = cmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    getcatsum = (!DBNull.Value.Equals(dbdr[0])) ? Convert.ToDouble(ReturnData(dbdr[0].ToString())) : 0;
                    getmopsum = (!DBNull.Value.Equals(dbdr[1])) ? Convert.ToDouble(ReturnData(dbdr[1].ToString())) : 0;
                }

                getoos = (getcatsum - getmopsum);

                if (getcatsum > getmopsum)
                {
                    Gtxt = (getoos * -1);
                }
                else if (getcatsum <= getmopsum)
                {
                    Gtxt = (getoos);
                }

                CreateFile4();

                rmconn.Close();
            }
        }
        #endregion

        #region "Write and Save Files"
        //Save Sales Category
        public void SaveFile()
        {
            openConn();
            cmd = new OleDbCommand("Insert into tblSaveCat (scatID, scatprice) values(" + string.Format("{0:0.##}", cattype) + ", " + string.Format("{0:0.##}", catprice1) + ")", con);
            cmd.ExecuteNonQuery();
            closeConn();
        }
        //Save Method of Payment
        public void SaveFile3()
        {
            openConn();
            cmd = new OleDbCommand("Insert into tblSaveMOP (smopID, smopprice) values(" + string.Format("{0:0.##}", mopnum) + ", " + string.Format("{0:0.##}", mopprice) + ")", con);
            cmd.ExecuteNonQuery();
            closeConn();
        }
        //Save Over or Short
        public void SaveFile4()
        {
            openConn();
            cmd = new OleDbCommand("Insert into tblOvershort (catsumup, mopsumup) values(" + string.Format("{0:0.##}", jk) + ", " + string.Format("{0:0.##}", kj) + ")", con);
            cmd.ExecuteNonQuery();
            closeConn();
        }
        //Write Sales Category
        public void CreateFile()
        {
            txtfile.WriteLine(classcust + "\t" + transdate + "\t" + "" + "\t" + classdesc + "\t" + catdesc + "\t" + string.Format("{0:#,##0.#0}", scatprice) + "\t" + "" + "\t" + "Non");
        }
        //Write Total Discounts
        public void CreateFile1()
        {
            txtfile.WriteLine(classcust + "\t" + transdate + "\t" + "" + "\t" + classdesc + "\t" + "Total Discounts" + "\t" + string.Format("{0:#,##0.#0}", (totaldisc * -1)) + "\t" + "" + "\t" + "Non");
        }
        //Write Vat
        public void CreateFile2()
        {
            txtfile.WriteLine(classcust + "\t" + transdate + "\t" + "" + "\t" + classdesc + "\tvat 12% (vat 12%)\t" + string.Format("{0:#,##0.#0}", taxes) + "\t" + "" + "\t" + "Non");
        }
        //Write SC
        public void CreateFile5()
        {
            txtfile.WriteLine(classcust + "\t" + transdate + "\t" + "" + "\t" + classdesc + "\tService Charge collected\t" + string.Format("{0:#,##0.#0}", sc) + "\t" + "" + "\t" + "Non");
        }
        //Write Method of Payment
        public void CreateFile3()
        {
            txtfile.WriteLine(classcust + "\t" + transdate + "\t" + "" + "\t" + classdesc + "\t" + mopdesc + "\t" + string.Format("{0:#,##0.#0}", (smopprice * -1)) + "\t" + "");
        }
        //Write Over or Short
        public void CreateFile4()
        {
            txtfile.WriteLine(classcust + "\t" + transdate + "\t" + "" + "\t" + classdesc + "\tOver or Short\t" + string.Format("{0:#,##0.#0}", Gtxt) + "\t" + "");
        }
        #endregion

        //Return a Value if Value is null
        public Double ReturnData(string param)
        {
            if(param != "")
            {
                return Convert.ToDouble(param);
            }
            else
            {
                return 0;
            }
        }
    }

    #region "Unused"
    //OleDbCommand abc = new OleDbCommand("Select page_type from pagetype", rmconn);
    //OleDbDataAdapter da = new OleDbDataAdapter(abc);
    //DataTable dttable = new DataTable();
    //da.Fill(dttable);

    //foreach (DataRow dr in dttable.Rows)
    //{

    //}" AND d.page_type = " + dr["page_type"] + 
    #endregion
}
