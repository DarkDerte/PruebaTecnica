namespace Api.Business.DTO
{
    public class ContractDTO
    {
        public ulong Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
