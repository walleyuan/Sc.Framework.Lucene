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
        /// Gets documents.
        /// </summary>
        /// <param name="searchResults">
        /// The search results.
        /// </param>
        /// <typeparam name="T">
        /// Type of class that you want to get.
        /// </typeparam>
        /// <returns>
        /// The document list.
        /// </returns>
        public static IList<T> GetDocuments<T>(this SearchResults<T> searchResults)
        {
            return searchResults.Hits.Select(h => h.Document).ToList();
        }

        /// <summary>
        /// Sort collection by property name with specified sort order.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="T">
        /// Type of class that you want to get.
        /// </typeparam>
        /// <returns>
        /// The document list.
        /// </returns>
        public static List<T> SortBy<T>(this IEnumerable<T> collection, SortOrder order, string propertyName) where T : class
        {
            var enumerable = collection as IList<T> ?? collection.ToList();

            if (enumerable.Any())
            {
                if (enumerable[0].GetType().GetProperty(propertyName) != null)
                {
                    return order == SortOrder.Descending ?
                            enumerable.OrderByDescending(c => c.GetType().GetProperty(propertyName).GetValue(c, null)).ToList() :
                            enumerable.OrderBy(c => c.GetType().GetProperty(propertyName).GetValue(c, null)).ToList();
                }
            }

            return enumerable.ToList();
        }
    }
}
