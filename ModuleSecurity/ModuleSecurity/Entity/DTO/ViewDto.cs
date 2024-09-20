

using Entity.Model.Security;

namespace Entity.Dto
{
    public class ViewDto
    {
        public Module IdModule;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
