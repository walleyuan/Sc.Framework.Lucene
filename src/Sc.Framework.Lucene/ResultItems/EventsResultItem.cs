// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventsResultItem.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the EventsResultItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sc.Framework.Lucene.ResultItems
{
    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.SearchTypes;

    /// <summary>
    /// The events result item.
    /// </summary>
    public class EventsResultItem : SearchResultItem
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [IndexField("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        [IndexField("Tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        [IndexField("imageurl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        [IndexField("summary")]
        public string Summary { get; set; }
    }
}
