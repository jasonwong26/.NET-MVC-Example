using System.Collections.Generic;
using System.Linq;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Mapping.Implementation
{
    public class RoomToRoomFormMap<TOutput, TInput> : IObjectToObjectMap<TOutput, TInput>
    {
        public TOutput Map(TInput input)
        {
            object result = Map(input as Room);
            return (TOutput)result;
        }

        private RoomForm Map(Room input)
        {
            RoomForm result = new RoomForm()
            {
                RoomFormID = input.RoomID,
                Description = input.Description,
                Location = input.Location,
                Available = input.Available
            };

            result.Keys = new List<KeyForm>();
            foreach (Key k in input.Keys.ToList())
            {
                result.Keys.Add(Mapper.Map<KeyForm, Key>(k));
            }

            return result;
        }
    }
}