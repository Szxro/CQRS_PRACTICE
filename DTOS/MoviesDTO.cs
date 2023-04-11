namespace DTOS
{
    public class MoviesDTO
    {
        public string Name { get; set; } = null!;

        public bool isLive { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}