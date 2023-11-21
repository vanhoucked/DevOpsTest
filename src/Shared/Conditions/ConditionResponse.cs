namespace Project.Shared.Conditions;

public static class ConditionResponse
{
    public class GetIndex
    {
        public List<ConditionDTO.Index> Conditions { get; set; } = new();
    }
    public class GetDetail
    {
        public ConditionDTO.Detail Condition { get; set; } = new();
    }
    public class Delete
    {

    }
    public class Create
    {
        public int ConditionId { get; set; }
    }
    public class Edit
    {
        public int ConditionId { get; set; }
    }
}
