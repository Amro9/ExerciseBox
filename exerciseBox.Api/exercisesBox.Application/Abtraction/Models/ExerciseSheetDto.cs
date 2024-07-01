using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Repräsentiert ein Datenübertragungsobjekt für ein Übungsblatt.
    /// </summary>
    public class ExerciseSheetDto
    {
        /// <summary>
        /// Die eindeutige Kennung des Übungsblattes.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Der Titel des Übungsblattes.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gibt an, ob ein Platzhalter für den Namen vorhanden ist.
        /// </summary>
        public bool NamePlaceHolder { get; set; }

        /// <summary>
        /// Gibt an, ob ein Platzhalter für die Note vorhanden ist.
        /// </summary>
        public bool MarkPlaceHolder { get; set; }

        /// <summary>
        /// Gibt an, ob ein Platzhalter für das Datum vorhanden ist.
        /// </summary>
        public bool DatePlaceHolder { get; set; }

        /// <summary>
        /// Gibt an, ob ein Platzhalter für die Klassennummer vorhanden ist.
        /// </summary>
        public bool ClassNumberPlaceHolder { get; set; }

        /// <summary>
        /// Der Text für die Klassennummer.
        /// </summary>
        public string ClassNumberText { get; set; }

        /// <summary>
        /// Gibt an, ob ein Platzhalter für das Fach vorhanden ist.
        /// </summary>
        public bool SubjectPlaceHolder { get; set; }

        /// <summary>
        /// Implizite Konvertierung von <see cref="ExerciseSheets"/> zu <see cref="ExerciseSheetDto"/>.
        /// </summary>
        /// <param name="v">Das <see cref="ExerciseSheets"/>-Objekt, das konvertiert werden soll.</param>
        public static implicit operator ExerciseSheetDto(ExerciseSheets v)
        {
            return new ExerciseSheetDto
            {
                Id = v.Id,
                Title = v.Titel,
                NamePlaceHolder = v.NamePlaceHolder,
                MarkPlaceHolder = v.MarkPlaceHolder,
                DatePlaceHolder = v.DatePlaceHolder,
                ClassNumberPlaceHolder = v.ClassNumberPlaceHolder,
                ClassNumberText = v.ClassNumberText,
                SubjectPlaceHolder = v.SubjectPlaceHolder,
            };
        }

        /// <summary>
        /// Implizite Konvertierung von <see cref="ExerciseSheetDto"/> zu <see cref="ExerciseSheets"/>.
        /// </summary>
        /// <param name="v">Das <see cref="ExerciseSheetDto"/>-Objekt, das konvertiert werden soll.</param>
        public static implicit operator ExerciseSheets(ExerciseSheetDto v)
        {
            return new ExerciseSheets
            {
                Id = v.Id,
                Titel = v.Title,
                NamePlaceHolder = v.NamePlaceHolder,
                MarkPlaceHolder = v.MarkPlaceHolder,
                DatePlaceHolder = v.DatePlaceHolder,
                ClassNumberPlaceHolder = v.ClassNumberPlaceHolder,
                ClassNumberText = v.ClassNumberText,
                SubjectPlaceHolder = v.SubjectPlaceHolder,
            };
        }
    }
}
