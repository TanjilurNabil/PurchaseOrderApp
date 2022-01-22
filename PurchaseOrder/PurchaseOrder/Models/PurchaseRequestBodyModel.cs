using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrder.Models
{
    public class PurchaseRequestBodyModel
    {
        public string PurchaseCode { get; set; }
        public string PurchaseDate { get; set; }
        public string Supplier { get; set; }
        public List<ItemListTVP> Item { get; set; }
    }

    public class ItemListTVP
    {
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public int PurchaseReqId { get; set; }
    }
}