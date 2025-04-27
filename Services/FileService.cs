using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo_ListApp.Models;

namespace ToDo_ListApp.Services;

public static class FileService
{
    private static string _jsonFileName = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "AvaloniaToDoList", "MyToDoList.txt");

    public static async Task SaveToFileAsync(IEnumerable<Item> itemsToSave)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);

        using (var fs = File.Create(_jsonFileName))
        {
            await JsonSerializer.SerializeAsync(fs, itemsToSave);
        }
    }

    public static async Task<IEnumerable<Item>> LoadFromFileAsync()
    {
        try
        {
            using (var fs = File.OpenRead(_jsonFileName))
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<Item>>(fs);
            }
        }
        catch (Exception e) when(e is FileNotFoundException || e is DirectoryNotFoundException)
        {
            return null;
        }
    }
}