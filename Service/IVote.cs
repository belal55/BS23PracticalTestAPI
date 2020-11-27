using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IVote
    {
        Vote InsertVote(Vote vote);
    }
}
