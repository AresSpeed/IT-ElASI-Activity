using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using Microsoft.AspNetCore.Http;
public class SongViewModel
{
    [JsonPropertyName("Title")]
    [Required(ErrorMessage = "Song title is required.")]
    public string Title { get; set; }

    [JsonPropertyName("Artist")]
    [Required(ErrorMessage = "Artist name is required.")]
    public string Artist { get; set; }

    [JsonPropertyName("Album")]
    public string Album { get; set; }

    [JsonPropertyName("ReleaseDate")]
    [Required(ErrorMessage = "Release date is required.")]
    public DateTime ReleaseDate { get; set; }

    [JsonPropertyName("Duration")]
    [Required(ErrorMessage = "Song duration is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Duration must be greater than zero.")]
    public double Duration { get; set; } // Duration in minutes

    [JsonPropertyName("Genre")]
    public string Genre { get; set; }
}