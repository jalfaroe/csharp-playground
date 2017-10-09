namespace IMS.Domain.Entities
{
    public class Article : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal TotalInShelf { get; set; }
        public decimal TotalInVault { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}