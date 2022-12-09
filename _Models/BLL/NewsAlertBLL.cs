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
    public class NewsAlertBLL
    {
        public int NewsEventID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public string Pagename { get; set; }
        public string Image { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public List<NewsAlertBLL> GetAll()
        {
            try
            {
                var lst = new List<NewsAlertBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetNewsHome_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<NewsAlertBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<NewsAlertBLL> GetNews()
        {
            try
            {
                var lst = new List<NewsAlertBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetNews_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<NewsAlertBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<NewsAlertBLL> GetEvents()
        {
            try
            {
                var lst = new List<NewsAlertBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetEvent_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<NewsAlertBLL>>();
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