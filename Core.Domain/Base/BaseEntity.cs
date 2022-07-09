namespace Core.Domain.Base
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

    }

    public class BaseEntity : BaseEntity<int>
    {

    }
}
