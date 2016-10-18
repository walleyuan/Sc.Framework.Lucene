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
        /// Get search results documents
        /// </summary>
        /// <typeparam name="T">
        /// search result type.
        /// </typeparam>
        /// <param name="searchResults">
        /// results
        /// </param>
        /// <param name="page">
        /// page.
        /// </param>
        /// <param name="perPage">
        /// page size.
        /// </param>
        /// <param name="orderBy">
        /// order by.
        /// </param>
        /// <param name="propertyName">
        /// property name.
        /// </param>
        /// <returns>
        /// Return search documents.
        /// </returns>
        public static IList<T> GetDocuments<T>(
            this SearchResults<T> searchResults,
            int page,
            int perPage,
            SortOrder orderBy,
            string propertyName)
        {
            var skipNumber = page == 1 ? 0 : (page - 1) * perPage;

            return
                searchResults.Hits.SortBy(orderBy, propertyName)
                    .Skip(skipNumber)
                    .Take(perPage)
                    .Select(h => h.Document)
                    .ToList();
        }

        /// <summary>
        /// The get documents.
        /// </summary>
        /// <param name="searchResults">
        /// The search results.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="perPage">
        /// The per page.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public static IList<T> GetDocuments<T>(
           this SearchResults<T> searchResults,
           int page,
           int perPage)
        {
            var skipNumber = page == 1 ? 0 : (page - 1) * perPage;

            return
                searchResults.Hits
                    .Skip(skipNumber)
                    .Take(perPage)
                    .Select(h => h.Document)
                    .ToList();
        }

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
