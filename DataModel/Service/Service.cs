using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace DataModel.Service
{
    public class Service
    {
        #region Properties
        XDocument xdoc;
        DataTable dt;
        DataModel.Result.Result err = new DataModel.Result.Result();

        int serviceId;
        string serviceName;
        string dbConStr;
        string dbCommonConStr;
        string serialNumber;
        string authCode;
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
        string adminGroup;
        string userGroup;
        DateTime createdOn;
        int createdBy;
        bool isActive;
        DateTime updatedOn;
        int updatedBy;

        public int ServiceId
        {
            get
            {
                return serviceId;
            }

            set
            {
                serviceId = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return serviceName;
            }

            set
            {
                serviceName = value;
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
        #endregion

        #region Methods
        public List<Service> getServiceList(int serviceId,string serviceName, int userId)
        {
            try
            {
                XElement logXMl = null;
                xdoc = DBXML.serviceConfig_g(serviceId,serviceName, userId, logXMl);
                dt = SqlExe.GetDT(xdoc);
                List<Service> lst = dt!=null && dt.Rows.Count>0?  dt.AsEnumerable().Select(s => new Service
                {
                    ServiceName = s.Field<string>("ServiceName"),
                    serviceId = s.Field<int>("serviceId"),
                    dbConStr = s.Field<string>("dbConStr"),
                    dbCommonConStr = s.Field<string>("dbCommonConStr"),
                    serialNumber = s.Field<string>("serialNumber"),
                    authCode = s.Field<string>("authCode")
                }).ToList(): null;
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
