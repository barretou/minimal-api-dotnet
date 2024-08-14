namespace ApiCrud.Api.Models
{
	public class StudentModel
	{
		public Guid Id { get; init; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public StudentModel(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            IsActive = true;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
		public void UpdateState(bool state)
		{
			IsActive = state;
		}

	}
}
