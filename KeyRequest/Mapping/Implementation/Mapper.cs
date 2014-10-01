using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;
using KeyRequest.ViewModels;
using KeyRequest.Mapping.Implementation;

namespace KeyRequest.Mapping
{
    //TODO: Reimplement as Singleton utilizing IMapper interface
    public static class Mapper
    {
        private static readonly Dictionary<TypeMap, string> ClassMaps = new Dictionary<TypeMap, string>{
            { new TypeMap(typeof(RequestForm), typeof(Request)), "RequestToRequestForm" },
            { new TypeMap(typeof(Request), typeof(RequestForm)), "RequestFormToRequest" },

            { new TypeMap(typeof(RequestSetForm), typeof(RequestSet)), "RequestSetToRequestSetForm" },
            { new TypeMap(typeof(RequestSet), typeof(RequestSetForm)), "RequestSetFormToRequestSet" },

            { new TypeMap(typeof(RoomForm), typeof(Room)), "RoomToRoomForm" },
            { new TypeMap(typeof(Room), typeof(RoomForm)), "RoomFormToRoom" },

            { new TypeMap(typeof(KeyForm), typeof(Key)), "KeyToKeyForm" },
            { new TypeMap(typeof(Key), typeof(KeyForm)), "KeyFormToKey" },

            { new TypeMap(typeof(RequestReport), typeof(Key)), "KeyToRequestReport" },
        };

        private static IObjectToObjectMap<TOutput, TInput> GetMap<TOutput, TInput>()
        {
            TypeMap typeMap = new TypeMap(typeof(TOutput), typeof(TInput));
            string mapperID;

            if (ClassMaps.TryGetValue(typeMap, out mapperID)){
                switch (mapperID)
                {
                    case "RequestToRequestForm":
                        return new RequestToRequestFormMap<TOutput, TInput>();
                    case "RequestFormToRequest":
                        return new RequestFormToRequestMap<TOutput, TInput>();

                    case "RequestSetToRequestSetForm":
                        return new RequestSetToRequestSetFormMap<TOutput, TInput>();
                    case "RequestSetFormToRequestSet":
                        return new RequestSetFormToRequestSetMap<TOutput, TInput>();

                    case "RoomToRoomForm" :
                        return new RoomToRoomFormMap<TOutput, TInput>();
                    case "RoomFormToRoom" :
                        return new RoomFormToRoomMap<TOutput, TInput>();
                    
                    case "KeyToKeyForm" :
                        return new KeyToKeyFormMap<TOutput, TInput>();
                    case "KeyFormToKey" :
                        return new KeyFormToKeyMap<TOutput, TInput>();

                    case "KeyToRequestReport" :
                        return new KeyToRequestReportMap<TOutput, TInput>();
                }
            }

            throw new NotImplementedException("No Object Map Exists for between specified classes");
        }

        public static TOutput Map<TOutput, TInput>(TInput input)
        {
            IObjectToObjectMap<TOutput, TInput> objectMap = GetMap<TOutput, TInput>();
            return objectMap.Map(input);
        }

        private class TypeMap
        {
            public Type Input { get; private set; }
            public Type Output { get; private set; }

            public TypeMap(Type output, Type input)
            {
                this.Input = input;
                this.Output = output;
            }

            #region Comparison Override
            public override bool Equals(System.Object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                TypeMap other = obj as TypeMap;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(TypeMap other)
            {
                if (other == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return (this.Input == other.Input) && (this.Output == other.Output);
            }

            public override int GetHashCode()
            {
                return Input.GetHashCode() ^ Output.GetHashCode();
            }
            #endregion
        }
    }
}