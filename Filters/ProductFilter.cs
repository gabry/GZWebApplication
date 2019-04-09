namespace GZWebApplication.Filters
{
    /// <summary>
    /// Filter Product
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Filter Id
        /// </summary>
        public GZIntFilter FilterId { get; set; }
        /// <summary>
        /// Filter Name
        /// </summary>
        public GZStringFilter Name { get; set; }
        /// <summary>
        /// Filter Category
        /// </summary>
        public GZStringFilter Category { get; set; }
        /// <summary>
        /// Filter Price
        /// </summary>
        public GZIntFilter Price { get; set; }
    }
}