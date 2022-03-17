using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Project.Search.Controllers
{
    public class CustomSearchController : ApiController
    {
        [Route("altudoapi/handlesearch")]
        [HttpPost]
        public IHttpActionResult HandleSearch(SearchParam param)
        {
            List<SearchResult> searchResult = new List<SearchResult>();
            var contextDB = Sitecore.Context.Database;
            //get your index instance
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");

            //Create serach index
            using(IProviderSearchContext searchContext=searchIndex.CreateSearchContext())
            {
                var searchResultFromSolr=searchContext.GetQueryable<SearchResultItem>()
                                                       .Where(x=>x.TemplateName=="HealthArticle")
                                                       .Where(x=>x.Content.Contains(param.searchKeyword))
                                                       .Select(x=> new SearchResult
                                                       {
                                                        SearchTitle=Convert.ToString(x.Fields["title_t"]),
                                                        SearchBrief = Convert.ToString(x.Fields["brief_t"])
                                                     }).ToList();

                searchResult = searchResultFromSolr;
            }
            //do query
            return Json(searchResult);
        }
    }
    public class SearchResult
    {
        public string SearchTitle { get; set; }
        public string SearchBrief { get; set; }
        public string SearchTileUrl{ get; set; }
    }
    public  class SearchParam
    {
        public string searchKeyword { get; set; }
    }

}
