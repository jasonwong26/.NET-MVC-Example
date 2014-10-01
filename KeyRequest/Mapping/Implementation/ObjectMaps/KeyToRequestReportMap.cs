using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class KeyToRequestReportMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as Key);
            return (TOutput)result;
        }

        private RequestReport Map(Key input)
        {
            RequestReport result = new RequestReport
            {
                Description = input.Room.Description,
                Location = input.Room.Location,
                Tag = input.Tag,
                Sets = input.Room.RequestSets.Sum(x => x.Sets)
            };

            return result;
        }
    }
}