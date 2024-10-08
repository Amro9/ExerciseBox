﻿using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das Subject Repository.
    /// Erbt von IRepository mit Subjects als Entitätstyp und Guid als Schlüsseltyp.
    /// </summary>
    public interface ISubjectRepository : IRepository<Subjects, Guid>
    {
        /// <summary>
        /// Holt alle Fächer eines Lehrers.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Subjects>> GetSubjectsByTeacherId(string id);

        /// <summary>
        /// Holt alle Fächer einer Schule.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Subjects>> GetSubjectsBySchoolId(string id);

        /// <summary>
        /// Holt alle Fächer eines Schultyps.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Subjects> ReadByTopic(string id);

        /// <summary>
        /// Holt alle Fächer eines Schulzweigs.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Subjects>> GetSubjectsBySchoolBranchId(string id);
    }
}
