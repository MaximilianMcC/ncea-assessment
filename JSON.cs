public class Root
{
    public List<Quesions> Questions { get; set; }
}

public class Quesions
{    
    public string Question { get; set; }
    public List<string> Answers { get; set; }
    public int Answer { get; set; }
}