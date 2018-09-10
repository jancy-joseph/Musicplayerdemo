using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Diagnostics;
using System.Text;
using Windows.Media.Playlists;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using Windows.UI.Core;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace musicapp1
{

    public sealed partial class MainPage : Page
    {
        MediaPlayer player;
        //Dictionary<string, MusicFile> MyMusicDictLst = new Dictionary<string, MusicFile>();
        public Dictionary<string, string> LibUserPlaylistLocationDict = new Dictionary<string, String>();
        string Jsonfilepath;
        UserPlaylist JsonPlaylist;


        public MainPage()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
            // LoadMyMusicCollection();
        }

        private async void LoadMyMusicCollection()
        {
            ObservableCollection<string> dataList = new ObservableCollection<string>();
            var MusicFileList = new List<MusicFile>();
            QueryOptions queryOption = new QueryOptions
                          (CommonFileQuery.OrderByTitle, new string[] { ".mp3", ".mp4", ".wma", ".ogg" });

            queryOption.FolderDepth = FolderDepth.Deep;

            Queue<IStorageFolder> folders = new Queue<IStorageFolder>();

            var files = await KnownFolders.MusicLibrary.CreateFileQueryWithOptions
                       (queryOption).GetFilesAsync();
            if (files.Count > 0)
            {
                foreach (var fileToAdd in files)
                {
                    if (MusicFile.MyMusicDictList.ContainsKey(fileToAdd.Name))
                        continue;
                    MusicProperties musicProperties = await fileToAdd.Properties.GetMusicPropertiesAsync();

                    var mymusic = new MusicFile()
                    {
                        MFileName = fileToAdd.Name,
                        MAlbum = musicProperties.Album,
                        MArtist = musicProperties.Artist,
                        MTitle = musicProperties.Title
                    };
                    this.ChoosePlaylist1.Items.Add(mymusic.MFileName);
                    MusicFile.MyMusicDictList.Add(mymusic.MFileName, fileToAdd);
                    //Trying to Bind an object to XAML didnot work so keeping for next time
                    MusicFileList.Add(mymusic);
                    dataList.Add(mymusic.MFileName);

                }
                //MyViewlist.ItemsSource = dataList;
                foreach (KeyValuePair<string, StorageFile> Music in MusicFile.MyMusicDictList)
                {
                    Debug.WriteLine("Music List");
                    Debug.WriteLine("Key = {0}, Value = {1}", Music.Key, Music.Value.Path);
                }
            }
            else
            {
                //MyMusicCollection.TxtUSER.txt= "Operation cancelled.";
                Debug.WriteLine("Operation cancelled in Music File");
            }



        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private async void ChoosePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;

            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".wav");
            picker.FileTypeFilter.Add(".wma");
            picker.FileTypeFilter.Add(".ogg");

            IReadOnlyList<StorageFile> files = await picker.PickMultipleFilesAsync();
            if (files.Count > 0)
            {
                //StringBuilder output = new StringBuilder("Picked files:\n");

                // Application now has read/write access to the picked file(s)
                foreach (Windows.Storage.StorageFile fileToAdd in files)
                {
                    MusicProperties musicProperties = await fileToAdd.Properties.GetMusicPropertiesAsync();

                    var mymusic = new MusicFile()
                    {
                        MFileName = fileToAdd.Name,
                        //MFile = fileToAdd,
                        MAlbum = musicProperties.Album,
                        MArtist = musicProperties.Artist,
                        MTitle = musicProperties.Title
                    };
                    MusicFile.MyMusicDictList.Add(mymusic.MFileName, fileToAdd);
                    this.ChoosePlaylist1.Items.Add(mymusic.MFileName);

                }
                foreach (KeyValuePair<string, StorageFile> Music in MusicFile.MyMusicDictList)
                {
                    Debug.WriteLine("Music List");
                    Debug.WriteLine("Key = {0}, Value = {1}", Music.Key, Music.Value.Path);
                }
            }
            else
            {
                this.ChoosePlaylist1.Items.Add("Operation cancelled.");
            }
        }

        private void ChoosePlaylist1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// Code to Play a file


            player.AutoPlay = false;
            Debug.WriteLine(ChoosePlaylist1.SelectedItem);
            foreach (KeyValuePair<string, StorageFile> Music in MusicFile.MyMusicDictList)
            {
                if (Music.Key == (string)ChoosePlaylist1.SelectedItem)
                {
                    player.Source = MediaSource.CreateFromStorageFile(Music.Value);
                    player.Play();

                }


            }



        }

        private  void CreatePLaylist_Button_Click(object sender, RoutedEventArgs e)
        {
            string Playlistusername = "JancyUser";

            var PLaylist1 = new UserPlaylist()
            {
                playlistName = txtPlaylistName.Text,
                playlistUserName = Playlistusername,
            };
            foreach (string Filename in this.ChoosePlaylist1.SelectedItems)
            {
                PLaylist1.LibUserPlaylist.Add(Filename);
                ChoosePlaylist2.Items.Add(Filename);

            }

            /*
            Jsonfilepath = await SerelizeDataToJson(PLaylist1, PLaylist1.playlistName);
            UserPlaylist playlistjson = await DeserelizeDataFromJson(Jsonfilepath);
            Debug.WriteLine(playlistjson.playlistName);
            Debug.WriteLine(playlistjson.playlistUserName);


            */

            foreach (string filetoplay in PLaylist1.LibUserPlaylist)
            {
                FindndPLayMusic(filetoplay);
            }

        }
/*
        public static async Task<UserPlaylist> DeserelizeDataFromJson(string fileName)
        {

            try
            {
                var DeserializedJsonPlayLst = new UserPlaylist();
                var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await Folder.GetFileAsync(fileName + ".json");
                var data = await file.OpenReadAsync();

                using (StreamReader r = new StreamReader(data.AsStream()))
                {
                    string text = r.ReadToEnd();
                    DeserializedJsonPlayLst = JsonConvert.DeserializeObject<UserPlaylist>(text);
                    //foreach (var i in p)
                    //{
                    //    persons.UserPlaylists.Add(i);
                    // }
                }
                return DeserializedJsonPlayLst;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        /*
        private static async Task<UserPlaylist> DeserelizeDataFromJson(string fileName)
        {
            try
            {
                var persons = new UserPlaylist();
                var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await Folder.GetFileAsync(fileName + ".json");
                var data = await file.OpenReadAsync();

                using (StreamReader r = new StreamReader(data.AsStream()))
                {
                    string text = r.ReadToEnd();
                    UserPlaylist[] p = JsonConvert.DeserializeObject<UserPlaylist[]>(text);
                    foreach (var i in p)
                    {
                        persons = UserPlaylist[i];
                    }
                }
                return persons;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
        private static async Task<string> SerelizeDataToJson(UserPlaylist MyListPlay, string filename)
        {
            try
            {
                var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await Folder.CreateFileAsync(filename + ".json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                var data = await file.OpenStreamForWriteAsync();

                using (StreamWriter r = new StreamWriter(data))
                {
                    var serelizedfile = JsonConvert.SerializeObject(MyListPlay);
                    r.Write(serelizedfile);

                }
                return filename;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        */
        private void FindndPLayMusic(string myFilename)
        {

            player.AutoPlay = false;
            //  Debug.WriteLine(ChoosePlaylist1.SelectedItem);
            foreach (KeyValuePair<string, StorageFile> Music in MusicFile.MyMusicDictList)
            {
                if (Music.Key == myFilename)
                {

                    player.Source = MediaSource.CreateFromStorageFile(Music.Value);
                    player.Play();

                }

            }


        }
       

    }

       

}

