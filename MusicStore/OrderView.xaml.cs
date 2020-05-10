using MahApps.Metro.Controls;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>

    public partial class OrderView : Window
    {
        public int loginUserId;
        MusicStoreContext musicStoreContext = new MusicStoreContext();
        public OrderView()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bindData();
        }
        public void bindData()
        {
            var query = from order in musicStoreContext.Orders
                        join music in musicStoreContext.Musics on order.Music.id equals music.id
                        where order.User.Id == loginUserId
                        select new { order.Id, music.musicName, music.album, music.artist };
            this.DataContext = query.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = dataGrid.SelectedItem;
            int selectedOrderId = row.Id;
            using (var ctx = new MusicStoreContext())
            {
                Order order = ctx.Orders.Where(o => o.Id == selectedOrderId).FirstOrDefault();
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
                bindData();
            }
        
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window1 buyMusic = new Window1();
            buyMusic.loginUserId = loginUserId;
            buyMusic.Show();
            this.Close();
        }
    }
}
