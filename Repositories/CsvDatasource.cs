using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Repositories;

internal class CsvDatasource : IDatasource
{
    private readonly CsvConfiguration _config = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        HeaderValidated = null,
        MissingFieldFound = null
    };

    private static string GetFilePath<T>()
    {
        var tableName = GetDataName<T>();
        return Path.Combine(Paths.Data, $"{tableName}.csv");
    }

    private static string GetEventFilePath<T>()
    {
        var tableName = GetDataName<T>();
        return Path.Combine(Paths.EventDataPath, $"{tableName}.tsv");
    }

    private static string? GetDataName<T>()
    {
        var tAttribute = (TableAttribute)
            typeof(T)?.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
        var tableName = tAttribute?.Name;
        return tableName;
    }

    public List<T> GetList<T>() where T : IItem
    {
        var itemFilePath = GetFilePath<T>();

        if (!File.Exists(itemFilePath))
        {
            return [];
        }

        var text = File.ReadAllText(itemFilePath);

        var reader = new StringReader(text);

        using var csv = new CsvReader(reader, _config);
        return csv.GetRecords<T>().ToList();
    }

    public List<T> GetList<T>(string path) where T : IItem
    {
        var itemFilePath = path;

        if (!File.Exists(itemFilePath))
        {
            return [];
        }

        var text = File.ReadAllText(itemFilePath);

        var reader = new StringReader(text);

        using var csv = new CsvReader(reader, _config);
        return csv.GetRecords<T>().ToList();
    }

    public void MakeBackup(string path)
    {
        throw new System.NotImplementedException();
    }

    public void Update<T>(T item)
        where T : IItem
    {
        var events = string.Empty;
        var itemFilePath = GetEventFilePath<T>();
        using var writer = new StreamWriter(itemFilePath, false, System.Text.Encoding.UTF8);
        using var csvText = new CsvWriter(writer, _config);
        csvText.WriteRecords(events);
        writer.Flush();
    }

    public List<T> GetDoneList<T>() where T : IExternalItem
    {
        var itemFilePath = GetEventFilePath<T>();

        if (!File.Exists(itemFilePath))
        {
            return [];
        }

        var text = File.ReadAllText(itemFilePath);

        var reader = new StringReader(text);

        // Use _config once all old tsvs are converted
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "\t",
            MissingFieldFound = null,
            BadDataFound = null
        };

        using var csv = new CsvReader(reader, config);
        return csv.GetRecords<T>().ToList();
    }
}
