using AltudoBtc1.Feature.DetailPage.Models;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBtc1.Feature.ListingPage.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var listing = contextItem.GetChildren()
                .Select(x => new Details
                {
                    Title = new HtmlString(FieldRenderer.Render(x, "Title")),
                Description = new HtmlString(FieldRenderer.Render(x, "Description")),
                CardImage = new HtmlString(FieldRenderer.Render(x, "CardImage")),
                RedirectUrl = LinkManager.GetItemUrl(x)
            }).ToList();
            return View("/Views/Altudo/ListingPage/Listing.cshtml", listing);
        }
    }
}