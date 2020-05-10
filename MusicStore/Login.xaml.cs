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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int loginUserId = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new MusicStoreContext())
            {
                string uName = tbUserName.Text.Trim();
                string pwd = tbPassword.Text.Trim();
                bool isAdmin = rbAdmin.IsChecked ?? false;

                List<User> list1 = ctx.Users.Where(u => u.UserName == uName).ToList();

                if (list1.Count >= 1)
                {
                    User loginUser = ctx.Users.Where(u => u.UserName == uName).FirstOrDefault();
                    loginUserId = loginUser.Id;
                    List<User> list2 = ctx.Users.Where(u => u.UserName == uName && u.PassWord == pwd).ToList();
                    if (list2.Count >= 1)
                    {
                        if (isAdmin == false)
                        {
                            Window1 BuyMusic = new Window1();
                            BuyMusic.loginUserId = loginUserId;
                            this.Close();
                            BuyMusic.Show();
                        }
                        else
                        {
                            ManageMusic manageMusic = new ManageMusic();
                            this.Close();
                            manageMusic.Show();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Either the user name or password entered is incorrect.");
                    }

                }
                else
                {
                    MessageBox.Show("Either the user name or password entered is incorrect.");
                }

                //int howManyUsers = ctx.Users.Count();
                //User u1 = new User() { UserName = "Tony", PassWord = "123", isAdmin = true };
                //ctx.Users.Add(u1);
                //ctx.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
