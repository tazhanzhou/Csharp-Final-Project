using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for ManageMusic.xaml
    /// </summary>

    public partial class ManageMusic : Window
    {
        MusicStoreContext musicStoreContext = new MusicStoreContext();
        public ManageMusic()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bindData();
        }
        public void bindData()
        {
            var query = from music in musicStoreContext.Musics
                        select new { music.id, music.musicName, music.album, music.artist, music.available };
            this.DataContext = query.ToList();
            //dataGrid.ItemsSource = query.ToList();
            //using (var ctx = new MusicStoreContext())
            //{
            //    List<Music> list1 = ctx.Musics.Select(m => m).ToList();
            //    dataGrid.ItemsSource = list1;
            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMusic addMusic = new AddMusic();
            addMusic.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            dynamic row = dataGrid.SelectedItem;
            EditMusic editMusic = new EditMusic();
            editMusic.id = row.id;
            editMusic.tbName.Text = row.musicName;
            editMusic.tbAlbum.Text = row.album;
            editMusic.tbArtist.Text = row.artist;
            editMusic.tbAvailable.Text = (row.available).ToString();
            editMusic.Show();
            this.Close();
        }
    }
}
