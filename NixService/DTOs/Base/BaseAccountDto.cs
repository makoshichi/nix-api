namespace NixService.DTOs.Base
{
    public abstract class BaseAccountDto
    {
        public int Id { get; set; }
        public decimal PurchaseValue { get; set; }
        public string Description { get; set; }
        public ClientDto ClientAccount { get; set; }
    }
}
