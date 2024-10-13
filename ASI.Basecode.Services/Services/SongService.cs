using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.IO;
public class SongService : ISongService
{
    private readonly ISongRepository _songRepository;

    // Constructor
    public SongService(ISongRepository songRepository)
    {
        this._songRepository = songRepository;
    }

    // Get all songs
    public (bool, IEnumerable<Song>) GetSongs()
    {
        var songs = _songRepository.ViewSongs();
        if (songs != null)
        {
            return (true, songs);
        }
        else
        {
            return (false, null);
        }
    }

    // Add a new song
    public void AddSong(Song song)
    {
        try
        {
            var newSong = new Song
            {
                Title = song.Title,
                Artist = song.Artist,
                ReleaseDate = song.ReleaseDate,
                Genre = song.Genre,
                Album = song.Album
            };
            _songRepository.AddSong(newSong);
        }
        catch (Exception)
        {
            throw new InvalidDataException("Error adding song");
        }
    }

    // Update an existing song
    public void UpdateSong(Song song)
    {
        if (song == null || string.IsNullOrEmpty(song.Id))
        {
            throw new ArgumentNullException(nameof(song));
        }

        var existingSong = _songRepository.GetSongById(song.Id);
        if (existingSong == null)
        {
            throw new KeyNotFoundException("Song not found.");
        }

        existingSong.Title = song.Title;
        existingSong.Artist = song.Artist;
        existingSong.ReleaseDate = song.ReleaseDate;
        existingSong.Genre = song.Genre;
        existingSong.Album = song.Album;

        _songRepository.UpdateSong(existingSong);
    }

    // Delete a song by ID
    public void DeleteSong(string songId)
    {
        if (string.IsNullOrEmpty(songId))
        {
            throw new ArgumentNullException(nameof(songId));
        }

        var song = _songRepository.GetSongById(songId);
        if (song == null)
        {
            throw new KeyNotFoundException("Song not found.");
        }

        _songRepository.DeleteSong(songId);
    }

    // Delete a song by object
    public void DeleteSong(Song song)
    {
        throw new NotImplementedException();
    }
}

