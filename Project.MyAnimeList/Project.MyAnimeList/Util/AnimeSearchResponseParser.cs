﻿using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace MyAnimeListSharp.Util
{
	public class AnimeSearchResponseParser
	{
		public bool IsParsable(string testString)
		{
			if (string.IsNullOrWhiteSpace(testString)) return false;

			using (StringReader reader = new StringReader(testString))
			{
				XDocument document;
				try
				{
					document = XDocument.Load(reader);
				}
				catch (Exception ex)
				{
					return false;
				}

				bool error = false;
				var xmlSchemaSet = GetXmlSchemaSet();
				document.Validate(xmlSchemaSet,
					// Closure: Access "error" variable from outer scope to set the return value.
					// This event handler is called only when a validation error occurs.
					(sender, args) => error = true);

				return !error;
			}
		}

		private XmlSchemaSet GetXmlSchemaSet()
		{
			var result = new XmlSchemaSet();
			const string targetNamespace = "";
			string schemaUri = @"./Xml/AnimeSearchResponse.xsd";

			result.Add(targetNamespace, schemaUri);
			return result;
		}
	}
}