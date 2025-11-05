namespace MovieRentalAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string MovieDescription { get; set; } = string.Empty;
        public bool IsRented { get; set; } = false;
        public DateTime? RentalDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}