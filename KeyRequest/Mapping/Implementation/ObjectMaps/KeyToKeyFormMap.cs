using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class KeyToKeyFormMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as Key);
            return (TOutput)result;
        }

        private KeyForm Map(Key input)
        {
            KeyForm result = new KeyForm()
            {
                KeyFormID = input.KeyID,
                RoomFormID = input.RoomID,
                Tag = input.Tag
            };

            return result;
        }
    }
}