public class Root
{
    public List<Quiz> Quiz { get; set; }

}

public class Quiz
{
    public string Name { get; set; }
    public List<QuestionObject> Questions { get; set; }
}

public class QuestionObject
{
    public string Question { get; set; }
    public List<string> Answers { get; set; }
    public int Answer { get; set; }
}
