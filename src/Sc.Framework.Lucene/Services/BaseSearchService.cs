// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSearchService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   The BaseSearchService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sc.Framework.Lucene.Services
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using Interfaces;
    using Models;
    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Linq;

    /// <summary>
    /// The BaseSearchService interface.
    /// </summary>
    /// <typeparam name="T">
    /// Type of class that you want to search.
    /// </typeparam>
    public class BaseSearchService<T> : IBaseSearchService<T> where T : class
    {
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public virtual ISearchIndex Index { get; set; }

        /// <summary>
        /// Gets all items in the index file.
        /// </summary>
        /// <returns>
        /// The search response.
        /// </returns>
        public virtual GenericSearchResponse<T> All()
        {
            using (var context = this.Index.CreateSearchContext())
            {
                IQueryable<T> allResults = null;

                allResults = context.GetQueryable<T>();

                var response = new GenericSearchResponse<T>(allResults.GetResults());

                return response;
            }
        }

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
        public virtual GenericSearchResponse<T> All(int page, int perPage)
        {
            using (var context = this.Index.CreateSearchContext())
            {
                IQueryable<T> allResults = null;

                allResults = context.GetQueryable<T>().Page(page - 1, perPage);

                var response = new GenericSearchResponse<T>(allResults.GetResults());

                return response;
            }
        }

        /// <summary>
        /// The all.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="perPage">
        /// The per page.
        /// </param>
        /// <param name="orderType">
        /// The order By.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <typeparam name="T">
        /// The type of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The property of the source.
        /// </typeparam>
        /// <returns>
        /// The search results response.
        /// </returns>
        public GenericSearchResponse<T> All<T, TKey>(int page, int perPage, SortOrder orderType, Expression<Func<T, TKey>> sortExpression)
        {
            using (var context = this.Index.CreateSearchContext())
            {
                IQueryable<T> allResults = null;

                allResults = orderType == SortOrder.Descending
                                ? context.GetQueryable<T>()
                                      .OrderByDescending(sortExpression)
                                      .Page(page, perPage)
                                : context.GetQueryable<T>().OrderBy(sortExpression).Page(page - 1, perPage);

                var response = new GenericSearchResponse<T>(allResults.GetResults());

                return response;
            }
        }

        /// <summary>
        /// Gets specified items by expression.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The search response.
        /// </returns>
        public virtual GenericSearchResponse<T> Search(Expression<Func<T, bool>> filter)
        {
            using (var context = this.Index.CreateSearchContext())
            {
                IQueryable<T> allResults = null;

                allResults = context.GetQueryable<T>().Where(filter);

                var response = new GenericSearchResponse<T>(allResults.GetResults());

                return response;
            }
        }

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
        public virtual GenericSearchResponse<T> Search(
            Expression<Func<T, bool>> filter,
            int page,
            int perPage)
        {
            using (var context = this.Index.CreateSearchContext())
            {
                IQueryable<T> allResults = null;

                allResults = context.GetQueryable<T>().Where(filter).Page(page - 1, perPage);

                var response = new GenericSearchResponse<T>(allResults.GetResults());

                return response;
            }
        }

        /// <summary>
        /// The search.
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
        /// <param name="orderType">
        /// The ordering type.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <typeparam name="T">
        /// The type of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The property of the source.
        /// </typeparam>
        /// <returns>
        /// The search results response.
        /// </returns>
        public virtual GenericSearchResponse<T> Search<T, TKey>(
            Expression<Func<T, bool>> filter,
            int page,
            int perPage,
            SortOrder orderType,
            Expression<Func<T, TKey>> sortExpression)
        {
            using (var context = this.Index.CreateSearchContext())
            {
                IQueryable<T> allResults = null;

                allResults = orderType == SortOrder.Descending
                                 ? context.GetQueryable<T>()
                                       .Where(filter)
                                       .OrderByDescending(sortExpression)
                                       .Page(page, perPage)
                                 : context.GetQueryable<T>().Where(filter).OrderBy(sortExpression).Page(page - 1, perPage);

                var response = new GenericSearchResponse<T>(allResults.GetResults());

                return response;
            }
        }
    }
}