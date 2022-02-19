using MVCExamMain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExamMain.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Products> list = new List<Products>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJan22;Integrated Security=True;Connect Timeout=30;";
            cn.Open();

            SqlCommand cmdPdk = new SqlCommand();
            cmdPdk.CommandType = System.Data.CommandType.Text;
            cmdPdk.CommandText = "select * from Products";
            try
            {
                SqlDataReader dr = cmdPdk.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Products
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        Rate = (decimal)dr["Rate"],
                        Description = (string)dr["Description"],
                        CategoryName = (string)dr["CategoryName"]
                    });
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
            finally {
                cn.Close();
            }
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJan22;Integrated Security=True;Connect Timeout=30;";
            cn.Open();

            SqlCommand cmdPdk = new SqlCommand();
            cmdPdk.CommandType = System.Data.CommandType.Text;
            cmdPdk.CommandText = "update Products set ProductName = @ProductName,Rate = @Rate,Description = @Description,CategoryName = @CategoryName where ProductId = @ProductId";

            cmdPdk.Parameters.AddWithValue("ProductName",obj.ProductName);
            cmdPdk.Parameters.AddWithValue("Rate", obj.Rate);
            cmdPdk.Parameters.AddWithValue("Description", obj.Description);
            cmdPdk.Parameters.AddWithValue("CategoryName", obj.CategoryName);
            cmdPdk.Parameters.AddWithValue("ProductId", id);

            try
            {
                cmdPdk.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally {
                cn.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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
    }
}
