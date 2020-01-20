using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel.Database
{
    public class dbConfig:Result.Result
    { 
        #region Properties
        XDocument xdoc;
        DataTable dt; 

        int dbConfigId;
        string dbName;
        string dbServerName;
        string dbDatabaseName;
        string dbUserId;
        string dbPassword; 
        string dbConStr; 
        string dbCommServerName;
        string dbCommDatabaseName;
        string dbCommUserId;
        string dbCommPassword; 
        string dbCommonConStr;
        string serialNumber;
        string authCode; 
        string adminGroup;
        string userGroup;
        DateTime createdOn;
        int createdBy;
        bool isActive;
        DateTime updatedOn;
        int updatedBy;
        int isAdmin;
        //Stevedoring Setting
        string itemCriteria;
        string etaDateUsrDef;
        string etdDateUsrDef;
        string uom1;
        string uom2;
        string minCharge;
        string invcNumb;
        string perInvcNumb;
        string jobCriteria;
        string priceListCriteria;
        string warehouseId;
        string clientSettProvider;
        //Shore handling setting 
        string sShItemCriteria;
        string sShEtaDateUsrDef;
        string sShEtdDateUsrDef;
        string sShUom1;
        string sShUom2;
        string sShMinCharge;
        string sShInvcNumb;
        string sShPerInvcNumb;
        string sShJobCriteria;
        string sShPriceListCriteria;
        string sShWarehouseId;
        string sShClientSettProvider; 
        //Agency fee setting
        string sAgItemCrieteria;
        string sAgJobCriteris;
        string sAgInvcNumb;
        string sAgPerInvcNumb;
        string sAgWarehouseId;
        string sAgpriceListCriteria;
        string sAgPriceListName;

        public int DbConfigId
        {
            get
            {
                return dbConfigId;
            }

            set
            {
                dbConfigId = value;
            }
        }

        public string DbName
        {
            get
            {
                return dbName;
            }

            set
            {
                dbName = value;
            }
        }

        public string DbServerName
        {
            get
            {
                return dbServerName;
            }

            set
            {
                dbServerName = value;
            }
        }

        public string DbDatabaseName
        {
            get
            {
                return dbDatabaseName;
            }

            set
            {
                dbDatabaseName = value;
            }
        }

        public string DbUserId
        {
            get
            {
                return dbUserId;
            }

            set
            {
                dbUserId = value;
            }
        }

        public string DbPassword
        {
            get
            {
                return dbPassword;
            }

            set
            {
                dbPassword = value;
            }
        }

        public string DbConStr
        {
            get
            {
                return dbConStr;
            }

            set
            {
                dbConStr = value;
            }
        }

        public string DbCommServerName
        {
            get
            {
                return dbCommServerName;
            }

            set
            {
                dbCommServerName = value;
            }
        }

        public string DbCommDatabaseName
        {
            get
            {
                return dbCommDatabaseName;
            }

            set
            {
                dbCommDatabaseName = value;
            }
        }

        public string DbCommUserId
        {
            get
            {
                return dbCommUserId;
            }

            set
            {
                dbCommUserId = value;
            }
        }

        public string DbCommPassword
        {
            get
            {
                return dbCommPassword;
            }

            set
            {
                dbCommPassword = value;
            }
        }

        public string DbCommonConStr
        {
            get
            {
                return dbCommonConStr;
            }

            set
            {
                dbCommonConStr = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }

            set
            {
                serialNumber = value;
            }
        }

        public string AuthCode
        {
            get
            {
                return authCode;
            }

            set
            {
                authCode = value;
            }
        }

        public string ItemCriteria
        {
            get
            {
                return itemCriteria;
            }

            set
            {
                itemCriteria = value;
            }
        }

        public string EtaDateUsrDef
        {
            get
            {
                return etaDateUsrDef;
            }

            set
            {
                etaDateUsrDef = value;
            }
        }

        public string EtdDateUsrDef
        {
            get
            {
                return etdDateUsrDef;
            }

            set
            {
                etdDateUsrDef = value;
            }
        }

        public string Uom1
        {
            get
            {
                return uom1;
            }

            set
            {
                uom1 = value;
            }
        }

        public string Uom2
        {
            get
            {
                return uom2;
            }

            set
            {
                uom2 = value;
            }
        }

        public string MinCharge
        {
            get
            {
                return minCharge;
            }

            set
            {
                minCharge = value;
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

        public string JobCriteria
        {
            get
            {
                return jobCriteria;
            }

            set
            {
                jobCriteria = value;
            }
        }

        public string PriceListCriteria
        {
            get
            {
                return priceListCriteria;
            }

            set
            {
                priceListCriteria = value;
            }
        }

        public string WarehouseId
        {
            get
            {
                return warehouseId;
            }

            set
            {
                warehouseId = value;
            }
        }

        public string ClientSettProvider
        {
            get
            {
                return clientSettProvider;
            }

            set
            {
                clientSettProvider = value;
            }
        }

        public string AdminGroup
        {
            get
            {
                return adminGroup;
            }

            set
            {
                adminGroup = value;
            }
        }

        public string UserGroup
        {
            get
            {
                return userGroup;
            }

            set
            {
                userGroup = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return createdOn;
            }

            set
            {
                createdOn = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return createdBy;
            }

            set
            {
                createdBy = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

        public DateTime UpdatedOn
        {
            get
            {
                return updatedOn;
            }

            set
            {
                updatedOn = value;
            }
        }

        public int UpdatedBy
        {
            get
            {
                return updatedBy;
            }

            set
            {
                updatedBy = value;
            }
        }

        public int IsAdmin
        {
            get
            {
                return isAdmin;
            }

            set
            {
                isAdmin = value;
            }
        }

        public string SShItemCriteria
        {
            get
            {
                return sShItemCriteria;
            }

            set
            {
                sShItemCriteria = value;
            }
        }

        public string SShEtaDateUsrDef
        {
            get
            {
                return sShEtaDateUsrDef;
            }

            set
            {
                sShEtaDateUsrDef = value;
            }
        }

        public string SShEtdDateUsrDef
        {
            get
            {
                return sShEtdDateUsrDef;
            }

            set
            {
                sShEtdDateUsrDef = value;
            }
        }

        public string SShUom1
        {
            get
            {
                return sShUom1;
            }

            set
            {
                sShUom1 = value;
            }
        }

        public string SShUom2
        {
            get
            {
                return sShUom2;
            }

            set
            {
                sShUom2 = value;
            }
        }

        public string SShMinCharge
        {
            get
            {
                return sShMinCharge;
            }

            set
            {
                sShMinCharge = value;
            }
        }

        public string SShInvcNumb
        {
            get
            {
                return sShInvcNumb;
            }

            set
            {
                sShInvcNumb = value;
            }
        }

        public string SShPerInvcNumb
        {
            get
            {
                return sShPerInvcNumb;
            }

            set
            {
                sShPerInvcNumb = value;
            }
        }

        public string SShJobCriteria
        {
            get
            {
                return sShJobCriteria;
            }

            set
            {
                sShJobCriteria = value;
            }
        }

        public string SShPriceListCriteria
        {
            get
            {
                return sShPriceListCriteria;
            }

            set
            {
                sShPriceListCriteria = value;
            }
        }

        public string SShWarehouseId
        {
            get
            {
                return sShWarehouseId;
            }

            set
            {
                sShWarehouseId = value;
            }
        }

        public string SShClientSettProvider
        {
            get
            {
                return sShClientSettProvider;
            }

            set
            {
                sShClientSettProvider = value;
            }
        }

        public string SAgItemCrieteria
        {
            get
            {
                return sAgItemCrieteria;
            }

            set
            {
                sAgItemCrieteria = value;
            }
        }

        public string SAgJobCriteris
        {
            get
            {
                return sAgJobCriteris;
            }

            set
            {
                sAgJobCriteris = value;
            }
        }

        public string SAgInvcNumb
        {
            get
            {
                return sAgInvcNumb;
            }

            set
            {
                sAgInvcNumb = value;
            }
        }

        public string SAgPerInvcNumb
        {
            get
            {
                return sAgPerInvcNumb;
            }

            set
            {
                sAgPerInvcNumb = value;
            }
        }

        public string SAgWarehouseId
        {
            get
            {
                return sAgWarehouseId;
            }

            set
            {
                sAgWarehouseId = value;
            }
        }

        public string SAgpriceListCriteria
        {
            get
            {
                return sAgpriceListCriteria;
            }

            set
            {
                sAgpriceListCriteria = value;
            }
        }

        public string SAgPriceListName
        {
            get
            {
                return sAgPriceListName;
            }

            set
            {
                sAgPriceListName = value;
            }
        }


        #endregion

        #region Methods
        public List<dbConfig> getdbList(int dbConfigId, string dbName, int userId)
        {
            try
            {
                XElement logXMl = null;
                xdoc = DBXML.dbConfig_g(dbConfigId, dbName, userId, logXMl);
                dt = SqlExe.GetDT(xdoc);
                List<dbConfig> lst = dt != null && dt.Rows.Count > 0 ? dt.AsEnumerable().Select(s => new dbConfig
                { 
                    DbConfigId = s.Field<int>("dbConfigId"),
                    DbName = s.Field<string>("dbName"),
                    DbConStr = s.Field<string>("dbConStr"),
                    DbCommonConStr = s.Field<string>("dbCommonConStr"),
                    SerialNumber = s.Field<string>("serialNumber"),
                    AuthCode = s.Field<string>("authCode"),
                    ItemCriteria = s.Field<string>("itemCriteria"),
                    EtaDateUsrDef = s.Field<string>("etaDateUsrDef"),
                    EtdDateUsrDef = s.Field<string>("etdDateUsrDef"),
                    Uom1 = s.Field<string>("uom1"),
                    Uom2 = s.Field<string>("uom2"),
                    MinCharge = s.Field<string>("minCharge"),
                    InvcNumb = s.Field<string>("invcNumb"),
                    PerInvcNumb = s.Field<string>("perInvcNumb"),
                    JobCriteria = s.Field<string>("jobCriteria"),
                    PriceListCriteria = s.Field<string>("priceListCriteria"),
                    WarehouseId = s.Field<string>("warehouseId"),
                    ClientSettProvider = s.Field<string>("clientSettProvider"),
                    AdminGroup = s.Field<string>("adminGroup"),
                    UserGroup = s.Field<string>("userGroup"),
                    IsActive = s.Field<bool>("isActive") 
                }).ToList() : null;
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        
        public dbConfig getDatabse(int dbConfigId, string dbName, int userId)
        {
            try
            {
                XElement logXMl = null;
                xdoc = DBXML.dbConfig_g(dbConfigId, dbName, userId, logXMl);
                dt = SqlExe.GetDT(xdoc);
                dbConfig lst = dt != null && dt.Rows.Count > 0 ? dt.AsEnumerable().Select(s => new dbConfig
                {
                    DbConfigId = s.Field<int>("dbConfigId"),
                    DbName = s.Field<string>("dbName"),
                    DbConStr = s.Field<string>("dbConStr"),
                    DbCommonConStr = s.Field<string>("dbCommonConStr"),
                    SerialNumber = s.Field<string>("serialNumber"),
                    AuthCode = s.Field<string>("authCode"),
                    ItemCriteria = s.Field<string>("itemCriteria"),
                    EtaDateUsrDef = s.Field<string>("etaDateUsrDef"),
                    EtdDateUsrDef = s.Field<string>("etdDateUsrDef"),
                    Uom1 = s.Field<string>("uom1"),
                    Uom2 = s.Field<string>("uom2"),
                    MinCharge = s.Field<string>("minCharge"),
                    InvcNumb = s.Field<string>("invcNumb"),
                    PerInvcNumb = s.Field<string>("perInvcNumb"),
                    JobCriteria = s.Field<string>("jobCriteria"),
                    PriceListCriteria = s.Field<string>("priceListCriteria"),
                    WarehouseId = s.Field<string>("warehouseId"),
                    ClientSettProvider = s.Field<string>("clientSettProvider"),
                    AdminGroup = s.Field<string>("adminGroup"),
                    UserGroup = s.Field<string>("userGroup"),
                    IsActive = s.Field<bool>("isActive")
                }).ToList().FirstOrDefault() : null;
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
    }
}
