using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class EvaluationService : Service, IService<Evaluation, EvaluationModel>
{
    public EvaluationService(Db db) : base(db)
    {
    }

    public IQueryable<EvaluationModel> Query()
    {
        return _db.Evaluations.Include(e => e.EvaluatedEvaluations).ThenInclude(ee => ee.Evaluated).OrderBy(e => e.Date)
            .Select(e => new EvaluationModel() { Record = e });
    }

    public Service Create(Evaluation record)
    {
        record.Title = record.Title?.Trim();
        record.Description = record.Description?.Trim();
        
        _db.Evaluations.Add(record);
        _db.SaveChanges();
        return Success("Evaluation Created");
    }

    public Service Update(Evaluation record)
    {
        var entity = _db.Evaluations.Include(e => e.EvaluatedEvaluations).SingleOrDefault(e => e.Id == record.Id);
        
        if(entity is null) 
            return Error("Record not found");
        
        _db.EvaluatedEvaluations.RemoveRange(entity.EvaluatedEvaluations);
        
        entity.Title = record.Title.Trim();
        entity.Score = record.Score;
        entity.Date = record.Date;
        entity.Description = record.Description.Trim();
        entity.UserId = record.UserId;
        
        entity.EvaluatedEvaluations = record.EvaluatedEvaluations;
        
        _db.Evaluations.Update(entity);
        _db.SaveChanges();
        return Success("Evaluation Updated");
    }

    public Service Delete(int id)
    {
        var evaluation = _db.Evaluations.Find(id);
        
        if(evaluation is null)
            return Error("Record not found");
        
        _db.EvaluatedEvaluations.RemoveRange(evaluation.EvaluatedEvaluations);
        
        _db.Evaluations.Remove(evaluation);
        _db.SaveChanges();
        return Success("Evaluation Deleted");
    }
}