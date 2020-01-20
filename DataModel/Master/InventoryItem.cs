using Pastel.Evolution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Master
{
    public class InventoryItem
    {
        int _ITEMID;
        string _ITEMDSEC;
        string _ITEMDSEC2;
        decimal _TAX;
        string _UOM2;
        string _UOM1;
        List<PriceListMapping> _plTransList;
        string _conStr;

        InventoryItem _obj;

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

        public string ITEMDSEC
        {
            get
            {
                return _ITEMDSEC;
            }

            set
            {
                _ITEMDSEC = value;
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
        public List<PriceListMapping> PlTransList
        {
            get
            {
                return _plTransList;
            }

            set
            {
                _plTransList = value;
            }
        }


        public string UOM2
        {
            get
            {
                return _UOM2;
            }

            set
            {
                _UOM2 = value;
            }
        }
        public string UOM1
        {
            get
            {
                return _UOM1;
            }

            set
            {
                _UOM1 = value;
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

        public InventoryItem Obj
        {
            get
            {
                return _obj;
            }

            set
            {
                _obj = value;
            }
        }

        public string ITEMDSEC2
        {
            get
            {
                return _ITEMDSEC2;
            }

            set
            {
                _ITEMDSEC2 = value;
            }
        }

        public InventoryItem()
        {
        }
        public InventoryItem(string conStr)
        {
            ConStr = conStr;
        }
        public object GetInventoryItemDt(int id, string itemCriteria, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode)
        {
            DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);
            DataTable dt;

            dt = Pastel.Evolution.InventoryItem.List(itemCriteria);
            object dbresult = dt != null ? (from s in dt.AsEnumerable()
                                            select new
                                            {
                                                id = s.Field<int>("StockLink"),
                                                text = s.Field<string>("Code") + " " + s.Field<string>("Description_1")
                                            }).ToList() : null;


            return dbresult;
        }
        public InventoryItem getItemDetailsById(int itemId, string conUOM1, string conUOM2, string conMINCHARGE, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode)
        {
            try
            {
                DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);

                InventoryItem origobj = new InventoryItem();//this class is created in our application
                List<PriceListMapping> AddListObj = new List<PriceListMapping>();
                Pastel.Evolution.InventoryItem obj = new Pastel.Evolution.InventoryItem(itemId);//This is evolution class we are passing selected itemid to it 
                SellingPriceCollection sl = obj.SellingPrices;
                PriceListMapping plObj = new PriceListMapping(ConStr);
                List<PriceListMapping> ListObj = plObj.GetPriceList(0, 0);

                string[] minCharge = Convert.ToString(obj.UserFields[conMINCHARGE]) != "None" ? Convert.ToString(obj.UserFields[conMINCHARGE]).Split('|') : null;

                int count = 0;

                foreach (var plobj in ListObj)
                {
                    string MINPLRATE = "0";
                    if (minCharge != null && minCharge.Length > 0 && count < minCharge.Length)
                    {
                        MINPLRATE = minCharge[count];
                    }
                    foreach (SellingPrice sageplobj in sl)
                    {
                        decimal PriceExcl = Convert.ToDecimal(sageplobj.PriceExcl);
                        int plid = sageplobj.PriceList.ID;
                        if (plid == plobj.PriceListId)
                        {
                            PriceListMapping newplobj = new PriceListMapping();
                            newplobj.MappingId = plobj.MappingId;
                            newplobj.PriceListId = plobj.PriceListId;
                            newplobj.PriceListName = plobj.PriceListName;
                            newplobj.Rate = PriceExcl;
                            newplobj.MappingName = plobj.MappingName;
                            newplobj.MinCharge = Convert.ToDecimal(MINPLRATE);
                            AddListObj.Add(newplobj);
                            break;
                        }

                    }

                    count++;
                }

                origobj.UOM1 = Convert.ToString(obj.UserFields[conUOM1]);
                origobj.UOM2 = Convert.ToString(obj.UserFields[conUOM2]);
                origobj.PlTransList = AddListObj;
                origobj.TAX = Convert.ToDecimal(obj.DefaultInvoicingTaxType.Rate);

                return origobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InventoryItem> getAgencyFeeItemsdetails(string itemCriteria, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode)
        {
            try
            {
                DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode); 
                InventoryItem origobj = new InventoryItem();//this class is created in our application 
                DataTable dt = Pastel.Evolution.InventoryItem.List("ItemGroup IN ('AFPS','AFRV','AFT','AFCT') AND ItemActive=1"); 
                List<InventoryItem> dbResult = dt != null || dt.Rows.Count>0?
                    (from s in dt.AsEnumerable()
                     select new InventoryItem
                     {
                         Obj = origobj.getAgencyFeeItemDetailsById(s.Field<int>("StockLink"), dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode)
                     }).ToList():null; 
                return dbResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InventoryItem getAgencyFeeItemDetailsById(int itemId, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode)
        {
            try
            {
                DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);

                InventoryItem origobj = new InventoryItem();//this class is created in our application
                List<PriceListMapping> AddListObj = new List<PriceListMapping>();
                Pastel.Evolution.InventoryItem obj = new Pastel.Evolution.InventoryItem(itemId);//This is evolution class we are passing selected itemid to it 
                SellingPriceCollection sl = obj.SellingPrices;
                PriceListMapping plObj = new PriceListMapping(dbConnectionString);
                List<PriceListMapping> ListObj = plObj.GetPriceList(0, 0);

                foreach (SellingPrice sageplobj in sl)
                {
                    decimal PriceExcl = Convert.ToDecimal(sageplobj.PriceExcl);
                    string plid = sageplobj.PriceList.Description;
                    if (plid == "Normal")
                    {
                        PriceListMapping newplobj = new PriceListMapping();
                        newplobj.MappingId = 0;
                        newplobj.PriceListId = 0;
                        newplobj.PriceListName = "";
                        newplobj.Rate = PriceExcl;
                        newplobj.MappingName = "";
                        AddListObj.Add(newplobj);
                        break;
                    }

                }
                origobj.ITEMID = itemId;
                origobj.ITEMDSEC = obj.Code + ' ' + obj.Description_2;
                origobj.ITEMDSEC2 = obj.Description;
                origobj.PlTransList = AddListObj;
                origobj.TAX = Convert.ToDecimal(obj.DefaultInvoicingTaxType.Rate);

                return origobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
