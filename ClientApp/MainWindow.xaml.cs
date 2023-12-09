using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UdpClient client = new UdpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ip = ipTB.Text;
            int port = int.Parse(portTB.Text);

            string message = msgTB.Text;

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), port);

            client.Send(Encoding.UTF8.GetBytes(message), endpoint);

            // TODO: run receiving in Task

            IPEndPoint? server = null;
            var data = client.Receive(ref server);

            var response = Encoding.UTF8.GetString(data);
            dialogList.Items.Add(response);
        }
    }
}
