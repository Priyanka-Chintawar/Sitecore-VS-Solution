using AltudoBatch1.Project.Search.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Project.Search.Controllers
{
    public class SearchWithPredicateController : ApiController
    {
        [Route("altudoapi/GetSearchResultForPredicate")]
        public IHttpActionResult GetSearchResultForPredicate(SearchParam param)
        {
            List<StandardSearchResult> searchResults = new List<StandardSearchResult>();
            var contextDB = Sitecore.Context.Database;
            ISearchIndex searchIndex=ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");
            var searchPredicate = GetSearchPredicate(param.searchKeyword);
            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                searchResults = searchContext.GetQueryable<SearchOutputModel>()
                                            .Where(searchPredicate)
                                            .Select(x => new StandardSearchResult
                                            {
                                                SearchTitle = x.SearchTitle
                                            }).ToList();
            }
            return Json(searchResults);
        }

        public static Expression<Func<SearchOutputModel,bool>> GetSearchPredicate(string SearchTerm)
        {
            var predicate = PredicateBuilder.True<SearchOutputModel>();
            predicate = predicate.Or(x => x.TemplateName == "HealthArticle");
            //predicate = predicate.And(x => x.SearchTitle.Contains(SearchTerm));
            //predicate = predicate.And(x => x.SearchBrief.Contains(SearchTerm));
            return predicate;
        }
    }

}
