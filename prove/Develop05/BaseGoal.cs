public abstract class Goal
{
    protected string name;
    protected string description;
    protected internal int goalPoints;

    public Goal(string name, string description)
    {
        this.name = name;
        this.description = description;
        goalPoints = 0;
    }
 
    public virtual string Display()
    {
        return $"{name} ({description})";
    }

    public abstract void RecordProgress();

    public virtual string Save()
    {
        return $"{GetType().Name}:{name},{description},{goalPoints},{IsCompleted()}";
    }
    public virtual bool IsCompleted()
    {
        System.Console.WriteLine("Is completed base class");
        return false; // For Eternal Goals, which are never marked as completed
    }
}