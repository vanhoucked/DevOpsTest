namespace Project.Shared.Conditions
{
    public interface IConditionService
    {
        Task<ConditionResponse.GetIndex> GetIndexAsync(ConditionRequest.GetIndex request);
        Task<ConditionResponse.GetDetail> GetDetailAsync(ConditionRequest.GetDetail request);

        Task DeleteAsync(ConditionRequest.Delete request);

        Task<ConditionResponse.Create> CreateAsync(ConditionRequest.Create request);

        Task<ConditionResponse.Edit> EditAsync(ConditionRequest.Edit request);
    }
}
