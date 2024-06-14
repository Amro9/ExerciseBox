using exerciseBox.Application.Services.Interface;
using exerciseBox.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace exerciseBox.Application.Services;

public class ExerciseSheetGenerator : IExerciseSheetGenerator
{
    public byte[] Generate(ExerciseSheet exerciseSheet, IEnumerable<Questions> questions)
    {

        //TODO: https://github.com/Relorer/HTMLToQPDF 

        var pdfDocument = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);

                page.Header().Column(column =>
                {
                    if (exerciseSheet.StudentName)
                    {
                        column.Item().Text("Name:", TextStyle.Default.Size(20));
                    }
                    column.Item().ShowOnce().Background(Colors.Blue.Lighten2).Height(60);
                    column.Item().SkipOnce().Background(Colors.Green.Lighten2).Height(40);
                });

                page.Content().Column(column =>
                {
                    column.Item().Text("Title", TextStyle.Default.Size(24));

                    foreach (var question in questions)
                    {
                        column.Item().Text(question.QuestionText, TextStyle.Default.Size(16));
                    }
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
