using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface ISongService
    {
        // Retrieve all songs
        (bool, IEnumerable<Song>) GetSongs();

        // Add a new song
        void AddSong(Song song);

        // Update an existing song
        void UpdateSong(Song song);

        // Delete a song by passing the song object
        void DeleteSong(Song song);

        // Delete a song by its ID
        void DeleteSong(string id);
    }
}

