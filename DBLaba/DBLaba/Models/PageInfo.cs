using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbWarehouse.Models
{

    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItem { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItem / PageSize); }
        }

    }

    public class IndexViewModel
    {
        public List<List<Cell>> ListCell { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}