

using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        public Task<Questions> Create(Questions entity)
        {
            throw new NotImplementedException();
        }

        public Task<Questions> Delete(Questions entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Questions>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<Questions> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Questions> Update(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
