using AltudoBatch1.Project.Altudo.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Project.Altudo.Controllers
{
    public class LeadershipDetailsController : Controller
    {
        // GET: LeadershipDetails
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            LinkField linkfield = contextItem.Fields["SuggestedArticle"];

            var targetItem = linkfield.TargetItem;

            LeadershipDetails leadership = new LeadershipDetails
            {
                Name = new HtmlString(FieldRenderer.Render(contextItem,"Name")),
                Designation = new HtmlString(contextItem.Fields["Designation"].Value),
                ContactNumber = new HtmlString(FieldRenderer.Render(contextItem, "ContactNumber")),
                ProfileBrief = new HtmlString(FieldRenderer.Render(contextItem, "ProfileBrief")),
                ProfilePicture = new HtmlString(FieldRenderer.Render(contextItem, "ProfilePicture")),
                SuggestedArticleUrl = linkfield.Url,
                SuggestedArticleText = linkfield.Text

                //LinkManager.GetItemUrl(targetItem),targetItem.Fields["Title"].Value


            };

            return View("/Views/Altudo/LeadershipDetails.cshtml", leadership);
        }
    }
}