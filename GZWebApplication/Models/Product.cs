using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZWebApplication.Models
{
    /// <summary>
    /// A Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public int? Price { get; set; }
    }
}