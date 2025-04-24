using System.Text;

public interface ITextLoader
{
    string LoadText();
}

public interface ITextSaver
{
    void SaveText();
}

public class SqlFile : ITextLoader, ITextSaver
{
    public string FilePath { get; set; }
    public string FileText { get; set; }

    public string LoadText()
    {
        return File.ReadAllText(FilePath);
    }

    public void SaveText()
    {
        File.WriteAllText(FilePath, FileText);
    }
}
public class ReadOnlySqlFile : ITextLoader
{
    public string FilePath { get; set; }
    public string FileText { get; set; }

    public string LoadText()
    {
        return File.ReadAllText(FilePath);
    }

}

public class SqlFileLoaderManager
{
    public List<ITextLoader> FilesToLoad { get; set; }

    public string GetTextFromFiles()
    {
        var sb = new StringBuilder();
        foreach (var file in FilesToLoad)
        {
            sb.Append(file.LoadText());
        }
        return sb.ToString();
    }
}

public class SqlFileSaverManager
{
    public List<ITextSaver> FilesToSave { get; set; }

    public void SaveTextIntoFiles()
    {
        foreach (var file in FilesToSave)
        {
            file.SaveText();
        }
    }
}
