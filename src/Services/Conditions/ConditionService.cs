using Microsoft.EntityFrameworkCore;
using Project.Domain.Conditions;
using Project.Shared.Conditions;
using Project.Persistence.Data;

namespace Project.Services.Conditions;

public class ConditionService : IConditionService
{

    private readonly OogArtsDbContext _context;
    private readonly DbSet<Condition> _conditions;

    public ConditionService(OogArtsDbContext dataContext)
    {
        _context = dataContext;
        _conditions = dataContext.Conditions;
    }
    private IQueryable<Condition> GetConditionById(int id)
    {
        return _conditions.AsNoTracking().Where(c => c.Id == id);
    }

    public async Task<ConditionResponse.Create> CreateAsync(ConditionRequest.Create request)
    {
        ConditionResponse.Create response = new();
        var c = new Condition(request.Condition.Name, request.Condition.ShortDescription, request.Condition.LongDescription);
        var condition = _conditions.Add(c);
        await _context.SaveChangesAsync();
        response.ConditionId = c.Id;
        return response;
    }

    public async Task DeleteAsync(ConditionRequest.Delete request)
    {
        var condition = await _conditions.SingleAsync(p => p.Id == request.ConditionId);
        _context.Remove(condition);
        await _context.SaveChangesAsync();
    }

    public async Task<ConditionResponse.Edit> EditAsync(ConditionRequest.Edit request)
    {
        ConditionResponse.Edit response = new();
        var condition = await _conditions.SingleAsync(x => x.Id == request.ConditionId);
        if (condition is not null)
        {
            var model = request.Condition;
            condition.Name = model.Name ?? condition.Name;
            condition.ShortDescription = model.ShortDescription ?? condition.ShortDescription;
            condition.LongDescription = model.LongDescription ?? condition.LongDescription;

            await _context.SaveChangesAsync();
            response.ConditionId = condition.Id;
        }
        return response;
    }

    public async Task<ConditionResponse.GetDetail> GetDetailAsync(ConditionRequest.GetDetail request)
    {
        ConditionResponse.GetDetail response = new();
        response.Condition = await _conditions.AsNoTracking()
            .Select(x => new ConditionDTO.Detail
        {
            Id = x.Id,
            Name  = x.Name,
            ShortDescription = x.ShortDescription,
            LongDescription = x.LongDescription,
            }).SingleAsync(x => x.Id == request.ConditionId);
        return response;
    }

    public async Task<ConditionResponse.GetIndex> GetIndexAsync(ConditionRequest.GetIndex request)
    {
        ConditionResponse.GetIndex response = new();
        var query = _conditions.AsQueryable().AsNoTracking();
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(x => x.Name.Contains(request.SearchTerm));

        }
        query = query.Take(request.Amount);
        query = query.Skip(request.Amount * request.Page);
        query.OrderBy(x => x.Name);

        response.Conditions = await query.Select(x => new ConditionDTO.Index { Id = x.Id, Name = x.Name, ShortDescription = x.ShortDescription }).ToListAsync();
        return response;
    }
}
