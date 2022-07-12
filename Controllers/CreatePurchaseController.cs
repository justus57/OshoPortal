using OshoPortal.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class CreatePurchaseController : Controller
    {
        public string username { get; private set; }

        // GET: CreatePurchase view
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreatePurchase()
        {
            username = System.Web.HttpContext.Current.Session["Username"].ToString();
            try
            {
               string items = ItemRequest.itemList(username);
                ViewBag.itemlist = items;
            }
            catch(Exception et)
            {

            }
            return View();
        }
    }
}