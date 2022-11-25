using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planera.Model
{
    public class BookNow
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public string Time { get; set; }
        public string Details { get; set; }
    }
}