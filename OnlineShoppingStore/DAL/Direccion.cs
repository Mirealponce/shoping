//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShoppingStore.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direccion
    {
        public int idDireccion { get; set; }
        public string region { get; set; }
        public string comuna { get; set; }
        public string calle { get; set; }
        public Nullable<int> numero { get; set; }
        public int Cliente_idCliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
