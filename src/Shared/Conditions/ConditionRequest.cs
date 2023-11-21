namespace Project.Shared.Conditions
{
    public static class ConditionRequest
    {
        public class GetIndex
        {
            public string? SearchTerm { get; set; }
            public int Page { get; set; }

            public int Amount { get; set; } = 25;

        }
        public class GetDetail
        {
            public int ConditionId { get; set; }
        }
        public class Delete
        {
            public int ConditionId { get; set; }

        }
        public class Create
        {
            public ConditionDTO.Mutate Condition { get; set; }
        }
        public class Edit
        {
            public int ConditionId { get; set; }
            public ConditionDTO.Mutate Condition { get; set; }

        }

    }
}

