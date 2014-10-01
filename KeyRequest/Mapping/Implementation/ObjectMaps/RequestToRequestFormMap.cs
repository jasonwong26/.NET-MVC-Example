using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class RequestToRequestFormMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as Request);
            return (TOutput)result;
        }

        private RequestForm Map(Request input)
        {
            RequestForm result = new RequestForm
            {
                RequestFormID = input.RequestID,
                EmployeeNo = input.EmployeeNo,
                LastName = input.LastName,
                FirstName = input.FirstName,
                RequestDate = input.RequestDate,
            };

            result.Sets = new List<RequestSetForm>();
            foreach (RequestSet rs in input.KeySets.ToList())
            { 
                result.Sets.Add(Mapper.Map<RequestSetForm, RequestSet>(rs));
            }

            return result;
        }
    }
}