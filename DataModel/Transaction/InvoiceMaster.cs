using DataAccess;
using DataModel.Master;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel.Transaction
{
    public class InvoiceMaster : Result.Result
    {
        //string invcNum = ConfigurationManager.AppSettings["INVCNUMB"];
        XDocument xdoc;
        #region Properties
        int _MID;
        string _INVCNUMB;
        DateTime _INVCDATE;
        int _JOBID;
        string _VOYAGENO;
        string _VOYAGEDESC;
        string _VESSEL;
        DateTime _ETA;
        DateTime _ETD;
        int _CUSTOMERID;
        string _CUSTOMER;
        string _ADDRESSDESC;
        string _CURRENCY;
        decimal _EXCHANGERATE;
        List<InvoiceTrans> _TransList;
        string _IFLAG;
        string _conStr;
        decimal _INCLUSIVE;
        decimal _TOTALEXCLUSIVE;
        decimal _TOTALTAXAMOUNT;
        string _INVCDATEDISP;
        string _PERINVCNUMB;
        bool _ISRELEASE;
        bool _STATUSID;
        int _SRNO;
        string _ETADISP;
        string _ETDDISP;
        int _totalRows;
        int _totalPages;
        int _pageSize;
        string _DOCSTATUS;

        public int MID
        {
            get
            {
                return _MID;
            }

            set
            {
                _MID = value;
            }
        }

        public string INVCNUMB
        {
            get
            {
                return _INVCNUMB;
            }

            set
            {
                _INVCNUMB = value;
            }
        }

        public DateTime INVCDATE
        {
            get
            {
                return _INVCDATE;
            }

            set
            {
                _INVCDATE = value;
            }
        }

        public string VOYAGENO
        {
            get
            {
                return _VOYAGENO;
            }

            set
            {
                _VOYAGENO = value;
            }
        }

        public string VESSEL
        {
            get
            {
                return _VESSEL;
            }

            set
            {
                _VESSEL = value;
            }
        }

        public DateTime ETA
        {
            get
            {
                return _ETA;
            }

            set
            {
                _ETA = value;
            }
        }

        public DateTime ETD
        {
            get
            {
                return _ETD;
            }

            set
            {
                _ETD = value;
            }
        }

        public string CUSTOMER
        {
            get
            {
                return _CUSTOMER;
            }

            set
            {
                _CUSTOMER = value;
            }
        }

        public string ADDRESSDESC
        {
            get
            {
                return _ADDRESSDESC;
            }

            set
            {
                _ADDRESSDESC = value;
            }
        }

        public string CURRENCY
        {
            get
            {
                return _CURRENCY;
            }

            set
            {
                _CURRENCY = value;
            }
        }

        public decimal EXCHANGERATE
        {
            get
            {
                return _EXCHANGERATE;
            }

            set
            {
                _EXCHANGERATE = value;
            }
        }

        public List<InvoiceTrans> TransList
        {
            get
            {
                return _TransList;
            }

            set
            {
                _TransList = value;
            }
        }

        public string IFLAG
        {
            get
            {
                return _IFLAG;
            }

            set
            {
                _IFLAG = value;
            }
        }

        public int JOBID
        {
            get
            {
                return _JOBID;
            }

            set
            {
                _JOBID = value;
            }
        }

        public int CUSTOMERID
        {
            get
            {
                return _CUSTOMERID;
            }

            set
            {
                _CUSTOMERID = value;
            }
        }

        public string ConStr
        {
            get
            {
                return _conStr;
            }

            set
            {
                _conStr = value;
            }
        }

        public decimal INCLUSIVE
        {
            get
            {
                return _INCLUSIVE;
            }

            set
            {
                _INCLUSIVE = value;
            }
        }

        public decimal TOTALEXCLUSIVE
        {
            get
            {
                return _TOTALEXCLUSIVE;
            }

            set
            {
                _TOTALEXCLUSIVE = value;
            }
        }

        public decimal TOTALTAXAMOUNT
        {
            get
            {
                return _TOTALTAXAMOUNT;
            }

            set
            {
                _TOTALTAXAMOUNT = value;
            }
        }

        public string INVCDATEDISP
        {
            get
            {
                return _INVCDATEDISP;
            }

            set
            {
                _INVCDATEDISP = value;
            }
        }


        public string PERINVCNUMB
        {
            get
            {
                return _PERINVCNUMB;
            }

            set
            {
                _PERINVCNUMB = value;
            }
        }

        public string VOYAGEDESC
        {
            get
            {
                return _VOYAGEDESC;
            }

            set
            {
                _VOYAGEDESC = value;
            }
        }

        public int SRNO
        {
            get
            {
                return _SRNO;
            }

            set
            {
                _SRNO = value;
            }
        }

        public bool ISRELEASE
        {
            get
            {
                return _ISRELEASE;
            }

            set
            {
                _ISRELEASE = value;
            }
        }

        public bool STATUSID
        {
            get
            {
                return _STATUSID;
            }

            set
            {
                _STATUSID = value;
            }
        }

        public string ETADISP
        {
            get
            {
                return _ETADISP;
            }

            set
            {
                _ETADISP = value;
            }
        }

        public string ETDDISP
        {
            get
            {
                return _ETDDISP;
            }

            set
            {
                _ETDDISP = value;
            }
        }

        public int TotalRows
        {
            get
            {
                return _totalRows;
            }

            set
            {
                _totalRows = value;
            }
        }

        public int TotalPages
        {
            get
            {
                return _totalPages;
            }

            set
            {
                _totalPages = value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value;
            }
        }

        public string DOCSTATUS
        {
            get
            {
                return _DOCSTATUS;
            }

            set
            {
                _DOCSTATUS = value;
            }
        }
        #endregion
        #region methods
        public InvoiceMaster()
        {
        }

        public InvoiceMaster(string conStr)
        {

            ConStr = conStr;
        }

        public Result.Result Save(int USERID, InvoiceMaster obj, string invcNum,XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_Invoice_C(obj.IFLAG, obj.MID, (obj.IFLAG == "1" || obj.IFLAG == "I") ? invcNum : obj.INVCNUMB, obj.INVCDATE, obj.JOBID, obj.VOYAGENO, obj.VESSEL, obj.ETA, obj.ETD, obj.CUSTOMERID, obj.CUSTOMER, obj.ADDRESSDESC, obj.CURRENCY, obj.EXCHANGERATE, USERID, 4, CreateTransXMl(obj), LOGXML);

                return ReadBIErrors(Convert.ToString(SqlExev2.GetXml(xdoc, ConStr)));
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public XElement CreateTransXMl(InvoiceMaster obj)
        {
            XElement xmlTrans = new XElement("TRANSLIST",
                 obj.TransList == null ? null : obj.TransList.Select(x => new XElement("TRANS",
                 new XAttribute("TID", x.TID),
                 new XAttribute("RMID", x.RMID),
                 new XAttribute("TRANSDATE", x.TRANSDATE),
                 new XAttribute("ISOVERTIME", x.ISOVERTIME),
                 new XAttribute("ITEMID", x.ITEMID),
                 new XAttribute("ITEMDESC", x.ITEMDESC),
                 new XAttribute("UOM1ID", x.UOM1ID),
                 new XAttribute("UOM1DESC", x.UOM1DESC),
                 new XAttribute("UOM2ID", x.UOM2ID),
                 new XAttribute("UOM2DESC", x.UOM2DESC),
                 new XAttribute("QTY1", x.QTY1),
                 new XAttribute("QTY2", x.QTY2),
                 new XAttribute("TAX", x.TAX),
                 new XAttribute("RATE", x.RATE),
                 new XAttribute("AMOUNT", x.AMOUNT))));

            return xmlTrans;
        }
        public List<InvoiceMaster> getInvoiceList(int FLAG, int MID, int USERID, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_INVOICE_g(FLAG, MID, "", USERID, LOGXML);
                DataTable dt = SqlExev2.GetDT(xdoc, ConStr);
                List<InvoiceMaster> dbresult = dt != null ? (from s in dt.AsEnumerable()
                                                             select new InvoiceMaster
                                                             {
                                                                 MID = s.Field<int>("MID"),
                                                                 INVCNUMB = s.Field<string>("INVCNUMB"),
                                                                 PERINVCNUMB = s.Field<string>("PERINVC"),
                                                                 INVCDATE = s.Field<DateTime>("INVCDATE"),
                                                                 JOBID = s.Field<int>("JOBID"),
                                                                 VOYAGENO = s.Field<string>("VOYAGENO"),
                                                                 VESSEL = s.Field<string>("VESSEL"),
                                                                 ETA = s.Field<DateTime>("ETA"),
                                                                 ETD = s.Field<DateTime>("ETD"),
                                                                 CUSTOMER = s.Field<string>("CUSTOMER"),
                                                                 CUSTOMERID = s.Field<int>("CUSTOMERID"),
                                                                 ADDRESSDESC = s.Field<string>("ADDRESSDESC"),
                                                                 CURRENCY = s.Field<string>("CURRENCY"),
                                                                 EXCHANGERATE = s.Field<decimal>("EXCHANGERATE"),
                                                                 TOTALEXCLUSIVE = s.Field<decimal>("DOCEXCLUSIVEAMOUNT"),
                                                                 INCLUSIVE = s.Field<decimal>("DOCINCLUSIVEAMOUNT"),
                                                                 VOYAGEDESC = s.Field<string>("VOYAGEDESC"),
                                                                 ISRELEASE = Convert.ToBoolean(s["ISRELEASE"]),
                                                                 STATUSID = Convert.ToBoolean(s["STATUSID"]), 
                                                                 TOTALTAXAMOUNT = s.Field<decimal>("DOCTOTALTAXAMOUNT"),
                                                                 TransList = s.Field<string>("TRANSDETAILS") != null ?
                                                                 (from m in XDocument.Parse(s.Field<string>("TRANSDETAILS")).Elements("TRANSACTION").Elements("TRANS")
                                                                  select new InvoiceTrans
                                                                  {
                                                                      SRNO = m.Attributes("SRNO").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("SRNO").FirstOrDefault().Value),
                                                                      RMID = m.Attributes("RMID").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("RMID").FirstOrDefault().Value),
                                                                      TID = m.Attributes("TID").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("TID").FirstOrDefault().Value),
                                                                      TRANSDATE = Convert.ToDateTime(m.Attributes("TRANSDATE").FirstOrDefault().Value),
                                                                      TRANSDATEDESP = Convert.ToDateTime(m.Attributes("TRANSDATE").FirstOrDefault().Value).ToString("dd-MM-yyyy"),
                                                                      ITEMID = m.Attributes("ITEMID").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("ITEMID").FirstOrDefault().Value),
                                                                      ITEMDESC = m.Attributes("ITEMDESC").FirstOrDefault().Value == null ? "" : Convert.ToString(m.Attributes("ITEMDESC").FirstOrDefault().Value),
                                                                      ISOVERTIME = Convert.ToBoolean(Convert.ToInt32(m.Attributes("ISOVERTIME").FirstOrDefault().Value)),
                                                                      UOM1DESC = m.Attributes("UOM1DESC").FirstOrDefault().Value == null ? "" : Convert.ToString(m.Attributes("UOM1DESC").FirstOrDefault().Value),
                                                                      UOM2DESC = m.Attributes("UOM2DESC").FirstOrDefault().Value == null ? "" : Convert.ToString(m.Attributes("UOM2DESC").FirstOrDefault().Value),
                                                                      QTY1 = Convert.ToDecimal(m.Attributes("QTY1").FirstOrDefault().Value),
                                                                      QTY2 = Convert.ToDecimal(m.Attributes("QTY2").FirstOrDefault().Value),
                                                                      RATE = Convert.ToDecimal(m.Attributes("RATE").FirstOrDefault().Value),
                                                                      AMOUNT = Convert.ToDecimal(m.Attributes("AMOUNT").FirstOrDefault().Value),
                                                                      TAX = Convert.ToDecimal(m.Attributes("TAX").FirstOrDefault().Value),
                                                                      TAXAMOUNT = Convert.ToDecimal(m.Attributes("TAXAMOUNT").FirstOrDefault().Value),
                                                                      REMARK = Convert.ToString(m.Attributes("REMARK").FirstOrDefault().Value),
                                                                      DayTypeDesc = Convert.ToString(m.Attributes("DayTypeDesc").FirstOrDefault().Value),
                                                                      TotalInclusive = Convert.ToString(s.Field<decimal>("DOCINCLUSIVEAMOUNT")),
                                                                      TotalExclusive = Convert.ToString(s.Field<decimal>("DOCEXCLUSIVEAMOUNT")),
                                                                      TotalTaxAmount = Convert.ToString(s.Field<decimal>("DOCTOTALTAXAMOUNT"))
                                                                  }).ToList() : null,
                                                             }).ToList() : null;
                //return dbresult;
                return  dbresult;

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<List<dayType>> getDocAmount(int MID, int USERID, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.INVOICEDOCAMOUNT_g(MID, USERID, LOGXML);
                DataTable dt = SqlExev2.GetDT(xdoc, ConStr);
                List<dayType> dbresult = dt != null ? (from s in dt.AsEnumerable()
                                                       select new dayType
                                                       {
                                                           TotalExclusive = Convert.ToString(s.Field<decimal>("DOCEXCLUSIVEAMOUNT")),
                                                           TotalInclusive = Convert.ToString(s.Field<decimal>("DOCINCLUSIVEAMOUNT")),
                                                           TotalTaxAmount = Convert.ToString(s.Field<decimal>("DOCTOTALTAXAMOUNT"))
                                                       }).ToList() : null;
                //return dbresult;
                return await Task.Factory.StartNew(() => dbresult);

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        #endregion
    }


    public class InvoiceTrans : Result.Result
    {
        XDocument xdoc;
        #region Properties
        int _TID;
        int _RMID;
        DateTime _TRANSDATE;
        bool _ISOVERTIME;
        int _ITEMID;
        string _ITEMDESC;
        int _UOM1ID;
        string _UOM1DESC;
        int _UOM2ID;
        string _UOM2DESC;
        decimal _QTY1;
        decimal _QTY2;

        decimal _RATE;
        decimal _TAX;
        decimal _AMOUNT;
        string _ITFLAG;
        string _REMARK;
        int _DAYTYPE;
        decimal _TAXAMOUNT;
        string _conStr;
        string _TRANSDATEDESP;
        int _SRNO;
        decimal _DAYTYPE1RATE;
        decimal _DAYTYPE2RATE;
        decimal _DAYTYPE3RATE;
        decimal _DAYTYPE4RATE;
        decimal _DAYTYPE1MINCHARGE;
        decimal _DAYTYPE2MINCHARGE;
        decimal _DAYTYPE3MINCHARGE;
        decimal _DAYTYPE4MINCHARGE;
        string _DayTypeDesc;
        int _ISMINCHRGAPPL;
        string _totalExclusive;
        string _totalTaxAmount;
        string _totalInclusive;
        int _totalRows;
        int _totalPages;
        int _pageSize;
        public int TID
        {
            get
            {
                return _TID;
            }

            set
            {
                _TID = value;
            }
        }

        public int RMID
        {
            get
            {
                return _RMID;
            }

            set
            {
                _RMID = value;
            }
        }

        public DateTime TRANSDATE
        {
            get
            {
                return _TRANSDATE;
            }

            set
            {
                _TRANSDATE = value;
            }
        }


        public decimal QTY1
        {
            get
            {
                return _QTY1;
            }

            set
            {
                _QTY1 = value;
            }
        }

        public decimal QTY2
        {
            get
            {
                return _QTY2;
            }

            set
            {
                _QTY2 = value;
            }
        }

        public decimal RATE
        {
            get
            {
                return _RATE;
            }

            set
            {
                _RATE = value;
            }
        }

        public decimal TAX
        {
            get
            {
                return _TAX;
            }

            set
            {
                _TAX = value;
            }
        }

        public decimal AMOUNT
        {
            get
            {
                return _AMOUNT;
            }

            set
            {
                _AMOUNT = value;
            }
        }

        public bool ISOVERTIME
        {
            get
            {
                return _ISOVERTIME;
            }

            set
            {
                _ISOVERTIME = value;
            }
        }

        public int ITEMID
        {
            get
            {
                return _ITEMID;
            }

            set
            {
                _ITEMID = value;
            }
        }

        public string ITEMDESC
        {
            get
            {
                return _ITEMDESC;
            }

            set
            {
                _ITEMDESC = value;
            }
        }


        public string UOM1DESC
        {
            get
            {
                return _UOM1DESC;
            }

            set
            {
                _UOM1DESC = value;
            }
        }

        public int UOM1ID
        {
            get
            {
                return _UOM1ID;
            }

            set
            {
                _UOM1ID = value;
            }
        }

        public int UOM2ID
        {
            get
            {
                return _UOM2ID;
            }

            set
            {
                _UOM2ID = value;
            }
        }

        public string UOM2DESC
        {
            get
            {
                return _UOM2DESC;
            }

            set
            {
                _UOM2DESC = value;
            }
        }
        public string ITFLAG
        {
            get
            {
                return _ITFLAG;
            }

            set
            {
                _ITFLAG = value;
            }
        }
        public string REMARK
        {
            get
            {
                return _REMARK;
            }

            set
            {
                _REMARK = value;
            }
        }
        public int DAYTYPE
        {
            get
            {
                return _DAYTYPE;
            }

            set
            {
                _DAYTYPE = value;
            }
        }
        public decimal TAXAMOUNT
        {
            get
            {
                return _TAXAMOUNT;
            }

            set
            {
                _TAXAMOUNT = value;
            }
        }

        public string ConStr
        {
            get
            {
                return _conStr;
            }

            set
            {
                _conStr = value;
            }
        }

        public string TRANSDATEDESP
        {
            get
            {
                return _TRANSDATEDESP;
            }

            set
            {
                _TRANSDATEDESP = value;
            }
        }
        public int SRNO
        {
            get
            {
                return _SRNO;
            }

            set
            {
                _SRNO = value;
            }
        }

        public decimal DAYTYPE1RATE
        {
            get
            {
                return _DAYTYPE1RATE;
            }

            set
            {
                _DAYTYPE1RATE = value;
            }
        }


        public decimal DAYTYPE2RATE
        {
            get
            {
                return _DAYTYPE2RATE;
            }

            set
            {
                _DAYTYPE2RATE = value;
            }
        }

        public decimal DAYTYPE3RATE
        {
            get
            {
                return _DAYTYPE3RATE;
            }

            set
            {
                _DAYTYPE3RATE = value;
            }
        }

        public decimal DAYTYPE4RATE
        {
            get
            {
                return _DAYTYPE4RATE;
            }

            set
            {
                _DAYTYPE4RATE = value;
            }
        }

        public decimal DAYTYPE1MINCHARGE
        {
            get
            {
                return _DAYTYPE1MINCHARGE;
            }

            set
            {
                _DAYTYPE1MINCHARGE = value;
            }
        }

        public decimal DAYTYPE2MINCHARGE
        {
            get
            {
                return _DAYTYPE2MINCHARGE;
            }

            set
            {
                _DAYTYPE2MINCHARGE = value;
            }
        }

        public decimal DAYTYPE3MINCHARGE
        {
            get
            {
                return _DAYTYPE3MINCHARGE;
            }

            set
            {
                _DAYTYPE3MINCHARGE = value;
            }
        }

        public decimal DAYTYPE4MINCHARGE
        {
            get
            {
                return _DAYTYPE4MINCHARGE;
            }

            set
            {
                _DAYTYPE4MINCHARGE = value;
            }
        }

        public string DayTypeDesc
        {
            get
            {
                return _DayTypeDesc;
            }

            set
            {
                _DayTypeDesc = value;
            }
        }

        public int ISMINCHRGAPPL
        {
            get
            {
                return _ISMINCHRGAPPL;
            }

            set
            {
                _ISMINCHRGAPPL = value;
            }
        }

        public string TotalExclusive
        {
            get
            {
                return _totalExclusive;
            }

            set
            {
                _totalExclusive = value;
            }
        }

        public string TotalTaxAmount
        {
            get
            {
                return _totalTaxAmount;
            }

            set
            {
                _totalTaxAmount = value;
            }
        }

        public string TotalInclusive
        {
            get
            {
                return _totalInclusive;
            }

            set
            {
                _totalInclusive = value;
            }
        }

        public int TotalRows
        {
            get
            {
                return _totalRows;
            }

            set
            {
                _totalRows = value;
            }
        }

        public int TotalPages
        {
            get
            {
                return _totalPages;
            }

            set
            {
                _totalPages = value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value;
            }
        }

        #endregion

        #region methods 
        public InvoiceTrans()
        { }
        public InvoiceTrans(string conStr)
        { ConStr = conStr; }

        public Result.Result Save(int USERID, InvoiceTrans obj, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_InvoiceTrans_C(obj.ITFLAG, obj.TID, obj.RMID, obj.TRANSDATE, obj.ITEMID, obj.DAYTYPE, obj.ITEMDESC, obj.ISOVERTIME, obj.QTY1, obj.UOM1DESC, obj.QTY2, obj.UOM2DESC, obj.RATE, obj.TAX, obj.TAXAMOUNT, obj.AMOUNT, obj.REMARK==null ?"": obj.REMARK, obj.DAYTYPE1MINCHARGE, obj.DAYTYPE2MINCHARGE, obj.DAYTYPE3MINCHARGE, obj.DAYTYPE4MINCHARGE, obj.DAYTYPE1RATE, obj.DAYTYPE2RATE, obj.DAYTYPE3RATE, obj.DAYTYPE4RATE, obj.ISMINCHRGAPPL, USERID, 4, LOGXML);

                return ReadBIErrors(Convert.ToString(SqlExev2.GetXml(xdoc, ConStr)));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public List<InvoiceTrans> getInvoiceTransList(int FLAG, int MID, int TID, int USERID, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_INVOICETRANS_g(FLAG, MID, TID, "", USERID, LOGXML);
                DataTable dt = SqlExev2.GetDT(xdoc, ConStr);
                List<InvoiceTrans> dbresult = dt != null ? (from s in dt.AsEnumerable()
                                                            select new InvoiceTrans
                                                            {
                                                                SRNO = Convert.ToInt32(s["SRNO"]),
                                                                TID = s.Field<int>("TID"),
                                                                RMID = s.Field<int>("RMID"),
                                                                ITEMID = s.Field<int>("ITEMID"),
                                                                ITEMDESC = s.Field<string>("ITEMDESC"),
                                                                ISOVERTIME = s.Field<bool>("ISOVERTIME"),
                                                                QTY1 = s.Field<decimal>("QTY1"),
                                                                UOM1DESC = s.Field<string>("UOM1DESC"),
                                                                QTY2 = s.Field<decimal>("QTY2"),
                                                                UOM2DESC = s.Field<string>("UOM2DESC"),
                                                                RATE = s.Field<decimal>("RATE"),
                                                                AMOUNT = s.Field<decimal>("AMOUNT"),
                                                                TRANSDATE = s.Field<DateTime>("TRANSDATE"),
                                                                TAX = s.Field<decimal>("TAX"),
                                                                TAXAMOUNT = s.Field<decimal>("TAXAMOUNT"),
                                                                DAYTYPE = s.Field<int>("DAYTYPE"),
                                                                TRANSDATEDESP = s.Field<string>("TRANSDATEDESP"),
                                                                DAYTYPE1RATE = s.Field<decimal>("DAYTYPE1RATE"),
                                                                DAYTYPE2RATE = s.Field<decimal>("DAYTYPE2RATE"),
                                                                DAYTYPE3RATE = s.Field<decimal>("DAYTYPE3RATE"),
                                                                DAYTYPE4RATE = s.Field<decimal>("DAYTYPE4RATE"),
                                                                DAYTYPE1MINCHARGE = s.Field<decimal>("DAYTYPE1MINCHARGE"),
                                                                DAYTYPE2MINCHARGE = s.Field<decimal>("DAYTYPE2MINCHARGE"),
                                                                DAYTYPE3MINCHARGE = s.Field<decimal>("DAYTYPE3MINCHARGE"),
                                                                DAYTYPE4MINCHARGE = s.Field<decimal>("DAYTYPE4MINCHARGE"),
                                                                ISMINCHRGAPPL = Convert.ToInt32(s.Field<bool>("ISMINCHRGAPPL")),
                                                                REMARK = s.Field<string>("REMARK"),
                                                                DayTypeDesc = s.Field<string>("DayTypeDesc"),
                                                                TotalInclusive = Convert.ToString(s.Field<decimal>("DOCINCLUSIVEAMOUNT")),
                                                                TotalExclusive = Convert.ToString(s.Field<decimal>("DOCEXCLUSIVEAMOUNT")),
                                                                TotalTaxAmount = Convert.ToString(s.Field<decimal>("DOCTOTALTAXAMOUNT"))

                                                            }).ToList() : null;
                return dbresult;
            }
            catch (Exception ex)
            { 
                throw ex;
            }


        }
        #endregion
    }
}
