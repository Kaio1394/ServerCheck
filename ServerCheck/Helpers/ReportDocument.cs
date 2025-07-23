using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ServerCheck.Helpers
{
    class ReportDocument : IDocument
    {
        private string _text;
        private string _header;
        public ReportDocument(string text, string header)
        {
            _text = text;
            _header = header;
        }
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(14));

                page.Content()
                    .Column(column =>
                    {
                        column.Item().PaddingBottom(20).Text(_header).Bold().FontSize(20);
                        column.Item().Text(_text);
                    });

                page.Footer()
                  .AlignCenter()
                  .Text(text =>
                  {
                      text.Span("Page ");
                      text.CurrentPageNumber();
                      text.Span(" of ");
                      text.TotalPages();
                  });
            });
        }
    }
}
