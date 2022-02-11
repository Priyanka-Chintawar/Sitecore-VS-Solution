﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Project.Altudo.Models
{
    public class LeadershipDetails
    {
        public HtmlString Name { get; set; }
        public HtmlString Designation { get; set; }
        public HtmlString ContactNumber { get; set; }
        public HtmlString ProfileBrief { get; set; }
        public HtmlString ProfilePicture { get; set; }

        public string SuggestedArticleUrl { get; set; }
        public String SuggestedArticleText { get; set; }
    }
}