using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class VoteService:IVote
    {
        private readonly IRepository<Vote> _voteRepo;
        public VoteService( IRepository<Vote> voteRepo)
        {
            this._voteRepo = voteRepo;
        }

        public Vote InsertVote(Vote vote)
        {
            _voteRepo.Insert(vote);
            _voteRepo.SaveChanges();
            return vote;
        }
    }
}
