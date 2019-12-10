namespace Fms.Jpf.Submission.DAL.Contracts
{
    using System.Collections.Generic;

    using Fms.Jpf.Submission.DAL.Models;

    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();
    }
}