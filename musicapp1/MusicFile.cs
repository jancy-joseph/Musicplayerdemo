using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;

namespace musicapp1
{
    class MusicFile
    {
        /*
       public string Album { get; set; }
       public string AlbumArtist { get; set; }
       public string Artist { get; set; }
       public uint Bitrate { get; }
     //  public IList<string> Composers { get; }
     //  public IList<string> Conductors { get; }
       public TimeSpan Duration { get; }
       public IList<string> Genre { get; }
      // public IList<string> Producers { get; }
      // public string Publisher { get; set; }
       //public uint Rating { get; set; }
       public string Subtitle { get; set; }
       public string Title { get; set; }
       public uint TrackNumber { get; set; }
      // public IList<string> Writers { get; }
       public uint Year { get; set; }

   */
        /// <summary>
        /// Source of the file to play using Mediaplayer
        /// </summary>
        //public StorageFile MFile { get; set; }
        /// <summary>
        /// Name of the File to be played
        /// </summary>
        public string MFileName { get; set; }
        /// <summary>
        /// Adding a cover Image property
        /// </summary>
        public string McoverImage { get; set; } = "Assets/icons8-international-music-96.png";
        /// <summary>
        /// Name of the Albumn
        /// </summary>
        public string MAlbum { get; set; }
        /// <summary>
        /// Name of the  Artist
        /// </summary>
        public string MArtist { get; set; }
        /// <summary>
        /// Title of the SOng
        /// </summary>
        public string MTitle { get; set; }

        public static Dictionary<string, StorageFile> MyMusicDictList = new Dictionary<string, StorageFile>();


    }
}