using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	public class ValuesFormatterFactory
	{
		private readonly Dictionary<string, Type> _supportedTypes;

		public ValuesFormatterFactory()
		{
			_supportedTypes = GetSupportedTypes();
		}

		public object Create(MyAnimeListValues values)
		{
			Type type = GetTypeToCreate(values);
			if (type == null)
				return new NullValuesFormatter<MyAnimeListValues>();
			return Activator.CreateInstance(type);
		}

		private Type GetTypeToCreate(MyAnimeListValues values)
		{
			string typeName = values.GetType().Name.ToUpperInvariant();

			return (
				from supportedType in _supportedTypes
				where supportedType.Key.Contains(typeName)
				select _supportedTypes[supportedType.Key]).FirstOrDefault();
		}

		private Dictionary<string, Type> GetSupportedTypes()
		{
			var result = new Dictionary<string, Type>();
			var types = Assembly.GetExecutingAssembly().GetTypes();

			foreach (Type type in types)
			{
				//if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (ValuesFormatter<MyAnimeListValues>))
				if (type.GetTypeInfo().BaseType == null) continue;
				if (type.GetTypeInfo().BaseType.Name != "ValuesFormatter`1") continue;

				result.Add(type.GetTypeInfo().BaseType.GetGenericArguments()[0].Name.ToUpperInvariant(), type);
			}

			return result;
		}
	}
}