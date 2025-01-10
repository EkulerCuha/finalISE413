using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class EvaluatedService : Service, IService<Evaluated, EvaluatedModel>
{
    public EvaluatedService(Db db) : base(db) { }

    public IQueryable<EvaluatedModel> Query()
    {
        return _db.Evaluateds.OrderByDescending(e => e.Name).ThenBy(e => e.Surname)
            .Select(e => new EvaluatedModel() { Record = e });
    }

    public Service Create(Evaluated record)
    {
        if(_db.Evaluateds.Any(e => e.Name.ToUpper() == record.Name.ToUpper().Trim() && e.Surname.ToUpper() == record.Surname.ToUpper().Trim() && e.Id == record.Id))
            return Error("Duplicate name");
        
        record.Name = record.Name.Trim();
        record.Surname = record.Surname.Trim();
        
        _db.Evaluateds.Add(record);
        _db.SaveChanges();
        return Success("Evaluated" + record.Name);
    }

    public Service Update(Evaluated record)
    {
        throw new NotImplementedException();
    }

    public Service Delete(int id)
    {
        throw new NotImplementedException();
    }
    
}