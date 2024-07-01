using Azure.Core;
using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Stellt Methoden für den Zugriff auf Frage-Daten bereit.
    /// </summary>
    public interface IQuestionRepository : IRepository<Questions, Guid>
    {
        /// <summary>
        /// Ruft eine Auflistung von Fragen anhand einer Reihe von Frage-IDs asynchron ab.
        /// </summary>
        /// <param name="questionIds">Die Reihe von Frage-IDs.</param>
        /// <returns>Eine asynchrone Aufgabe, die eine Auflistung von <see cref="Questions"/> zurückgibt.</returns>
        Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds);

        /// <summary>
        /// Ruft eine Auflistung von Fragen ab, die einem bestimmten Ordner zugeordnet sind.
        /// </summary>
        /// <param name="folderid">Die ID des Ordners.</param>
        /// <returns>Eine asynchrone Aufgabe, die eine Auflistung von <see cref="Questions"/> zurückgibt.</returns>
        Task<IEnumerable<Questions>> GetFolderQuestions(string folderid);

        /// <summary>
        /// Ruft eine Auflistung von Fragen ab, die einem bestimmten Fach zugeordnet sind.
        /// </summary>
        /// <param name="subject">Das Fach, nach dem die Fragen gefiltert werden.</param>
        /// <returns>Eine asynchrone Aufgabe, die eine Auflistung von <see cref="Questions"/> zurückgibt.</returns>
        Task<IEnumerable<Questions>> GetQuestionsBySubject(string subject);

        /// <summary>
        /// Speichert eine Frage in einem Ordner.
        /// </summary>
        /// <param name="junctionId">Die ID der Verknüpfung.</param>
        /// <param name="folderId">Die ID des Ordners, in dem die Frage gespeichert werden soll.</param>
        /// <param name="questionId">Die ID der Frage, die gespeichert werden soll.</param>
        /// <returns>Eine asynchrone Aufgabe, die die Anzahl der gespeicherten Fragen zurückgibt.</returns>
        Task<int> SaveQuestionToFolder(string junctionId, string folderId, string questionId);

        /// <summary>
        /// Verbirgt eine Frage für einen bestimmten Lehrer.
        /// </summary>
        /// <param name="id">Die ID der Frage.</param>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <param name="questionId">Die ID der Frage, die verborgen werden soll.</param>
        /// <returns>Eine asynchrone Aufgabe, die angibt, ob die Frage erfolgreich verborgen wurde.</returns>
        Task<bool> HideQuestion(string id, string teacherId, string questionId);

        /// <summary>
        /// Ruft eine Auflistung von verborgenen Fragen für einen bestimmten Lehrer ab.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Eine asynchrone Aufgabe, die eine Auflistung von <see cref="Questions"/> zurückgibt.</returns>
        Task<IEnumerable<Questions>> GetHiddenQuestionsByTeacher(string teacherId);

        /// <summary>
        /// Entfernt eine Frage aus einem Ordner.
        /// </summary>
        /// <param name="folderId">Die ID des Ordners, aus dem die Frage entfernt werden soll.</param>
        /// <param name="questionId">Die ID der Frage, die entfernt werden soll.</param>
        /// <returns>Eine asynchrone Aufgabe, die die Anzahl der entfernten Fragen zurückgibt.</returns>
        Task<int> RemoveQuestionFromFolder(string folderId, string questionId);
    }
}
