using DataAccess;
using Pastel.Evolution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel.Master
{
    public class PriceListMapping : Result.Result
    { 
        XDocument xdoc;
        DataTable dt;
        int _mappingId;
        string _mappingName;
        int _priceListId;
        string _priceListName;
        decimal _rate;
        decimal _minCharge;
        List<PriceListMapping> _TransList;
        string _conStr;

        public int MappingId
        {
            get
            {
                return _mappingId;
            }

            set
            {
                _mappingId = value;
            }
        }

        public string MappingName
        {
            get
            {
                return _mappingName;
            }

            set
            {
                _mappingName = value;
            }
        }

        public int PriceListId
        {
            get
            {
                return _priceListId;
            }

            set
            {
                _priceListId = value;
            }
        }

        public string PriceListName
        {
            get
            {
                return _priceListName;
            }

            set
            {
                _priceListName = value;
            }
        }

        public List<PriceListMapping> TransList
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

        public decimal Rate
        {
            get
            {
                return _rate;
            }

            set
            {
                _rate = value;
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

        public decimal MinCharge
        {
            get
            {
                return _minCharge;
            }

            set
            {
                _minCharge = value;
            }
        }

        public PriceListMapping()
        {
        }
        public PriceListMapping(string conStr)
        {
            ConStr = conStr;
        }
        public List<PriceListMapping> GetPriceList(int MappingId, int USERID, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_PriceListMapping_g(MappingId, USERID, LOGXML);
                dt = SqlExev2.GetDT(xdoc, ConStr);
                List<PriceListMapping> dbresult = dt != null ?
                    (from s in dt.AsEnumerable()
                     select new PriceListMapping
                     {
                         MappingId = s.Field<int>("MappingId"),
                         MappingName = s.Field<string>("MappingName"),
                         PriceListId = s.Field<int>("PriceListId"),
                         PriceListName = s.Field<string>("PriceListName")
                     }).ToList() : null;
                return dbresult;
            }
            catch (Exception ex)
            { 
                throw ex;
            }

        }

        // Method for Save Factory Calendar Details
        public Result.Result Save(int USERID, PriceListMapping obj, XElement LOGXML = null)
        {
            try
            {
                xdoc = DBXML.ST_PriceListMapping_C("E", USERID, CreateTransXMl(obj), LOGXML);
                return ReadBIErrors(Convert.ToString(SqlExev2.GetXml(xdoc, ConStr)));
            }
            catch (Exception ex)
            { 
                throw ex;
            }

        }

        public XElement CreateTransXMl(PriceListMapping obj)
        {
            XElement xmlTrans = new XElement("TRANSACTIONS",
                 obj.TransList == null ? null : obj.TransList.Select(x => new XElement("TRANS",
                 new XAttribute("PRICELISTMAPPINGNAME", x.PriceListName),
                 new XAttribute("MAPPINGID", x.MappingId),
                 new XAttribute("PRICELISTMAPPING", x.PriceListId))));

            return xmlTrans;
        }

        public List<PriceListMapping> GetPriceListDt(string PriceListCriteria,string dbConnectionString,string evolutionCommonDBConnectionString,string serialNumber,string authCode)
        {
            try
            {
                DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);
                DataTable DT = PriceList.List(PriceListCriteria);

                List<PriceListMapping> dbresult = DT != null ?
                    (from s in DT.AsEnumerable()
                     select new PriceListMapping
                     {
                         PriceListId = s.Field<int>("IDPriceListName"),
                         PriceListName = s.Field<string>("cName")
                     }).ToList() : null;
                return dbresult;
            }
            catch (Exception ex)
            { 
                throw ex;
            }

        }
    }
}
