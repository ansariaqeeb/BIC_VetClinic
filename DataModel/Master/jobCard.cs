using Pastel.Evolution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Master
{
    public class jobCard
    {

        #region Properties
        int _JOBID;
        string _JOBDESC;
        string _VESSEL;
        string _CUSTOMERDESC;
        int _CUSTOMERID;
        string _ADDRESS;
        DateTime _ETA;
        DateTime _ETD;
        string _CURRENCY;
        string _conStr;
        string _ETADISP;
        string _ETDDISP;
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

        public string JOBDESC
        {
            get
            {
                return _JOBDESC;
            }

            set
            {
                _JOBDESC = value;
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

        public string CUSTOMERDESC
        {
            get
            {
                return _CUSTOMERDESC;
            }

            set
            {
                _CUSTOMERDESC = value;
            }
        }

        public string ADDRESS
        {
            get
            {
                return _ADDRESS;
            }

            set
            {
                _ADDRESS = value;
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

        #endregion

        #region Mothods
        public jobCard()
        {

        }
        public jobCard(string conStr)
        {
            ConStr = conStr;
        }

        public object GetJobDt(int id, string Criteria, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode)
        {
            try
            {
                DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);
                DataTable dt;

                dt = JobCard.List(Criteria);
                object dbresult = dt != null ? (from s in dt.AsEnumerable()
                                                select new
                                                {
                                                    id = s.Field<int>("IdJCMaster"),
                                                    text = s.Field<string>("cJobCode")
                                                }).ToList() : null;


                return dbresult;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public jobCard getJobDetailsById(int jobId, string dbConnectionString, string evolutionCommonDBConnectionString, string serialNumber, string authCode, string ETADATEUSRDEF, string ETDDATEUSRDEF)
        {
            try
            {
                DatabaseContext.Initialise(dbConnectionString, evolutionCommonDBConnectionString, serialNumber, authCode);

                jobCard origobj = new jobCard();//this class is created in our application

                JobCard obj = new JobCard(jobId);//This is evolution class we are passing selected jobid to it 

                Customer cudt1 = obj.Account; //Creating Object of customer class from jobcard object.Account

                origobj.JOBDESC = obj.Description != null ? obj.Description : "";

                origobj.VESSEL = cudt1.Description != null ? cudt1.Description : "";//Getting description from customer class for vessel

                origobj.CURRENCY = cudt1.Currency != null ? cudt1.Currency.Description != null ? cudt1.Currency.Description : "" : "";//getting currency from customer objec

                int MainAccountID = cudt1.MainAccountID; //getting main account id 

                if (MainAccountID != 0)
                {
                    origobj.CUSTOMERDESC = new Customer(MainAccountID).Description;//getting customer description from main account id 

                    origobj.CUSTOMERID = new Customer(MainAccountID).ID;//getting customer id

                    origobj.ADDRESS = new Customer(MainAccountID).PhysicalAddress.ToString();//getting physical address
                }


                origobj.ETA = Convert.ToDateTime(obj.UserFields[ETADATEUSRDEF]);//getting user define columns value for ETA

                origobj.ETD = Convert.ToDateTime(obj.UserFields[ETDDATEUSRDEF]); //getting user define columns value for ETD

                return origobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
