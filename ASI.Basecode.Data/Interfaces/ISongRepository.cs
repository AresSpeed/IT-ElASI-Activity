using ASI.Basecode.Data.Models;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface ISongRepository
    {
        // Retrieve all songs
        public IEnumerable<Song> ViewSongs();

        // Add a new song
        void AddSong(Song song);

        // Update an existing song
        void UpdateSong(Song song);

        // Delete a song by its object
        void DeleteSong(Song song);

        // Get a song by its ID
        Song GetSongById(string id);

        // Delete a song by its ID
        void DeleteSong(string songId);
    }
}

