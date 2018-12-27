using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFilterClass.Data
{
    public class CandidateRepository
    {
        private string _connectionString;
        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCandidate(Candidate candidate)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.Candidates.InsertOnSubmit(candidate);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Candidate> GetAll (Status status)
        {
            using (var context = new CandidatesDataContext(_connectionString))
                return context.Candidates.Where(s => s.Status == status).ToList();
        }
        public Candidate GetCandidate(int id)
        {
            using (var context = new CandidatesDataContext(_connectionString))
                return context.Candidates.FirstOrDefault(i => i.Id == id);
        }
        public int GetCount(Status status)
        {
            using (var context = new CandidatesDataContext(_connectionString))
                return context.Candidates.Count(s => s.Status == status);
        }

        public void UpdateStatusForCandidate(Candidate updatecandidate)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.Candidates.Attach(updatecandidate);
                context.Refresh(RefreshMode.KeepCurrentValues, updatecandidate);
                context.SubmitChanges();
            }
        }
      
     

    }
}
