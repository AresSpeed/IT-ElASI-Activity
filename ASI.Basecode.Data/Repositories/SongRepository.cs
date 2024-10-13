using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class SongRepository : BaseRepository, ISongRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public SongRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        // Get all songs
        public IEnumerable<Song> ViewSongs()
        {
            return _dbContext.Songs.ToList();
        }

        // Add a new song
        public void AddSong(Song song)
        {
            this.GetDbSet<Song>().Add(song);
            UnitOfWork.SaveChanges();
        }

        // Update an existing song
        public void UpdateSong(Song song)
        {
            var existingSong = _dbContext.Songs.Find(song.Id);

            if (existingSong != null)
            {
                existingSong.Title = song.Title;
                existingSong.Artist = song.Artist;
                existingSong.ReleaseDate = song.ReleaseDate;
                existingSong.Genre = song.Genre;
                existingSong.Album = song.Album;

                _dbContext.SaveChanges();
            }
        }

        // Delete a song by entity
        public void DeleteSong(Song song)
        {
            if (song != null)
            {
                _dbContext.Remove(song);
                UnitOfWork.SaveChanges();
            }
        }

        // Delete a song by ID
        public void DeleteSong(string songId)
        {
            var song = GetSongById(songId);
            if (song != null)
            {
                _dbContext.Remove(song);
                UnitOfWork.SaveChanges();
            }
        }

        // Get song by ID
        public Song GetSongById(string id)
        {
            return _dbContext.Songs.FirstOrDefault(s => s.Id == id);
        }
    }
}

