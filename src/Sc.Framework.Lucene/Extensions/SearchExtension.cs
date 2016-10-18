// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchExtension.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   The search extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sc.Framework.Lucene.Extensions
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Sitecore.ContentSearch.Linq;

    /// <summary>
    /// The search extension.
    /// </summary>
    public static class SearchExtension
    {
        /// <summary>
        /// The get documents.
        /// </summary>
        /// <param name="searchResults">
        /// The search results.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public static IList<T> GetDocuments<T>(this SearchResults<T> searchResults)
        {
            return searchResults.Hits.Select(h => h.Document).ToList();
        }
    }
}
