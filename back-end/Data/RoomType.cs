using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? PricePerHour { get; set; }

    public decimal PricePerNight { get; set; }

    public int NumberOfBathrooms { get; set; }

    public int NumberOfBeds { get; set; }

    public int? DoubleBed { get; set; }

    public int? SingleBed { get; set; }

    public int Sizes { get; set; }

    public int Capacity { get; set; }

    public string Thumbnail { get; set; } = null!;

    public string Images { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int HotelId { get; set; }

    public virtual ICollection<BookingRoomType> BookingRoomTypes { get; set; } = new List<BookingRoomType>();

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<CategoryDetail> CategoryDetails { get; set; } = new List<CategoryDetail>();
}
