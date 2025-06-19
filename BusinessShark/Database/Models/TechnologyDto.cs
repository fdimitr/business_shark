namespace BusinessShark.Database.Models
{
    internal class TechnologyDto
    {
        public int TechnologyId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public float ExponentBase { get; set; }
    }
}
