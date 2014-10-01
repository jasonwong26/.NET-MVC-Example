using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class RequestSetToRequestSetFormMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as RequestSet);
            return (TOutput)result;
        }

        private RequestSetForm Map(RequestSet input)
        {
            RequestSetForm result = new RequestSetForm()
            {
                RequestFormID = input.RequestID,
                RoomID = input.RoomID,
                RoomDescription = input.Room.Description,
                Sets = input.Sets
            };

            return result;
        }
    }
}