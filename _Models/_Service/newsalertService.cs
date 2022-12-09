using BAL.Repositories;
using Planera.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace planera.Models.Service
{
    public class newsalertService : baseService
    {
        NewsAlertBLL _service;
        public newsalertService()
        {
            _service = new NewsAlertBLL();
        }

        public List<NewsAlertBLL> GetAll()
        {
            try
            {
                return _service.GetAll();

            }
            catch (Exception ex)
            {
                return new List<NewsAlertBLL>();
            }
        }
        public List<NewsAlertBLL> GetNews()
        {
            try
            {
                return _service.GetNews();

            }
            catch (Exception ex)
            {
                return new List<NewsAlertBLL>();
            }
        }
        public List<NewsAlertBLL> GetEvents()
        {
            try
            {
                return _service.GetEvents();

            }
            catch (Exception ex)
            {
                return new List<NewsAlertBLL>();
            }
        }
    }
}