﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[assembly: InternalsVisibleTo("RealtimeTests")]

namespace Powerbase.Realtime.Converters;

/// <summary>
/// An int array converter that specifically parses Postgrest styled arrays `{1,2,3}` and `[1,2,3]` from strings
/// into a <see cref="List{T}"/>.
/// </summary>
public class IntArrayConverter : JsonConverter
{
    /// <inheritdoc />
    public override bool CanRead => true;

    /// <inheritdoc />
    public override bool CanWrite => false;

    /// <inheritdoc />
    public override bool CanConvert(Type objectType) => throw new NotImplementedException();

    /// <inheritdoc />
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        try
        {
            if (reader.Value != null)
                return Parse((string)reader.Value);

            var jo = JArray.Load(reader);
            return jo.ToObject<List<int>>(serializer);
        }
        catch
        {
            return null;
        }
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    internal static List<int> Parse(string value)
    {
        var result = new List<int>();

        var firstChar = value[0];
        var lastChar = value[value.Length - 1];

        switch (firstChar)
        {
            // {1,2,3}
            case '{' when lastChar == '}':
            {
                var array = value.Trim(new char[] { '{', '}' }).Split(',');
                foreach (var item in array)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    result.Add(int.Parse(item));
                }

                return result;
            }
            // [1,2,3]
            case '[' when lastChar == ']':
            {
                var array = value.Trim(new char[] { '[', ']' }).Split(',');
                foreach (var item in array)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    result.Add(int.Parse(item));
                }

                return result;
            }
            default:
                return result;
        }
    }
}