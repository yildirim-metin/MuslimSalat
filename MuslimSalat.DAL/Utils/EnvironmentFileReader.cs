namespace MuslimSalat.DAL.Utils;

public class EnvironmentFileReader
{
    private readonly string _envPath;

    public EnvironmentFileReader()
    {
        var baseDir = AppContext.BaseDirectory;
        var projectRoot = Path.GetFullPath(Path.Combine(baseDir, @$"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}.."));
        _envPath = Path.Combine(projectRoot, ".env");
    }

    public void Load()
    {
        foreach (string line in File.ReadAllLines(_envPath))
        {
            string[] parts = line.Split(':');
            if (Environment.GetEnvironmentVariable(parts[0]) == null)
            {
                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }

    public static string GetConnectionString()
    {
        return Environment.GetEnvironmentVariable("CONNECTION_STRING")
               ?? throw new NullReferenceException("CONNECTION_STRING does not exists in environment variables");
    }
}