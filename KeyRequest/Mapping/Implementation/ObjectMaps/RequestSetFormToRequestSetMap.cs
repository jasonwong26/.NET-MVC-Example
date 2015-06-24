using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class RequestSetFormToRequestSetMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as RequestSetForm);
            return (TOutput)result;
        }

        private RequestSet Map(RequestSetForm input)
        {
            RequestSet result = new RequestSet()
            {
                RequestID = input.RequestFormID,
                RoomID = input.RoomID.GetValueOrDefault(0),
                Sets = input.Sets.HasValue ? (int)input.Sets : 0,
            };

            return result;
        }
    }
}