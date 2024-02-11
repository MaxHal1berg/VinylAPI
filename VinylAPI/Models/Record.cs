using System;
using System.Collections.Generic;

namespace VinylAPI.Models;

public partial class Record
{
    public int RecordId { get; set; }

    public string? RecordPictureUrl { get; set; }

    public string? AlbumName { get; set; }

    public string? ArtistName { get; set; }

    public int? ReleaseYear { get; set; }

    public string? AlbumSongs { get; set; }

    public int? MyRating { get; set; }

    public string? WhatCollection { get; set; }
}
