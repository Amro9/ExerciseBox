using exerciseBox.Application.Services.Interface;
using exerciseBox.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace exerciseBox.Application.Services
{
    public class ExerciseSheetGenerator : IExerciseSheetGenerator
    {
        public byte[] Generate(ExerciseSheet exerciseSheet, IEnumerable<Questions> questions)
        {
            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);

                    // Header Section
                    page.Header().Column(column =>
                    {
                        if (exerciseSheet.StudentName)
                        {
                            column.Item().Text($"Name:", TextStyle.Default.Size(12));
                        }
                    });

                    // Content Section
                    page.Content().Padding(5).PaddingVertical(40).Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Text(exerciseSheet.Title)
                            .Style(TextStyle.Default.Size(24).Bold())
                            .AlignCenter();
                        column.Item().PaddingBottom(20);

                        foreach (var question in questions)
                        {
                            var questionIndex = questions.ToList().IndexOf(question) + 1;
                            column.Item().Text($"{questionIndex}) {question.QuestionText}", TextStyle.Default.Size(12));
                            column.Item().PaddingBottom(20);
                        }
                    });

                    // Footer Section
                    page.Footer().AlignLeft().Text(text =>
                    {
                        text.Span("Page ");
                        text.CurrentPageNumber();
                        text.Span(" of ");
                        text.TotalPages();
                    });
                });
            });

            byte[] pdfBytes;
            using (var stream = new MemoryStream())
            {
                pdfDocument.GeneratePdf(stream);
                pdfBytes = stream.ToArray();
            }

            return pdfBytes;
        }
    }
}
