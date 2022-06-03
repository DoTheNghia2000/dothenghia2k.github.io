using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dothenghia_shop.Models
{
    [Serializable]
    public class CartItem
    {
        public SANPHAM Product { set; get; }
        public int Quantity { set; get; }
    }
}