using System.Collections;
using System.Collections.Generic;
using Fms.Jpf.Submission.DAL.Models;

namespace Fms.Jpf.Submission.Service.Contracts
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
    }
}