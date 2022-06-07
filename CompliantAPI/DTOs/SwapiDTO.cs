namespace CompliantAPI.DTOs
{
    public class SwapiDTO
    {
        public int Count { get; set; }
        public List<ResultDTO>? Results { get; set; }
    }
    public class ResultDTO
    {
        public string? Name { get; set; } 
        public int Height { get; set; } 
        public int Mass { get; set; } 
        public string? HairColor { get; set; } 
        public string? SkinColor { get; set; } 
        public string? EyeColor { get; set; } 
        public string? BirthYear { get; set; } 
        public string? Gender { get; set; } 
        public string? HomeWorld { get; set; } 
    }
}
