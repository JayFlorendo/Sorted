using Sorted.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Interface
{
    public interface IRainfallService
    {
        Task<RainfallReadingResponse> GetRainfallReading (int StationID);
    }
}
