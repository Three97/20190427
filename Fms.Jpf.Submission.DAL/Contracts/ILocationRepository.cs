using System.Collections.Generic;
using Fms.Jpf.Submission.DAL.Models;

namespace Fms.Jpf.Submission.DAL.Contracts
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();
    }
}