using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NTimeService
{
    [ServiceContract]
    public interface ITimeService
    {
        [OperationContract]
        string GetCurrentTime();
    }
}
