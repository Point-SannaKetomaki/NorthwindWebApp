using NorthwindWebApp_SKe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWebApp_SKe.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            northwindEntities entities = new northwindEntities();
            try
            {
                List<Customers> model = entities.Customers.ToList();
                return View(model);
            }
            finally
            {
                entities.Dispose();
            }
        }

        public ActionResult GetOrderData(string id)  //id-parametri tulee MVC-mallin oletusreiteistä => mitä tarkoittaa ????
        {
            northwindEntities entities = new northwindEntities();
            try
            {
                List<Orders> orders = (from o in entities.Orders
                                       where o.CustomerID == id
                                       orderby o.OrderDate descending
                                       select o).ToList();

                StringBuilder html = new StringBuilder();       //lisätään html-dataa taulukkoon
                html.AppendLine("<td colspan = \"5\">" +
                     "<table class=\"table table-striped\">");

                foreach (Orders order in orders)
                {
                    html.AppendLine("<tr><td>" +
                        order.OrderDate.Value.ToShortDateString() + "</td>" +
                        "<td>" + order.OrderDate + "</td>" +
                        "<td>" + order.ShipCity + "</td>" +
                        "<td>" + order.RequiredDate.Value.ToShortDateString() + "</td></tr>");
                }
                    html.AppendLine("</table></td>");

               // html.Append("Hello!");              //testataan, että kaikki toimii, että Ajax-kutsu toimii oikein!

                var jsonData = new { html = html.ToString() };  //palautetaan json-dataa, tässä vielä "Hello!"
                return Json(jsonData,JsonRequestBehavior.AllowGet); //palautetaan json -muodossa, HTTP-pyyntö GET, sallitaan GET
            }
            finally
            {
                entities.Dispose();
            }
        }
    }
}