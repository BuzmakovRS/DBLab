using DbWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace DbWarehouse.Stored_Procedures
{
    public static class StorProcedures
    {

        internal static List<List<Cell>> GetTable()
        {
            List<List<Cell>> listResult = new List<List<Cell>>();
            try
            {
                using (WarehouseContext db = new WarehouseContext())
                {
                    using (var cmd = db.Database.Connection.CreateCommand())
                    {
                        db.Database.Connection.Open();
                        string sqlExpression = "show_products";
                        cmd.CommandText = sqlExpression;
                        cmd.CommandType = CommandType.StoredProcedure;
                        StringBuilder sql = new StringBuilder();
                        var tran = db.Database.Connection.BeginTransaction();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                sql.AppendLine($"FETCH ALL IN \"{reader.GetString(0)}\";");


                            using (var cmd2 = db.Database.Connection.CreateCommand())
                            {
                                cmd2.Connection = cmd.Connection;
                                cmd2.Transaction = cmd.Transaction;
                                cmd2.CommandTimeout = cmd.CommandTimeout;
                                cmd2.CommandText = sql.ToString();
                                cmd2.CommandType = CommandType.Text;

                                //Execute cmd2 and process the results as normal
                                using (var reader2 = cmd2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        List<Cell> listCell = new List<Cell>();
                                        for (int i = 0; i < reader2.FieldCount; i++)
                                        {
                                            listCell.Add(new Cell { Title = reader2.GetName(i), Value = reader2.GetValue(i).ToString() });
                                        }
                                        listResult.Add(new List<Cell>(listCell));
                                    }
                                }
                            }


                        }
                        tran.Commit();
                        db.Database.Connection.Close();
                    }
                }
                return listResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listResult; ;
        }
    }
}