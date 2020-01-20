using DataAccess;
using DataModel.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel.Transaction
{
    public class AgencyInvoiceMast : Result.Result
    {
        XDocument xdoc;
        DataTable dt;
        #region Properties
        int mid;
        string invcNumb;
        DateTime invcDate;
        int jobId;
        string voyageNo;
        string voyageDesc;
        string vesseltype;
        DateTime AADate;
        DateTime ADDate;
        int customerId;
        string customer;
        string addressDesc;
        string currency;
        List<AgencyInvoiceTrans> transList;
        string iFlag;
        string conStr;
        decimal inclusiveTotalAmount;
        decimal exclusiveTotalAmount;
        decimal totalTaxAmount;
        string invcDateDisp;
        string perInvcNumb;
        bool isRelease;
        bool statusId;
        int srNo;
        string AADateDisp;
        string ADDateDisp;
        int totalRows;
        int totalPages;
        int pageSize;
        string docStatus;

        public int Mid
        {
            get
            {
                return mid;
            }

            set
            {
                mid = value;
            }
        }

        public string InvcNumb
        {
            get
            {
                return invcNumb;
            }

            set
            {
                invcNumb = value;
            }
        }

        public DateTime InvcDate
        {
            get
            {
                return invcDate;
            }

            set
            {
                invcDate = value;
            }
        }

        public int JobId
        {
            get
            {
                return jobId;
            }

            set
            {
                jobId = value;
            }
        }

        public string VoyageNo
        {
            get
            {
                return voyageNo;
            }

            set
            {
                voyageNo = value;
            }
        }

        public string VoyageDesc
        {
            get
            {
                return voyageDesc;
            }

            set
            {
                voyageDesc = value;
            }
        }

        public string Vesseltype
        {
            get
            {
                return vesseltype;
            }

            set
            {
                vesseltype = value;
            }
        }

        public DateTime AADate1
        {
            get
            {
                return AADate;
            }

            set
            {
                AADate = value;
            }
        }

        public DateTime ADDate1
        {
            get
            {
                return ADDate;
            }

            set
            {
                ADDate = value;
            }
        }

        public int CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
            }
        }

        public string Customer
        {
            get
            {
                return customer;
            }

            set
            {
                customer = value;
            }
        }

        public string AddressDesc
        {
            get
            {
                return addressDesc;
            }

            set
            {
                addressDesc = value;
            }
        }

        public string Currency
        {
            get
            {
                return currency;
            }

            set
            {
                currency = value;
            }
        }

        public List<AgencyInvoiceTrans> TransList
        {
            get
            {
                return transList;
            }

            set
            {
                transList = value;
            }
        }

        public string IFlag
        {
            get
            {
                return iFlag;
            }

            set
            {
                iFlag = value;
            }
        }

        public string ConStr
        {
            get
            {
                return conStr;
            }

            set
            {
                conStr = value;
            }
        }

        public decimal InclusiveTotalAmount
        {
            get
            {
                return inclusiveTotalAmount;
            }

            set
            {
                inclusiveTotalAmount = value;
            }
        }

        public decimal ExclusiveTotalAmount
        {
            get
            {
                return exclusiveTotalAmount;
            }

            set
            {
                exclusiveTotalAmount = value;
            }
        }

        public decimal TotalTaxAmount
        {
            get
            {
                return totalTaxAmount;
            }

            set
            {
                totalTaxAmount = value;
            }
        }

        public string InvcDateDisp
        {
            get
            {
                return invcDateDisp;
            }

            set
            {
                invcDateDisp = value;
            }
        }

        public string PerInvcNumb
        {
            get
            {
                return perInvcNumb;
            }

            set
            {
                perInvcNumb = value;
            }
        }

        public bool IsRelease
        {
            get
            {
                return isRelease;
            }

            set
            {
                isRelease = value;
            }
        }

        public bool StatusId
        {
            get
            {
                return statusId;
            }

            set
            {
                statusId = value;
            }
        }

        public int SrNo
        {
            get
            {
                return srNo;
            }

            set
            {
                srNo = value;
            }
        }

        public string AADateDisp1
        {
            get
            {
                return AADateDisp;
            }

            set
            {
                AADateDisp = value;
            }
        }

        public string ADDateDisp1
        {
            get
            {
                return ADDateDisp;
            }

            set
            {
                ADDateDisp = value;
            }
        }

        public int TotalRows
        {
            get
            {
                return totalRows;
            }

            set
            {
                totalRows = value;
            }
        }

        public int TotalPages
        {
            get
            {
                return totalPages;
            }

            set
            {
                totalPages = value;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        public string DocStatus
        {
            get
            {
                return docStatus;
            }

            set
            {
                docStatus = value;
            }
        }

        #endregion
        #region functions
        public AgencyInvoiceMast()
        {
        }

        public AgencyInvoiceMast(string conStr)
        {
            ConStr = conStr;
        }
        public Result.Result Save(int USERID, AgencyInvoiceMast obj, string invcNum, string itemCriteria, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode, XElement LOGXML = null)
        {
            try
            {

                xdoc = DBXML.st_AgencyFeeInvoice_C(obj.IFlag, obj.Mid, (obj.IFlag == "1" || obj.IFlag == "I") ? invcNum : obj.InvcNumb, obj.InvcDate, obj.jobId, obj.VoyageNo, obj.Vesseltype, obj.AADate1, obj.ADDate1, obj.CustomerId, obj.Customer, obj.AddressDesc, obj.Currency, USERID, 4, obj.IFlag == "I" ? CreateTransXMl(obj, itemCriteria, dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode):null, LOGXML);

                return ReadBIErrors(Convert.ToString(SqlExev2.GetXml(xdoc, ConStr)));
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public XElement CreateTransXMl(AgencyInvoiceMast obj, string itemCriteria, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode)
        {
            try
            {
                InventoryItem objInv = new InventoryItem();
                List<InventoryItem> ListInv = objInv.getAgencyFeeItemsdetails(itemCriteria, dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);
                XElement xmlTrans = new XElement("TRANSLIST",
                     ListInv == null ? null : ListInv.Select(x => new XElement("TRANS",
                     new XAttribute("TID", 0),
                     new XAttribute("RMID", obj.Mid),
                     new XAttribute("TRANSDATE",DateTime.Now.Date),
                     new XAttribute("ITEMID", x.Obj.ITEMID),
                     new XAttribute("ITEMDESC", x.Obj.ITEMDSEC),
                     new XAttribute("ITEMDSEC2", x.Obj.ITEMDSEC2),
                     new XAttribute("TAX", x.Obj.TAX),
                     new XAttribute("RATE", x.Obj.PlTransList.FirstOrDefault().Rate))));

                return xmlTrans;
            }
            catch (Exception ex)
            { 
                throw;
            } 
        }

        public List<AgencyInvoiceMast> getAgencyInvoiceList(int FLAG, int MID, int USERID, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.st_AgencyFeeInvoice_g(FLAG, MID, "", USERID, LOGXML);
                DataTable dt = SqlExev2.GetDT(xdoc, ConStr);
                List<AgencyInvoiceMast> dbresult = dt != null ?
                    (from s in dt.AsEnumerable()
                     select new AgencyInvoiceMast
                     {
                         Mid = s.Field<int>("mid"),
                         InvcNumb = s.Field<string>("invcNumb"),
                         perInvcNumb = s.Field<string>("perInvcNumb"),
                         InvcDate = s.Field<DateTime>("invcDate"),
                         JobId = s.Field<int>("jobId"),
                         VoyageNo = s.Field<string>("voyageNo"),
                         Vesseltype = s.Field<string>("vesselType"),
                         AADate1 = s.Field<DateTime>("AADate"),
                         ADDate1 = s.Field<DateTime>("ADDate"),
                         customer = s.Field<string>("customer"),
                         CustomerId = s.Field<int>("customerId"),
                         AddressDesc = s.Field<string>("addressDesc"),
                         Currency = s.Field<string>("currency"),
                         exclusiveTotalAmount = s.Field<decimal>("DOCEXCLUSIVEAMOUNT"),
                         inclusiveTotalAmount = s.Field<decimal>("DOCINCLUSIVEAMOUNT"),
                         VoyageDesc = s.Field<string>("voyageDesc"),
                         IsRelease = Convert.ToBoolean(s["isRelease"]),
                         statusId = Convert.ToBoolean(s["statusId"]),
                         totalTaxAmount = s.Field<decimal>("DOCTOTALTAXAMOUNT"),
                         TransList = s.Field<string>("TRANSDETAILS") != null ?
                         (from m in XDocument.Parse(s.Field<string>("TRANSDETAILS")).Elements("TRANSACTION").Elements("TRANS")
                          select new AgencyInvoiceTrans
                          {
                              SrNo = m.Attributes("SRNO").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("SRNO").FirstOrDefault().Value),
                              Rmid = m.Attributes("rmid").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("rmid").FirstOrDefault().Value),
                              Tid = m.Attributes("tid").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("tid").FirstOrDefault().Value),
                              TransDate = Convert.ToDateTime(m.Attributes("transDate").FirstOrDefault().Value),
                              TransDateDisp = Convert.ToDateTime(m.Attributes("transDate").FirstOrDefault().Value).ToString("dd-MM-yyyy"),
                              ItemId = m.Attributes("itemId").FirstOrDefault().Value == null ? 0 : Convert.ToInt32(m.Attributes("itemId").FirstOrDefault().Value),
                              ItemDesc = m.Attributes("itemDesc").FirstOrDefault().Value == null ? "" : Convert.ToString(m.Attributes("itemDesc").FirstOrDefault().Value),
                              UomDesc = m.Attributes("uomDesc").FirstOrDefault().Value == null ? "" : Convert.ToString(m.Attributes("uomDesc").FirstOrDefault().Value),
                              Qty = Convert.ToDecimal(m.Attributes("qty").FirstOrDefault().Value),
                              Rate = Convert.ToDecimal(m.Attributes("rate").FirstOrDefault().Value),
                              Amount = Convert.ToDecimal(m.Attributes("amount").FirstOrDefault().Value),
                              Tax = Convert.ToDecimal(m.Attributes("tax").FirstOrDefault().Value),
                              TaxAmount = Convert.ToDecimal(m.Attributes("taxAmount").FirstOrDefault().Value),
                              Remark = Convert.ToString(m.Attributes("remark").FirstOrDefault().Value),
                              DayTypeDesc = Convert.ToString(m.Attributes("DayTypeDesc").FirstOrDefault().Value),
                              TotalInclusive = Convert.ToString(s.Field<decimal>("DOCINCLUSIVEAMOUNT")),
                              TotalExclusive = Convert.ToString(s.Field<decimal>("DOCEXCLUSIVEAMOUNT")),
                              TotalTaxAmount = Convert.ToString(s.Field<decimal>("DOCTOTALTAXAMOUNT"))
                          }).ToList() : null,
                     }).ToList() : null;
                //return dbresult;
                return dbresult;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion
    }
    public class AgencyInvoiceTrans : Result.Result
    {
        XDocument xdoc; 
        #region Properties
        int tid;
        int rmid;
        DateTime transDate;
        int itemId;
        string itemDesc;
        int uom;
        string uomDesc;
        decimal qty;
        decimal rate;
        decimal tax;
        decimal amount;
        string itFlag;
        string remark;
        int dayType;
        decimal taxAmount;
        string conStr;
        string transDateDisp;
        int srNo;
        decimal dayType1Rate;
        decimal dayType2Rate;
        decimal dayType3Rate;
        decimal dayType4Rate;
        decimal dayType1MinCharg;
        decimal dayType2MinCharg;
        decimal dayType3MinCharg;
        decimal dayType4MinCharg;
        string dayTypeDesc;
        int isMinChargAppl;
        string totalExclusive;
        string totalTaxAmount;
        string totalInclusive;
        int totalRows;
        int totalPages;
        int pageSize;

        public int Tid
        {
            get
            {
                return tid;
            }

            set
            {
                tid = value;
            }
        }

        public int Rmid
        {
            get
            {
                return rmid;
            }

            set
            {
                rmid = value;
            }
        }

        public DateTime TransDate
        {
            get
            {
                return transDate;
            }

            set
            {
                transDate = value;
            }
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }

            set
            {
                itemId = value;
            }
        }

        public string ItemDesc
        {
            get
            {
                return itemDesc;
            }

            set
            {
                itemDesc = value;
            }
        }

        public int Uom
        {
            get
            {
                return uom;
            }

            set
            {
                uom = value;
            }
        }

        public string UomDesc
        {
            get
            {
                return uomDesc;
            }

            set
            {
                uomDesc = value;
            }
        }

        public decimal Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
            }
        }

        public decimal Tax
        {
            get
            {
                return tax;
            }

            set
            {
                tax = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string ItFlag
        {
            get
            {
                return itFlag;
            }

            set
            {
                itFlag = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }

        public int DayType
        {
            get
            {
                return dayType;
            }

            set
            {
                dayType = value;
            }
        }

        public decimal TaxAmount
        {
            get
            {
                return taxAmount;
            }

            set
            {
                taxAmount = value;
            }
        }

        public string ConStr
        {
            get
            {
                return conStr;
            }

            set
            {
                conStr = value;
            }
        }

        public string TransDateDisp
        {
            get
            {
                return transDateDisp;
            }

            set
            {
                transDateDisp = value;
            }
        }

        public int SrNo
        {
            get
            {
                return srNo;
            }

            set
            {
                srNo = value;
            }
        }

        public decimal DayType1Rate
        {
            get
            {
                return dayType1Rate;
            }

            set
            {
                dayType1Rate = value;
            }
        }

        public decimal DayType2Rate
        {
            get
            {
                return dayType2Rate;
            }

            set
            {
                dayType2Rate = value;
            }
        }

        public decimal DayType3Rate
        {
            get
            {
                return dayType3Rate;
            }

            set
            {
                dayType3Rate = value;
            }
        }

        public decimal DayType4Rate
        {
            get
            {
                return dayType4Rate;
            }

            set
            {
                dayType4Rate = value;
            }
        }

        public decimal DayType1MinCharg
        {
            get
            {
                return dayType1MinCharg;
            }

            set
            {
                dayType1MinCharg = value;
            }
        }

        public decimal DayType2MinCharg
        {
            get
            {
                return dayType2MinCharg;
            }

            set
            {
                dayType2MinCharg = value;
            }
        }

        public decimal DayType3MinCharg
        {
            get
            {
                return dayType3MinCharg;
            }

            set
            {
                dayType3MinCharg = value;
            }
        }

        public decimal DayType4MinCharg
        {
            get
            {
                return dayType4MinCharg;
            }

            set
            {
                dayType4MinCharg = value;
            }
        }

        public string DayTypeDesc
        {
            get
            {
                return dayTypeDesc;
            }

            set
            {
                dayTypeDesc = value;
            }
        }

        public int IsMinChargAppl
        {
            get
            {
                return isMinChargAppl;
            }

            set
            {
                isMinChargAppl = value;
            }
        }

        public string TotalExclusive
        {
            get
            {
                return totalExclusive;
            }

            set
            {
                totalExclusive = value;
            }
        }

        public string TotalTaxAmount
        {
            get
            {
                return totalTaxAmount;
            }

            set
            {
                totalTaxAmount = value;
            }
        }

        public string TotalInclusive
        {
            get
            {
                return totalInclusive;
            }

            set
            {
                totalInclusive = value;
            }
        }

        public int TotalRows
        {
            get
            {
                return totalRows;
            }

            set
            {
                totalRows = value;
            }
        }

        public int TotalPages
        {
            get
            {
                return totalPages;
            }

            set
            {
                totalPages = value;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        #endregion

        #region Methods
        public AgencyInvoiceTrans()
        {
        }

        public AgencyInvoiceTrans(string conStr)
        {
            ConStr = conStr;
        }
        public Result.Result Save(int USERID, AgencyInvoiceTrans obj, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.st_AgencyFeeInvoiceTrans_C(obj.itFlag, obj.Tid, obj.Rmid, obj.TransDate, obj.ItemId, obj.DayType, obj.ItemDesc, obj.Qty, obj.UomDesc, obj.Rate, obj.Tax, obj.TaxAmount, obj.Amount, obj.Remark == null ? "" : obj.Remark, obj.DayType1MinCharg, obj.DayType2MinCharg, obj.DayType3MinCharg, obj.DayType4MinCharg, obj.DayType1Rate, obj.DayType2Rate, obj.DayType3Rate, obj.DayType4Rate, USERID, 5, LOGXML);

                return ReadBIErrors(Convert.ToString(SqlExev2.GetXml(xdoc, ConStr)));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<AgencyInvoiceTrans> getAgencyInvTransList(int FLAG, int MID, int TID, int USERID, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_INVOICETRANS_g(FLAG, MID, TID, "", USERID, LOGXML);
                DataTable dt = SqlExev2.GetDT(xdoc, ConStr);
                List<AgencyInvoiceTrans> dbresult = dt != null ?
                    (from s in dt.AsEnumerable()
                     select new AgencyInvoiceTrans
                     {
                         SrNo = Convert.ToInt32(s["SRNO"]),
                         Tid = s.Field<int>("tid"),
                         Rmid = s.Field<int>("rmid"),
                         ItemId = s.Field<int>("itemId"),
                         ItemDesc = s.Field<string>("itemDesc"),
                         Qty = s.Field<decimal>("qty"),
                         UomDesc = s.Field<string>("uomDesc"),
                         Rate = s.Field<decimal>("rate"),
                         Amount = s.Field<decimal>("amount"),
                         TransDate = s.Field<DateTime>("transDate"),
                         Tax = s.Field<decimal>("tax"),
                         TaxAmount = s.Field<decimal>("taxAmount"),
                         dayType = s.Field<int>("dayType"),
                         TransDateDisp = s.Field<string>("transDateDisp"),
                         dayType1Rate = s.Field<decimal>("dayType1Rate"),
                         DayType2Rate = s.Field<decimal>("dayType2Rate"),
                         DayType3Rate = s.Field<decimal>("dayType3Rate"),
                         DayType4Rate = s.Field<decimal>("dayType4Rate"),
                         DayType1MinCharg = s.Field<decimal>("dayType1MinCharge"),
                         DayType2MinCharg = s.Field<decimal>("dayType2MinCharge"),
                         DayType3MinCharg = s.Field<decimal>("dayType3MinCharge"),
                         DayType4MinCharg = s.Field<decimal>("dayType4MinCharge"),
                         remark = s.Field<string>("remark"),
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