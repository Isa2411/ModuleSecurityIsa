namespace Entity.Model.Security
{
    public class Module
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool State { get; set; }
    }
}
