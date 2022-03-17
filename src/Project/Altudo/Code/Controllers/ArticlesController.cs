using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Data.Fields;
using Sitecore.Links;

namespace AltudoBatch1.Project.Altudo.Controllers
{
    public class ArticlesController : ApiController
    {
        [Route("altudoapi/GetArticles")]
        public IHttpActionResult GetArticles()
        {
            var contextItem = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(new Sitecore.Data.ID("{BEA747BA-DE65-4406-8243-D4F8B4B9ABAD}")); 
            var listofArticles = contextItem.GetChildren()
                                            .Select(x => new JsonArticle
                                            {
                                                Name = x.Name,
                                                Title = x.Fields["Title"].Value,
                                                Brief = x.Fields["Brief"].Value,
                                                DetailedArticle = x.Fields["DetailedArticle"].Value,
                                                ImageUrl = getImageUrl(x, "ArticleImage"),
                                            })
                                            .ToList();
            return Json(listofArticles);
        }

        private string getImageUrl(Item item, string ArticleImage)
        {
            ImageField image = item.Fields["ArticleImage"];
            return MediaManager.GetMediaUrl(image.MediaItem);
        }
        [Route("altudoapi/GetFullBleedImageFromHealthArticle")]
        public IHttpActionResult GetheroImageFromHealthArticle()
        {
            var parentItem = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(new Sitecore.Data.ID("{BEA747BA-DE65-4406-8243-D4F8B4B9ABAD}"));
            var listOfCarouselImages = parentItem.GetChildren()
                                        .Select(x => new CarouselImages
                                        {
                                            CarouselTitle = x.Fields["Title"].Value,
                                            CarouselImageUrl = getImageUrl(x, "heroImage"),
                                            CarouselUrl = LinkManager.GetItemUrl(x)
                                        }).ToList();

            return Json(listOfCarouselImages);
        }
    }
    public class JsonArticle
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string DetailedArticle { get; set; }
        public string ImageUrl { get; set; }
    }
    public class CarouselImages
    {
        public string CarouselImageUrl { get; set; }
        public string CarouselTitle { get; set; }
        public string CarouselUrl { get; set; }
    }
}




