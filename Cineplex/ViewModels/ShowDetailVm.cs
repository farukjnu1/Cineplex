using Cineplex.Models;

namespace Cineplex.ViewModels
{
    public class ShowDetailVm
    {
        public int ShowDetailsId { get; set; }

        public int? ShowId { get; set; }

        public int? HallId { get; set; }

        public string? SeatNumber { get; set; }

        public bool? IsBooked { get; set; }

        public int? CustomerId { get; set; }

    }
}
