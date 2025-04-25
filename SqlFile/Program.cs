using System.Text;
// first requirment 

public Interface ILead
{  
        void CreateSubTask();  
        void AssginTask();  
        void WorkOnTask();
}
public class TeamLead : ILead
{
    public void AssignTask()
    {
        // create a task
        Task t = new Task() { Title = "Merge and Deploy", Description = "Task to merge and deploy sharing feature to develop" };

        //Code to assign a task. 
        t.AssignTo(new Developer() { Name = "Developer1" });
    }
    public void CreateSubTask()
    {
        //Code to create a sub task  
    }
    public void WorkOnTask()
    {
        //Code to implement perform assigned task.  
    }
}

// second requirment 
public interface IRole
{
    void CreateSubTask();
    void AssginTask();
}
public class manager : IRole
{

}
    public Interface ILead : IRole
    {  
        void CreateSubTask();
        void AssginTask();
        void WorkOnTask();
    }
    public class TeamLead : ILead
{
    public void AssignTask()
    {
        // create a task
        Task t = new Task() { Title = "Merge and Deploy", Description = "Task to merge and deploy sharing feature to develop" };

        //Code to assign a task. 
        t.AssignTo(new Developer() { Name = "Developer1" });
    }
    public void CreateSubTask()
    {
        //Code to create a sub task  
    }
    public void WorkOnTask()
    {
        //Code to implement perform assigned task.  
    }
}




// final Requirments 
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
