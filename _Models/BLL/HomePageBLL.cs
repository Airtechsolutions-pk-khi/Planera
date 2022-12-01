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
    public class HomePageBLL
    {
        public int HomePageID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public static List<HomePageBLL> GetAll()
        {
            try
            {
                var lst = new List<HomePageBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetHomeImage_PlnInt");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<HomePageBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static List<HomePageBLL> GetACBH()
        {
            try
            {
                var lst = new List<HomePageBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetHomeImage_AcBah");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<HomePageBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }

        }     
        public static List<HomePageBLL> GetACDB()
        {
            try
            {
                var lst = new List<HomePageBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetHomeImage_AcDub");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<HomePageBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static List<HomePageBLL> GetCont()
        {
            try
            {
                var lst = new List<HomePageBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetHomeImage_HrCnt");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<HomePageBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<HomePageBLL> GetHarmano()
        {
            try
            {
                var lst = new List<HomePageBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetHomeImage_HrRpr");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<HomePageBLL>>();
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