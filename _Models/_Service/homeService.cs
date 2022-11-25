using BAL.Repositories;
using Planera.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace planera.Models.Service
{
    public class homeService : baseService
    {
       HomePageBLL _service;
        public homeService()
        {
            _service = new HomePageBLL();
        }

        public List<HomePageBLL> GetAll()
        {
            try
            {
                return HomePageBLL.GetAll();
            }
            catch (Exception ex)
            {
                return new List<HomePageBLL>();
            }
        }
    }
}