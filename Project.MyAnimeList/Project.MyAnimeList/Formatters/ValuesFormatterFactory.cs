using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Formatters;

namespace Project.MyAnimeList.Test.Tests
{
	public class ValuesFormatterFactory
	{
		private readonly Dictionary<string, Type> _supportedTypes;

		public ValuesFormatterFactory()
		{
			_supportedTypes = GetSupportedTypes();
		}

		public ValuesFormatter<T> Create<T>(T values) where T : MyAnimeListValues
		{
			Type type = GetTypeToCreate(values);
			if (type == null)
				return new NullValuesFormatter<T>();
			return Activator.CreateInstance(type) as ValuesFormatter<T>;
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
			Dictionary<string, Type> result = new Dictionary<string, Type>();

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