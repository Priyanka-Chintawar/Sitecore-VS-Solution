using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altudo.Foundation.Search.ComputedIndexes
{
    public class Speciality : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item ArticleItem = indexable as SitecoreIndexableItem;

            if (ArticleItem is null)
                return null;


            if (ArticleItem.TemplateID != Templates.Article.ArticleTemplate)
                return null;

            GroupedDroplinkField droplinkField = ArticleItem.Fields[Templates.Article.Fields.SpecialityName];

            return droplinkField.TargetItem.Fields[Templates.SpecialityMaster.Fields.SpecialityNameFromMaster].Value;
        }
    }
}