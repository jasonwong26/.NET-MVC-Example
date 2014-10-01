using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyRequest.Mapping
{
    public interface IMapper
    {
        TOutput Map<TOutput, TInput>(TInput input);
    }
}
