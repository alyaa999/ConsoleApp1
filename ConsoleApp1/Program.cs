// Segregated interfaces
public interface ITaskCreator
{
    void CreateSubTask();
}

public interface ITaskAssigner
{
    void AssignTask();
}

public interface ITaskWorker
{
    void WorkOnTask();
}

public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string AssignedTo { get; private set; }
    public void AssignTo(Developer developer)
    {
        AssignedTo = developer.Name;
        Console.WriteLine($"Task '{Title}' assigned to {AssignedTo}");
    }
}

public class Developer
{
    public string Name { get; set; }    
}

public class TeamLead : ITaskCreator, ITaskAssigner, ITaskWorker
{
    public void AssignTask()
    {
        Task t = new Task()
        {
            Title = "Merge and Deploy",
            Description = "Task to merge and deploy sharing feature to develop"
        };
        t.AssignTo(new Developer() { Name = "Developer1" });
    }

    public void CreateSubTask()
    {
        // Logic to create subtask
    }

    public void WorkOnTask()
    {
        // Logic to work on a task
    }
}

public class Manager : ITaskAssigner
{
    public void AssignTask()
    {
        // Manager assigns a task but doesn’t work on it
    }
}
