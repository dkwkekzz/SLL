using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SLL.Extensions
{
	public static class ObjectExtensions
    {
        public static object DeepClone(this object org)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);

                formatter.Serialize(stream, org);

                stream.Position = 0;

                return formatter.Deserialize(stream);
            }
        }

		public static T ToObject<T>(this IDictionary<string, object> source)
			where T : class, new()
		{
			T someObject = new T();
			Type someObjectType = someObject.GetType();

			foreach (KeyValuePair<string, object> item in source)
			{
				someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
			}

			return someObject;
		}

		public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance)
		{
			return source.GetType().GetProperties(bindingAttr).ToDictionary
			(
				propInfo => propInfo.Name,
				propInfo => propInfo.GetValue(source, null)
			);

		}
	}
}
