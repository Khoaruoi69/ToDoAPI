namespace TodoAPI.Models.ViewModel.Tasks
{
    public class CreateTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public Guid? Id { get; set; }
    }
}
