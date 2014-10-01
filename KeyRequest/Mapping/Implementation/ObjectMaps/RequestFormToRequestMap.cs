using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;


namespace KeyRequest.Mapping.Implementation
{
    public class RequestFormToRequestMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as RequestForm);
            return (TOutput)result;
        }

        private Request Map(RequestForm input)
        {
            Request result = new Request
            {
                RequestID = input.RequestFormID,
                EmployeeNo = input.EmployeeNo,
                LastName = input.LastName,
                FirstName = input.FirstName,
                RequestDate = input.RequestDate
            };

            result.KeySets = new List<RequestSet>();
            foreach (RequestSetForm rs in input.Sets.ToList())
            {
                RequestSet set = Mapper.Map<RequestSet, RequestSetForm>(rs);
                set.Request = result;
                result.KeySets.Add(set);
            }

            return result;
        }
    }
}