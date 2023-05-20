using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Wanna.DebugEx
{
    public class ParsableTree
    {
        Type[] m_usedTypes;
        IEnumerable<IParsable> m_parsables;

        public ParsableTree(IEnumerable<IParsable> parsables, params Type[] types)
        {
            m_parsables = parsables;
            m_usedTypes = types;
        }

        public object ToObject()
        {
            StringBuilder builder = new StringBuilder();
            int elemLength = 0;

            foreach (IParsable parsable in m_parsables)
            {
                string str = JsonHandler.InsertTab(parsable.Parse(), 1);
                builder.Append(str);
                builder.Append(",\n");
                elemLength++;
            }

            if (builder.Length != 0)
            {
                builder.Remove(builder.Length - 2, 2);
            }

            JsonHandler.Surround(builder, '[', ']');

            builder.Insert(0, $"Array<{string.Join(", ", m_usedTypes.Select(t => t.Name))}>: ");
            builder.Append($" Length = {elemLength}\n");

            return builder.ToString();
        }
    }
}