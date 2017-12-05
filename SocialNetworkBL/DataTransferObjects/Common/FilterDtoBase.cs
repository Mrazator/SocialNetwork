namespace SocialNetworkBL.DataTransferObjects.Common
{
    public class FilterDtoBase
    {
        /// <summary>
        ///     Number of page (indexed from 1) which was requested
        /// </summary>
        public int? RequestedPageNumber { get; set; } = 1;

        /// <summary>
        ///     Size of the page
        /// </summary>
        public int PageSize { get; set; } = 5;

        /// <summary>
        ///     Name of the property for sorting query results
        /// </summary>
        public string SortCriteria { get; set; }

        /// <summary>
        ///     Determines whether ASC sorting should be used
        /// </summary>
        public bool SortAscending { get; set; }
    }
}