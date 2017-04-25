using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbWarehouse.Models
{
    public class Cell
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int TypeId { get; set; }


        public enum EnumTypeColumn
        {
            _string = 1,
            _int,
            _double,
            _bool,
            _datetime
        }

    }
}