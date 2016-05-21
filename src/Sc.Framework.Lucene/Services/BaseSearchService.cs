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

    using Extensions;
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
                var allResults = context.GetQueryable<T>().GetResults();

                var response = new GenericSearchResponse<T>(allResults);

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
            var skipNumber = page == 1 ? 0 : (perPage - 1) * perPage;

            var response = this.All();

            response.Results = response.Results.Skip(skipNumber).Take(perPage).ToList();

            return response;
        }

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
        public virtual GenericSearchResponse<T> All(SortOrder orderBy, string propertyName, int page, int perPage)
        {
            var skipNumber = page == 1 ? 0 : (perPage - 1) * perPage;

            var response = this.All();

            response.Results = response.Results.SortBy(orderBy, propertyName).Skip(skipNumber).Take(perPage).ToList();

            return response;
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
                var allResults = context.GetQueryable<T>().Where(filter).GetResults();

                var response = new GenericSearchResponse<T>(allResults);

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
            var skipNumber = page == 1 ? 0 : (page - 1) * perPage;

            var response = this.Search(filter);

            response.Results = response.Results.Skip(skipNumber).Take(perPage).ToList();

            return response;
        }

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
        public virtual GenericSearchResponse<T> Search(
            Expression<Func<T, bool>> filter,
            int page,
            int perPage,
            SortOrder orderBy,
            string propertyName)
        {
            var skipNumber = page == 1 ? 0 : (page - 1) * perPage;

            var response = this.Search(filter);

            response.Results = response.Results.SortBy(orderBy, propertyName).Skip(skipNumber).Take(perPage).ToList();

            return response;
        }
    }
}