namespace GestionCommerciale.Shared.Database;

public static class DatabasePath
{
    public const string FileName = "ECOMATI_DB.db";

    public static string GetDirectory()
    {
        var dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "EcomatiSociete");
        Directory.CreateDirectory(dir);
        return dir;
    }

    public static string GetFilePath()
    {
        var dir = GetDirectory();
        var dbPath = Path.Combine(dir, FileName);

        // One-time migrate from previous filenames / folders if present.
        if (!File.Exists(dbPath))
        {
            var legacyPaths = new[]
            {
                Path.Combine(dir, "data.db"),
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "GestionCommerciale",
                    "data.db"),
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "GestionCommerciale",
                    FileName)
            };

            foreach (var legacy in legacyPaths)
            {
                if (!File.Exists(legacy)) continue;
                File.Copy(legacy, dbPath);
                break;
            }
        }

        return dbPath;
    }

    public static string GetConnectionString() => $"Data Source={GetFilePath()}";
}
