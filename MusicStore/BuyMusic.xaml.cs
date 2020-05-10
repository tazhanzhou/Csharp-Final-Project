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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int loginUserId;
        public int counter = 0;
        int musicsNumber = 0;
        int musicId = 1;
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var ctx = new MusicStoreContext())
            {
                musicsNumber = ctx.Musics.Where(m => m.available == true).Count();
                Music m1 = ctx.Musics.Where(m => m.available == true).FirstOrDefault();
                tbSong.Text = m1.musicName;
                tbAlbum.Text = m1.album;
                tbArtist.Text = m1.artist;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if(counter < musicsNumber-1)
            {
                counter++;
                using (var ctx = new MusicStoreContext())
                {
                    List<Music> fetchMusicList = ctx.Musics.Where(m => m.available == true).ToList();
                    tbSong.Text = fetchMusicList[counter].musicName;
                    tbAlbum.Text = fetchMusicList[counter].album;
                    tbArtist.Text = fetchMusicList[counter].artist;
                    musicId = fetchMusicList[counter].id;
                }
            }
            
        }

        private void btnPrivious_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                using (var ctx = new MusicStoreContext())
                {
                    List<Music> fetchMusicList = ctx.Musics.Where(m => m.available == true).ToList();
                    tbSong.Text = fetchMusicList[counter].musicName;
                    tbAlbum.Text = fetchMusicList[counter].album;
                    tbArtist.Text = fetchMusicList[counter].artist;
                    musicId = fetchMusicList[counter].id;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new MusicStoreContext())
            {
                Order order = new Order();
                order.Music = ctx.Musics.Where(m => m.id == musicId).FirstOrDefault();
                order.User = ctx.Users.Where(u => u.Id == loginUserId).FirstOrDefault();
                ctx.Orders.Add(order);
                ctx.SaveChanges();
                MessageBox.Show("One Music Added to Cart");
            }
        }

        private void goCart_Click(object sender, RoutedEventArgs e)
        {
            OrderView orderView = new OrderView();
            orderView.loginUserId = loginUserId;
            orderView.Show();
            this.Close();
        }
    }
}
