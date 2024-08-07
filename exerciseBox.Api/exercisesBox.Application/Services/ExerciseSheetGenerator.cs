using exerciseBox.Application.Services.Interface;
using exerciseBox.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;

namespace exerciseBox.Application.Services
{
    /// <summary>
    /// Implementiert die Logik zur Erzeugung von Übungsblättern als PDF-Dokument.
    /// </summary>
    public class ExerciseSheetGenerator : IExerciseSheetGenerator
    {
        /// <summary>
        /// Generiert ein PDF-Dokument für ein Übungsblatt.
        /// </summary>
        /// <param name="exerciseSheet">Das Übungsblatt, das generiert werden soll.</param>
        /// <param name="questions">Die Fragen, die auf dem Übungsblatt angezeigt werden sollen.</param>
        /// <param name="WithAnswers">Gibt an, ob die Antworten ebenfalls auf dem Übungsblatt angezeigt werden sollen.</param>
        /// <returns>Ein Byte-Array, das das generierte PDF-Dokument darstellt.</returns>
        public byte[] Generate(ExerciseSheets exerciseSheet, IEnumerable<Questions> questions, bool WithAnswers)
        {
            if (questions.Count() <= 0)
                throw new Exception("Keine Fragen gefunden");

            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);

                    // Header Bereich
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

                        if (exerciseSheet.DatePlaceHolder)
                            row.RelativeItem().AlignRight().Text(DateTime.Now.ToString("dd.MM.yyyy"), TextStyle.Default.Size(15));
                    });

                    // Inhaltsbereich
                    page.Content().Padding(5).PaddingVertical(40).Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Text(exerciseSheet.Titel)
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

                    // Fußzeilenbereich
                    page.Footer().Row(row =>
                    {
                        row.RelativeItem().AlignRight().Text(text =>
                        {
                            text.CurrentPageNumber();
                            text.Span(" von ");
                            text.TotalPages();
                            text.DefaultTextStyle(TextStyle.Default.Size(15));
                        });

                        if (exerciseSheet.MarkPlaceHolder)
                            row.RelativeItem().AlignRight().Row(innerRow =>
                            {
                                innerRow.AutoItem().Text("Note:", TextStyle.Default.Size(15));
                                innerRow.ConstantItem(40).PaddingTop(16).LineHorizontal(1);
                            });
                    });
                });

                // Zweite Seite für Antworten, falls WithAnswers true ist
                if (WithAnswers)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(20);
                        page.PageColor(Colors.White);

                        // Header Bereich
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

                            if (exerciseSheet.DatePlaceHolder)
                                row.RelativeItem().AlignRight().Text(DateTime.Now.ToString("dd.MM.yyyy"), TextStyle.Default.Size(15));
                        });

                        // Inhaltsbereich
                        page.Content().Padding(5).PaddingVertical(40).Column(column =>
                        {
                            column.Spacing(10);

                            column.Item().Text($"{exerciseSheet.Titel} Antworten")
                                .Style(TextStyle.Default.Size(30).Bold())
                                .AlignCenter();
                            column.Item().PaddingBottom(20);

                            foreach (var question in questions)
                            {
                                var questionIndex = questions.ToList().IndexOf(question) + 1;
                                column.Item().Text($"{questionIndex}) {question.QuestionText}", TextStyle.Default.Size(12));
                                column.Item().PaddingBottom(20);
                                column.Item().Text($"{question.Answer}", TextStyle.Default.Size(12));
                                column.Item().PaddingBottom(50);

                            }
                        });

                        // Fußzeilenbereich
                        page.Footer().Row(row =>
                        {
                            row.RelativeItem().AlignRight().Text(text =>
                            {
                                text.CurrentPageNumber();
                                text.Span(" von ");
                                text.TotalPages();
                                text.DefaultTextStyle(TextStyle.Default.Size(15));
                            });

                            if (exerciseSheet.MarkPlaceHolder)
                                row.RelativeItem().AlignRight().Row(innerRow =>
                                {
                                    innerRow.AutoItem().Text("Note:", TextStyle.Default.Size(15));
                                    innerRow.ConstantItem(40).PaddingTop(16).LineHorizontal(1);
                                });
                        });
                    });
                }
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
