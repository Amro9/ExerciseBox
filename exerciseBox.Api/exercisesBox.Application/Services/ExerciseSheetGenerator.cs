using exerciseBox.Application.Services.Interface;
using exerciseBox.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace exerciseBox.Application.Services
{
    public class ExerciseSheetGenerator : IExerciseSheetGenerator
    {
        public byte[] Generate(ExerciseSheets exerciseSheet, IEnumerable<Questions> questions)
        {
            if (questions.Count() <= 0)
                throw new Exception("No questions found");

            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);

                    // Header Section
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            if (exerciseSheet.NamePlaceHolder)
                            {
                                column.Item().AlignLeft().Row(innerRow =>
                                {
                                    innerRow.AutoItem().Text("Name:", TextStyle.Default.Size(15));
                                    innerRow.ConstantItem(100).PaddingTop(16).LineHorizontal(1);
                                });
                            }
                        });

                        if(exerciseSheet.DatePlaceHolder)
                            row.RelativeItem().AlignRight().Text(DateTime.Now.ToString("dd:MM:yyyy"), TextStyle.Default.Size(15));
                    });

                    // Content Section
                    page.Content().Padding(5).PaddingVertical(40).Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Text(exerciseSheet.Tilte)
                            .Style(TextStyle.Default.Size(30).Bold())
                            .AlignCenter();
                        column.Item().PaddingBottom(20);

                        foreach (var question in questions)
                        {
                            var questionIndex = questions.ToList().IndexOf(question) + 1;
                            column.Item().Text($"{questionIndex}) {question.QuestionText}", TextStyle.Default.Size(12));
                            column.Item().PaddingBottom(80);
                        }
                    });

                    // Footer Section
                    page.Footer().Row(row =>
                    {
                        row.RelativeItem().AlignRight().Text(text =>
                        {
                            text.CurrentPageNumber();
                            text.Span(" of ");
                            text.TotalPages();
                            text.DefaultTextStyle(TextStyle.Default.Size(15));
                        });

                        if(exerciseSheet.MarkPlaceHolder)
                            row.RelativeItem().AlignRight().Row(innerRow =>
                            {
                                innerRow.AutoItem().Text("Note:", TextStyle.Default.Size(15));
                                innerRow.ConstantItem(40).PaddingTop(16).LineHorizontal(1);
                            });
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