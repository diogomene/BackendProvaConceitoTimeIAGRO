namespace BookAPIagro.Entities
{
    public abstract class Person(string name)
    {
        public string Name { get; set; } = name;
    }
}
