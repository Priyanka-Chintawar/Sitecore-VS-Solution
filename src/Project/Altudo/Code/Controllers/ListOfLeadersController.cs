using AltudoBatch1.Project.Altudo.Models;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Project.Altudo.Controllers
{
    public class ListOfLeadersController : Controller
    {
        // GET: ListOfLeaders
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            List<LeadershipDetails> listofLeader = new List<LeadershipDetails>();

            MultilistField leaders = contextItem.Fields["Leaders"];
            listofLeader = leaders.GetItems()
            .Select(x => new LeadershipDetails
            {
                Name = new HtmlString(FieldRenderer.Render(x, "Name")),
                Designation = new HtmlString(FieldRenderer.Render(x, "Designation")),
                ContactNumber = new HtmlString(FieldRenderer.Render(x, "ContactNumber")),
                ProfileBrief = new HtmlString(FieldRenderer.Render(x, "ProfileBrief")),
                ProfilePicture = new HtmlString(FieldRenderer.Render(x, "ProfilePicture"))
                //SuggestedArticleUrl = linkfield.Url,
                //SuggestedArticleText = linkfield.Text
            }).ToList();


            return View("/Views/Altudo/ListOfLeaders.cshtml", listofLeader);
        }
    }
}