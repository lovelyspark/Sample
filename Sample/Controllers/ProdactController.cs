using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Config;
using Sample.Models;

namespace Sample.Controllers
{
    public class ProdactController : Controller
    {
        // GET: Prodact
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Prodact prodact)
        {
            using (SqlConnection con = new SqlConnection(DataBase.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("insert into Prodacts(Name,Price,Supplier) values('" + prodact.Name + "','" + prodact.Price + "','" + prodact.Supplier + "')" ,con))
                {

                    if (con.State != System.Data.ConnectionState.Open)
                            con.Open();
                

                cmd.ExecuteNonQuery();

                }
            }
           return Content("Result is saved in database:");
        }
        public ActionResult viewall()
        {
            List<Prodact> prodact = new List<Prodact>();
            using (SqlConnection connect = new SqlConnection(DataBase.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Prodacts", connect))
                {
                    if (connect.State != System.Data.ConnectionState.Open)
                        connect.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dtProdacts = new DataTable();
                    dtProdacts.Load(sdr);
                    foreach (DataRow row in dtProdacts.Rows)
                    {
                        prodact.Add(
                            new Prodact
                            {
                                Id = Convert.ToInt32(row["id"]),
                                Name = row["Name"].ToString(),
                                Price = Convert.ToDecimal(row["Price"]),
                                Supplier = row["Supplier"].ToString()
                            }
                            );
                    }
                }

            }
                return View(prodact);
        }
         
    }
}