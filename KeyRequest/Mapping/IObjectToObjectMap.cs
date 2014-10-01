using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyRequest.Mapping
{
    interface IObjectToObjectMap<TOutput, TInput>
    {
        TOutput Map(TInput input);
    }
}
