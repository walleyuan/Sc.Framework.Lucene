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
        public GenericSearchResponse(SearchResults<T> results)
        {
            this.TotalResults = results.TotalSearchResults;
            this.Results = results.GetDocuments();
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