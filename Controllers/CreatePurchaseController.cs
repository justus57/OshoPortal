using Newtonsoft.Json.Linq;
using OshoPortal.Modules;
using OshoPortal.Webportal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class CreatePurchaseController : Controller
    {
        

        // GET: CreatePurchase view
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreatePurchase()
        {
            
            try
            {
            //    var username = System.Web.HttpContext.Current.Session["UserProfile"].ToString();
            //  var productslist = createRequisition.Requisition(username);

            //    dynamic json = JObject.Parse(productslist);
            //    foreach (dynamic item  in productslist)
            //    {
                    
            //    }
               
                //ViewBag.itemlist = item;

            }
            catch(Exception es)
            {

            }
            return View();

        }
    }
}