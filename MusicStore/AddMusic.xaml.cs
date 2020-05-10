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
    /// Interaction logic for AddMusic.xaml
    /// </summary>
    public partial class AddMusic : Window
    {
        public AddMusic()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new MusicStoreContext())
            {
                Music m1 = new Music()
                {
                    musicName = tbName.Text,
                    album = tbAlbum.Text,
                    artist = tbArtist.Text,
                    available = bool.Parse(tbAvailable.Text)
                };
                ctx.Musics.Add(m1);
                ctx.SaveChanges();
                MessageBox.Show("Add to Database Successful");
                tbName.Clear();
                tbAlbum.Clear();
                tbArtist.Clear();
                tbAvailable.Clear();
            }

        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            ManageMusic manageMusic = new ManageMusic();
            manageMusic.Show();
            this.Close();
        }
    }
}
