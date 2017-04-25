using DbWarehouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;

namespace DbWarehouse.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
        WarehouseContext db = new WarehouseContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Result(string tableName = "Products")
        {
            try
            {
               List<List<Cell>> listResult = new List<List<Cell>>();
                //using (var cmd = db.Database.Connection.CreateCommand())
                //{

                //    db.Database.Connection.Open();

                //    string request = "SELECT * FROM public.\"" + tableName + "\"";
                //    cmd.CommandText = request;
                //    using (var reader = cmd.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            List<Cell> listCell = new List<Cell>();
                //            for (int i = 0; i < reader.FieldCount; i++)
                //            {
                //                listCell.Add(new Cell { Title = reader.GetName(i), Value = reader.GetValue(i).ToString() });
                //            }
                //            listResult.Add(new List<Cell>(listCell));
                //        }
                //    }
                //}
                listResult = Stored_Procedures.StorProcedures.GetTable();
                return View(listResult);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        public List<List<Cell>> Read(DbDataReader reader)
        {
            //List<Dictionary<string, object>>expansionList = new List<Dictionary<string, object>>();
            //foreach (var item in reader)
            //{
            //    IDictionary<string, object> expansion = new ExpandoObject();
            //    foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
            //    {
            //        var obj = propertyDescriptor.GetValue(item);
            //        var type = propertyDescriptor.PropertyType.BaseType.Name;
            //        expansion.Add(type, obj);
            //    }
            //    expansionList.Add(new Dictionary<string, object>(expansion));
            //}
            List<List<Cell>> expansionList = new List<List<Cell>>();
            foreach (var item in reader)
            {
                List<Cell> expansion = new List<Cell>();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
                {
                    Cell cell = new Cell();
                    cell.Title = propertyDescriptor.Name;
                    cell.Value = propertyDescriptor.GetValue(item).ToString();

                    expansion.Add(cell);
                }
                expansionList.Add(new List<Cell>(expansion));
            }
            return expansionList;
        }

        #region Other definition 


        // GET: Warehouse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Warehouse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Warehouse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
