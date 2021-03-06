﻿using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Util
{
    public class SearchResponseDeserializer<T> where T : class
    {
        public T Deserialize(string responseString)
        {
            using (var stringReader = new StringReader(responseString))
            using (
                var xmlReader = XmlReader.Create(stringReader,
                    new XmlReaderSettings {DtdProcessing = DtdProcessing.Ignore}))
            {
                DisableUndeclaredEntityCheck(xmlReader);

                var xmlSerializer = new XmlSerializer(typeof(T));
                var result = xmlSerializer.Deserialize(xmlReader) as T;
                return result;
            }
        }

        /// <summary>
        /// Using reflection, disable undeclared XML entity check for the specified XML reader.
        /// </summary>
        /// <remarks>
        /// Code available on <see cref="http://stackoverflow.com/a/22787825/4035"/>
        /// The main reason that forced me to use this was because of "&mdash;" entity in returned response string.
        /// There were other entities that cannot be just hardcoded 
        /// so I decided to just ignore them all during deserialzation process.
        /// </remarks>
        private static void DisableUndeclaredEntityCheck(XmlReader xmlReader)
        {
            PropertyInfo propertyInfo = xmlReader.GetType().GetProperty(
                "DisableUndeclaredEntityCheck", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            propertyInfo.SetValue(xmlReader, true);
        }
    }
}