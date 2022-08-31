namespace TodoAPI.Models.ViewModel.Tasks
{
    public class TasksVM
    {
        public Guid Ids { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public Guid? Id { get; set; }
    }
}
