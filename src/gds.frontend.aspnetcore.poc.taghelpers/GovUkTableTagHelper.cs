using gds.frontend.aspnetcore.poc.taghelpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace gds.frontend.aspnetcore.poc.taghelpers
{
    public class GovUkTableTagHelper : TagHelper
    {
        public Table Table { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.SetAttribute("class", string.Concat("govuk-table", string.IsNullOrWhiteSpace(Table.Classes) ? string.Empty: string.Concat(" ", Table.Classes)));
            BuildHtml(output.Content);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private void BuildHtml(TagHelperContent outputContent)
        {            
            BuildCaption(outputContent);
            BuildThead(outputContent);
            BuildRow(outputContent);
        }
        
        private void BuildCaption(TagHelperContent outputContent)
        {
            if (string.IsNullOrEmpty(Table.Caption))
                return;

            var caption = new TagBuilder("caption");
            caption.AddCssClass("govuk-table__caption");
            caption.AddCssClass(Table.CaptionClasses);
            caption.InnerHtml.Append(Table.Caption);

            outputContent.AppendHtml(caption);
        }

        private void BuildThead(TagHelperContent outputContent)
        {
            if (Table.HeadRows== null || !Table.HeadRows.Any())
                return;

            var thead = new TagBuilder("thead");
            thead.AddCssClass("govuk-table__head");
           
            foreach (var row in Table.HeadRows)
            {
                var tr = new TagBuilder("tr");
                tr.AddCssClass("govuk-table__row");

                foreach (var cell in row.Cells)
                {
                    var th = new TagBuilder("th");
                    th.AddCssClass("govuk-table__header");
                    th.AddCssClass(cell.Classes);
                    if (cell.Format == Format.Numeric)
                        th.AddCssClass("govuk-table__header--numeric");

                    th.Attributes.Add("scope", "col");
                    AppendHtmlOrText(cell, th);
                    th.MergeAttributes(new RouteValueDictionary(cell.Attributes));
                    AddColspan(cell, th);
                    AddRowspan(cell, th);
                    tr.InnerHtml.AppendHtml(th);
                }

                thead.InnerHtml.AppendHtml(tr);
            }
            
            outputContent.AppendHtml(thead);
        }

        private static void AppendHtmlOrText(Cell cell, TagBuilder th)
        {
            if (string.IsNullOrWhiteSpace(cell.Html))
            {
                th.InnerHtml.Append(cell.Text);
            }
            else
            {
                th.InnerHtml.AppendHtml(cell.Html);
            }
        }

        private void BuildRow(TagHelperContent outputContent)
        {
            if (Table.BodyRows == null || !Table.BodyRows.Any())
                return;

            var tbody = new TagBuilder("tbody");
            tbody.AddCssClass("govuk-table__body");
           
            foreach (var row in Table.BodyRows)
            {
                var tr = new TagBuilder("tr");
                tr.AddCssClass("govuk-table__row");
                                
                for (var i = 0; i < row.Cells.Count; i++)
                {
                    var cell = row.Cells[i];

                    TagBuilder td;                                        
                    if (i == 0 && Table.FirstCellIsHeader)
                    {
                        td = new TagBuilder("th");
                        td.MergeAttribute("scope", "row");
                    }
                    else
                    {
                        td = new TagBuilder("td");
                    }

                    td.AddCssClass("govuk-table__cell");
                    td.AddCssClass(cell.Classes);

                    if(cell.Format == Format.Numeric)
                        td.AddCssClass("govuk-table__cell--numeric");

                    AddColspan(cell, td);

                    AddRowspan(cell, td);

                    AppendHtmlOrText(cell, td);
                    td.MergeAttributes(new RouteValueDictionary(cell.Attributes));
                    tr.InnerHtml.AppendHtml(td);                
                }

                tbody.InnerHtml.AppendHtml(tr);                
            }

            outputContent.AppendHtml(tbody);
        }

        private static void AddRowspan(Cell cell, TagBuilder td)
        {
            if (cell.Rowspan != 1)
                td.Attributes.Add("rowspan", cell.Rowspan.ToString());
        }

        private static void AddColspan(Cell cell, TagBuilder td)
        {
            if (cell.Colspan > 1)
                td.Attributes.Add("colspan", cell.Colspan.ToString());
        }
    }
}