# Sc.Framework.Lucene 

## Introduction
The purpose of Sc.Framework.Lucene is to create a more generic search function for Sitecore projects.


## How to install

To install [Sc.Framework.Lucence](https://www.nuget.org/packages/Sc.Framework.Lucene/), run the following command in the Package Manager Console .

Install-Package Sc.Framework.Lucene 
 

## How to use
1. Create resultItem by inheriting from SearchResultItem
    ```
        public class EventsResultItem : SearchResultItem
        {
            [IndexField("Title")]
            public string Title { get; set; }
        }
    ```

2. Create search interface and inherits from IBeaseSearchService
    ```  
        public interface IEventsSearchService : IBaseSearchService<EventsResultItem>
        {
            //custom functions
        }
    ```

3. Create service service 

    ```
         public class ClaimSearchService : BaseSearchService<EventsResultItem>, IEventsSearchService
        {
            public override ISearchIndex Index => ContentSearchManager.GetIndex(Settings.GetSetting("EventsIndexName"));
        }
    ```