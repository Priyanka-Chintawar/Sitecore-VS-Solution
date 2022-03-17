using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altudo.Foundation.Search
{
    public static class Templates
    {
        public struct Article
        {
            public static readonly ID ArticleTemplate = new ID("{C3794982-7F91-487E-AA21-6C0081454638}");
            public struct Fields
            {
                public static readonly ID SpecialityName = new ID("{D42F9AD5-C66D-4C17-A424-DBBFD7B57557}");
            }
        }
        public struct SpecialityMaster
        {
            public static readonly ID SpecialityMasterTemplate = new ID("{4CD84C7A-5B9D-4AC3-8659-C8C0C471567E}");

            public struct Fields
        {
            public static readonly ID SpecialityNameFromMaster = new ID("{54474069-F0EF-4E06-A8F3-178294997249}");
        }
    }

}
}