using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Project.Search.Models
{
    public class SearchOutputModel:SearchResultItem
    {
        [IndexField("title_t")]
        public string SearchTitle { get; set; }
        [IndexField("brief_t")]
        public string SearchBrief { get; set; }
        [IndexField("articleurl_s")]
        public string ArticleUrl { get; set; }
        [IndexField("articleimageurl_s")]
        public string ArticleImageUrl { get; set; }

    }
}