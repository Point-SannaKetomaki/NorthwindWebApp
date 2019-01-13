using NorthwindWebApp_SKe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWebApp_SKe.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            northwindEntities entities = new northwindEntities(); //luodaan luokan ilmentymä eli instanssi

            //malliolion = model-olion avulla haetaan tietokannasta kaikki Customers-taulun tiedot
            List<Customers> model = entities.Customers.ToList();

            entities.Dispose(); //vapautetaan resurssit, joita käytettiin tietokantahakuun
            
            //näkymälle annetaan parametriksi malliolio
            return View(model);
        }
    }
}