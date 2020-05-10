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
    /// Interaction logic for EditMusic.xaml
    /// </summary>
    public partial class EditMusic : Window
    {
        public int id = 0;
        public EditMusic()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            
            
            using (var ctx = new MusicStoreContext())
            {
                Music m1 = ctx.Musics.Where(m => m.id == id).FirstOrDefault();
                m1.id = id;
                m1.musicName = tbName.Text;
                m1.album = tbAlbum.Text;
                m1.artist = tbArtist.Text;
                m1.available = bool.Parse(tbAvailable.Text);
                ctx.SaveChanges();
                MessageBox.Show("Edited Successful");
                ManageMusic manageMusic = new ManageMusic();
                manageMusic.Show();
                this.Close();
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
