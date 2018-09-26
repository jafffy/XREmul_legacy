using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization;
using System.IO;

using System.Linq;
using System;
public class SerializableToCSV {

	//https://medium.com/@utterbbq/c-serializing-list-of-objects-to-csv-9dce02519f6b
	public static string Serialize<T>(List<T> items) where T : class
	{
		var output = "";
		var delimiter = ';';
		var properties = typeof(T).GetProperties()
		.Where(n =>
		n.PropertyType == typeof(string)
		|| n.PropertyType == typeof(bool)
		|| n.PropertyType == typeof(char)
		|| n.PropertyType == typeof(byte)
		|| n.PropertyType == typeof(decimal)
		|| n.PropertyType == typeof(int)
		|| n.PropertyType == typeof(DateTime)
		|| n.PropertyType == typeof(DateTime?));
		using (var sw = new StringWriter())
		{
			var header = properties
			.Select(n => n.Name)
			.Aggregate((a, b) => a + delimiter + b);
			sw.WriteLine(header);
			foreach (var item in items)
			{
				var row = properties
				.Select(n => n.GetValue(item, null))
				.Select(n => n == null ? "null" : n.ToString())
				.Aggregate((a, b) => a + delimiter + b);
				sw.WriteLine(row);
			}
			output = sw.ToString();
		}
		return output;
	}

	public static string Serialize<T>(T item) where T : class
	{
		var output = "";
		var delimiter = ';';
		var properties = typeof(T).GetProperties()
		.Where(n =>
		n.PropertyType == typeof(string)
		|| n.PropertyType == typeof(bool)
		|| n.PropertyType == typeof(char)
		|| n.PropertyType == typeof(byte)
		|| n.PropertyType == typeof(decimal)
		|| n.PropertyType == typeof(int)
		|| n.PropertyType == typeof(DateTime)
		|| n.PropertyType == typeof(DateTime?));
		using (var sw = new StringWriter())
		{
			var header = properties
			.Select(n => n.Name)
			.Aggregate((a, b) => a + delimiter + b);
			sw.WriteLine(header);

			sw.WriteLine(properties
			.Select(n => n.GetValue(item, null))
			.Select(n => n == null ? "null" : n.ToString())
			.Aggregate((a, b) => a + delimiter + b));

			output = sw.ToString();
		}
		return output;
	}
}
