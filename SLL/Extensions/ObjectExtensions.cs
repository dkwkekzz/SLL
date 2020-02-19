using System;
using System.Collections.Generic;
using System.IO;
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

    }
}
