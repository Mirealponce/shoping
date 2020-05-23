using OnlineShoppingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class Carrito
    {
        
        private int cantidad;
        private Producto productos ;
        public Carrito()
        {

        }
       
        public int Cantidad { get; set; }
        public Producto Productos { get; set; }

    }
}