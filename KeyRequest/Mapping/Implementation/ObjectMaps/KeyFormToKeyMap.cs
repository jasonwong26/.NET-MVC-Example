using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class KeyFormToKeyMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as KeyForm);
            return (TOutput)result;
        }

        private Key Map(KeyForm input)
        {
            Key result = new Key()
            {
                KeyID = input.KeyFormID,
                RoomID = input.RoomFormID.GetValueOrDefault(0),
                Tag = input.Tag
            };

            return result;
        }
    }
}