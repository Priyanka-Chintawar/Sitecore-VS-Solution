using AltudoBatch1.Project.Search.Models;
using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Project.Search.Controllers
{
    public class StandardSearchController : ApiController
    {
        [Route("altudoapi/StandardResult")]
        [HttpPost]
        public IHttpActionResult GetStandardSearchResult(SearchParam param)
        {
            var contextDB = Sitecore.Context.Database;
            List<StandardSearchResult> serachResults = new List<StandardSearchResult>();
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");
            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                serachResults = searchContext.GetQueryable<SearchOutputModel>()
                .Where(x => x.TemplateName == "HealthArticle")
                .Where(x => x.SearchTitle.Contains(param.searchKeyword)) 
                .Where(x => x.SearchBrief.Contains(param.searchKeyword))
                .Select(x => new StandardSearchResult
                {
                    SearchTitle = x.SearchTitle,
                    SearchBrief = x.SearchBrief,
                    SearchTileUrl = x.ArticleUrl,
                    SearchImageUrl = x.ArticleImageUrl
                }).ToList();
            }
            return Json(serachResults);
        }
        //public IHttpActionResult GetStandardSearchResult(SearchParam param)
        //{
        //    var contextDB = Sitecore.Context.Database;
        //    List<StandardSearchResult> searchResult = new List<StandardSearchResult>();
        //    ISearchIndex searchIndex=ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");
        //    using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
        //    {
        //        searchResult=searchContext.GetQueryable<SearchOutputModel>()
        //                                  .Where(x => x.TemplateName == "HealthArticle")
        //                                  .Where(x => x.SearchTitle.Contains(param.searchKeyword)|| x.SearchBrief.Contains(param.searchKeyword))

        //                                  .Select(x => new StandardSearchResult
        //                                  {
        //                                  SearchTitle = x.SearchTitle,
        //                                  SearchBrief = x.SearchBrief,
        //                                  SearchTileUrl=x.ArticleUrl
        //                                  }).ToList();
        //    }
        //    return Json(searchResult);
        //}
    }
}
