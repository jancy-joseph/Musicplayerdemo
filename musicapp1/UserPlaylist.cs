using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicapp1
{
    class UserPlaylist
    {
        public string playlistName { get; set; }
        public string playlistUserName { get; set; }
        /// <summary>
        /// Lists of User Music Files names in a  Given Playlist
        /// </summary>
        public List<string> LibUserPlaylist = new List<string>();
        


        public void LoadMyMusic()
        {

        }
        public void AddSongToPlaylistTOcheckbox()
        {

        }
        public void DeleteSongsFromPlaylist()
        {

        }
        public void PlayMyMusic()
        {

        }

        /*
        public static  Task<ICollection<LibraryUser>> GetPlaylists()
        {
            
            var LibUsersList = new List<LibraryUser>();
            var filecontent = await FileHelper.ReadTextFileAsync(LOGIN_FILE_NAME);
            var lines = filecontent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var LibUser = new LibraryUser()
                {
                    UserName = lineParts[0],
                    USerPassword = lineParts[1]
                };
                LibUsersList.Add(LibUser);
            }
            return LibUsersList;
            
        }
    
        public static void WritePlaylistsToFile(LibraryUser myUser)
        {
            
            var LibUserData = $"{myUser.UserName},{myUser.USerPassword}\n";
            FileHelper.WriteTextFileAsync(LOGIN_FILE_NAME, LibUserData);
            
        }

    
        public static Task<bool> FindPlaylistsbyName(LibraryUser myUser)
        {
           

            var filecontent = await FileHelper.ReadTextFileAsync(LOGIN_FILE_NAME);
            var lines = filecontent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var LibUser = new LibraryUser()
                {
                    UserName = lineParts[0],
                    USerPassword = lineParts[1]
                };
                // Checking if the user object is in the Stored Login config file.
                if (LibUser.Equals(myUser))
                {
                    return true;
                }
            }
            return false;
          
        }
       */
       

    }
}
