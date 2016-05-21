// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseSearchService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   The BaseSearchService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sc.Framework.Lucene.Interfaces
{
    using System;
    using System.Data.SqlClient;
    using System.Linq.Expressions;

    using Sc.Framework.Lucene.Models;

    using Sitecore.ContentSearch;

    /// <summary>
    /// The BaseSearchService interface.
    /// </summary>
    /// <typeparam name="T">
    /// Type of class that you want to search.
    /// </typeparam>
    public interface IBaseSearchService<T> where T : class
    {
        /// <summary>
        /// Gets the index.
        /// </summary>
        ISearchIndex Index { get; }

        /// <summary>
        /// Gets all items in the index file.
        /// </summary>
        /// <returns>
        /// The search response.
        /// </returns>
        GenericSearchResponse<T> All();

        /// <summary>
        /// Gets specified items on specified page.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="perPage">
        /// The per page.
        /// </param>
        /// <returns>
        /// The search response.
        /// </returns>
        GenericSearchResponse<T> All(int page, int perPage);

        /// <summary>
        /// Gets specified items by property name on specified page.
        /// </summary>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="perPage">
        /// The per page.
        /// </param>
        /// <returns>
        /// The search response.
        /// </returns>
        GenericSearchResponse<T> All(SortOrder orderBy, string propertyName, int page, int perPage);

        /// <summary>
        /// Gets specified items by expression.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The search response.
        /// </returns>
        GenericSearchResponse<T> Search(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets specified items by expression on specified page.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="perPage">
        /// The per page.
        /// </param>
        /// <returns>
        /// The search response.
        /// </returns>
        GenericSearchResponse<T> Search(
            Expression<Func<T, bool>> filter, 
            int page, 
            int perPage);

        /// <summary>
        /// Gets specified items by expression on specified page with a specific order.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="perPage">
        /// The per page.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The search response.
        /// </returns>
        GenericSearchResponse<T> Search(
            Expression<Func<T, bool>> filter, 
            int page, 
            int perPage, 
            SortOrder orderBy, 
            string propertyName);
    }
}