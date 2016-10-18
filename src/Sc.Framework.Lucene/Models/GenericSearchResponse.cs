// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericSearchResponse.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   The search response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sc.Framework.Lucene.Models
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Extensions;
    using Sitecore.ContentSearch.Linq;

    /// <summary>
    /// The search response.
    /// </summary>
    /// <typeparam name="T">
    /// The type of search response.
    /// </typeparam>
    public class GenericSearchResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSearchResponse{T}"/> class.
        /// </summary>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <param name="page">
        /// The page Number.
        /// </param>
        /// <param name="perPage">
        /// The per Page.
        /// </param>
        /// <param name="orderBy">
        /// The order By.
        /// </param>
        /// <param name="propertyName">
        /// The property Name.
        /// </param>
        public GenericSearchResponse(
            SearchResults<T> results,
            int page,
            int perPage, 
            SortOrder orderBy,
            string propertyName)
        {
            this.TotalResults = results.TotalSearchResults;
            this.Results = results.GetDocuments(page, perPage, orderBy, propertyName);
            this.Facets = results.Facets;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSearchResponse{T}"/> class.
        /// </summary>
        /// <param name="results">
        /// The results.
        /// </param>
        public GenericSearchResponse(SearchResults<T> results)
        {
            this.TotalResults = results.TotalSearchResults;
            this.Results = results.GetDocuments();
            this.Facets = results.Facets;
        }


        public GenericSearchResponse(
           SearchResults<T> results,
           int page,
           int perPage)
        {
            this.TotalResults = results.TotalSearchResults;
            this.Results = results.GetDocuments(page, perPage);
            this.Facets = results.Facets;
        }

        /// <summary>
        /// Gets or sets the facets.
        /// </summary>
        public FacetResults Facets { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public IList<T> Results { get; set; }

        /// <summary>
        /// Gets or sets the total results.
        /// </summary>
        public int TotalResults { get; set; }
    }
}