using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPICode.Helpers;

namespace Planera.Model
{
    public class ServiceBLL
    {
        public int ServiceID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public string ImagePath { get; set; }
        public string IconImage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public static List<ServiceBLL> GetAll()
        {
            try
            {
                var lst = new List<ServiceBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetServiceWeb_PlInt");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<ServiceBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}