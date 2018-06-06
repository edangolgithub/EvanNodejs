using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace NodeJsWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declare member objects
        // Client for tcp, network stream to read bytes in socket
        TcpClient tcpClient = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = string.Empty;
        string msg = "Conected to Chat Server ...";

        public MainWindow()
        {
            InitializeComponent();

        }

        // Purpose:     Connect to node.js application (lamechat.js)
        // End Result:  node.js app now has a socket open that can send
        //              messages back to this tcp client application
        private void cmdConnect_Click(object sender, RoutedEventArgs e)
        {
            AddPrompt();
            tcpClient.Connect("127.0.0.1", 8000);
            serverStream = tcpClient.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(txtChatName.Text.Trim()
                                  + " is joining");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            // upload as javascript blob
            Task taskOpenEndpoint = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    // Read bytes
                    serverStream = tcpClient.GetStream();
                    byte[] message = new byte[4096];
                    int bytesRead;
                    bytesRead = 0;

                    try
                    {
                        // Read up to 4096 bytes
                        bytesRead = serverStream.Read(message, 0, 4096);
                    }
                    catch
                    {
                        /*a socket error has occured*/
                    }

                    //We have rad the message.
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    // Update main window
                    AddMessage(encoder.GetString(message, 0, bytesRead));
                    Thread.Sleep(500);
                }
            });
        }

        // Purpose:     Updates the window with the newest message received
        // End Result:  Will display the message received to this tcp based client
        private void AddMessage(string msg)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, (ThreadStart)(
             () =>
             {
                 this.txtConversation.Text += string.Format(
                          Environment.NewLine + Environment.NewLine +
                          " >> {0}", msg);

             }));
        }

        // Purpose:     Adds the " >> " prompt in the text box
        // End Result:  Shows prompt to user
        private void AddPrompt()
        {
            txtConversation.Text = txtConversation.Text +
                Environment.NewLine + " >> " + msg;
        }

        // Purpose:     Send the text in typed by the user (stored in
        //              txtOutMsg)
        // End Result:  Sends text message to node.js (lamechat.js)
        private void cmdSendMessage_Click(object sender, RoutedEventArgs e)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(txtOutMsg.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
    }
}

