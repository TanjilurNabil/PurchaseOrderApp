using PurchaseOrder.Models;
using PurchaseOrder.Models.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PurchaseOrder.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult PurchaseForm()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<JsonResult> SavePurchaseRequest(PurchaseRequestBodyModel requestBody)
        {
            try
            {
                var data = await PurchaseGateway.SavePurchaseRequest(requestBody);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}