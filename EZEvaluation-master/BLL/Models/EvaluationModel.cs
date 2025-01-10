using BLL.DAL;

namespace BLL.Models;

public class EvaluationModel
{
    public Evaluation Record { get; set; }

    public string Title => Record.Title;
    
    public string Score => Record.Score.ToString();
    
    public string Date => !Record.Date.HasValue ? string.Empty : Record.Date.Value.ToString("MM/dd/yyyy");
    
    public string Description => Record.Description;
    
    public User User => Record.User;

    public string Evaluateds => string.Join("<br>", Record.EvaluatedEvaluations?.Select(ee => ee.Evaluated.Name));
    
    public int EvaluatedsCount => Record.EvaluatedEvaluations?.Count ?? 0;

    public List<int> EvaluatedIds
    {
        get => Record.EvaluatedEvaluations?.Select(ee => ee.EvaluatedId).ToList();
        set => Record.EvaluatedEvaluations = value.Select( v => new EvaluatedEvaluations { EvaluatedId = v }).ToList();
    }

}