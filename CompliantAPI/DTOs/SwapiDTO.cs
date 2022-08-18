namespace CompliantAPI.DTOs
{
    public class SwapiDTO
    {
        public int Count { get; set; }
        public string? Next { get;set; }
        public string? Previous { get;set; }
        public List<ResultDTO>? Results { get; set; }
    }
    public class ResultDTO
    {
        public string? Name { get; set; }
        public string? Height { get; set; }
        public string? Mass { get; set; }
        public string? Hair_Color { get; set; }
        public string? Skin_Color { get; set; }
        public string? Eye_Color { get; set; }
        public string? Birth_Year { get; set; }
        public string? Gender { get; set; }
        public string? HomeWorld { get; set; }
    }
}
