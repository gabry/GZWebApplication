using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZWebApplication.Models
{
    /// <summary>
    /// A Company
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Company Id.
        /// Mandatory in PUT.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Company Description.
        /// Mandatory in POST and PUT.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Company VAT Code.
        /// </summary>
        public string VATCode { get; set; }
    }
}