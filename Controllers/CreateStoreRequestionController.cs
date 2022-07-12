using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class CreateStoreRequisitionsController : Controller
    {
        // GET: CreateStoreRequestion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateStoreRequisition()
        {
            return View();
        }
    }
}