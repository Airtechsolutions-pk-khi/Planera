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
    public class GalleryBLL
    {
        public int GalleryID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public static List<GalleryBLL> GetAll()
        {
            try
            {
                var lst = new List<GalleryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetProjectWeb_PlnInt");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<GalleryBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<GalleryBLL> GetGalleryAcBah()
        {
            try
            {
                var lst = new List<GalleryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetGalleryWeb_AcBah");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<GalleryBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<GalleryBLL> GetGalleryAcDub()
        {
            try
            {
                var lst = new List<GalleryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetGalleryWeb_AcDub");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<GalleryBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<GalleryBLL> GetGalleryHrCnt()
        {
            try
            {
                var lst = new List<GalleryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetGalleryWeb_HrCnt");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<GalleryBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<GalleryBLL> GetGalleryHrRpr()
        {
            try
            {
                var lst = new List<GalleryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetGalleryWeb_HrRpr");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<GalleryBLL>>();
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