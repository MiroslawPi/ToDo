namespace ToDo.Core.Domain
{
    public class Entity
    {
        //public Guid Id { get; protected set; }
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}