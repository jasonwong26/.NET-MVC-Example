using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class RoomFormToRoomMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
	{
        public TOutput Map(TInput input)
        {
            object result = Map(input as RoomForm);
            return (TOutput)result;
        }

        private Room Map(RoomForm input)
        {
            Room result = new Room
            {
                RoomID = input.RoomFormID,
                Description = input.Description,
                Location = input.Location,
                Available = input.Available
            };

            result.Keys = new List<Key>();
            foreach (KeyForm k in input.Keys.ToList())
            {
                Key key = Mapper.Map<Key, KeyForm>(k);
                key.Room = result;
                result.Keys.Add(key);
            }

            return result;
        }

	}
}