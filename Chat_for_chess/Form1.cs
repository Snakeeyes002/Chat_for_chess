using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace Chat_for_chess
{
    public partial class Form1 : Form
    {
        Socket sck;
        Socket sck1;
        EndPoint epLocal, epRemote,epCLocal,epCRemote;
        Button[,] field = new Button[8, 8];
        TextChessGame.Player player;
        int x, y,to_x,to_y;
        public Form1()
        {
            x = y = to_x = to_y = 9;
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            sck1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            Client1IPBox.Text = GetLocalIP();
            Client2IPBox.Text = GetLocalIP();
            SendButton.Enabled = false;
            WhiteButton.Enabled = false;
            BlackButton.Enabled = false;
            //Random r = new Random(100);
            //for (int i = 0; i < 5; i++)
            //{
            //    field[r.Next(8), r.Next(8)].Text = i.ToString();

            //}
        }
        private void Turn()
        {
            if(player.Move(x, y, to_x, to_y))
            {
                field[to_x, to_y].Text = player.CB.arr[to_x, to_y].ToString();
                field[x, y].Text = player.CB.arr[x, y].ToString();
                 player.YourTurn = false;
                //listMessage.Items.Add(player.CB.arr);
                sck1.Send(player.CB.ToByte());
            }
            x = y = to_x = to_y = 9;
        }
        private void Item_Click(object sender, EventArgs e)
        { if (player.YourTurn)
            {if (x == 9)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((sender as Button) == field[i, j])
                            {
                                x = i; y = j;
                              //  MessageBox.Show($"{x}  {y}");
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((sender as Button) == field[i, j])
                            {
                                
                                to_x = i; to_y = j;
                                if (to_x == x && to_y == y)
                                    return;
                               // MessageBox.Show($" to {to_x}  {to_y}");
                                Turn();
                            }
                        }
                    }
                    x = y = to_x = to_y = 9;
                }
            }
           
        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if(ip.AddressFamily==AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
        private void MessageCallBack(IAsyncResult Result)
        {
            try
            {
                int size = sck.EndReceiveFrom(Result, ref epRemote);
                if(size>0)
                {
                   
                    byte[] receivedData = new byte[4096];
                    receivedData = (byte[])Result.AsyncState;
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);
                    listMessage.Items.Add("Friend: "+receivedMessage);
                }
                byte[] buffer= new byte[4096];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote,new AsyncCallback(MessageCallBack),buffer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ChessCallBack(IAsyncResult Result)
        {
            try
            {
                int size1 = sck1.EndReceiveFrom(Result, ref epCRemote);
                if (size1 > 0)
                {

                    byte[] receivedData1 = new byte[64];
                    receivedData1 = (byte[])Result.AsyncState;
                    player.CB.FromBytes(receivedData1);
                    player.CB.BoardForBlack();
                    player.YourTurn = true;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            field[i, j].Text = player.CB.arr[i, j].ToString();
                        }
                    }
                        }
                byte[] buffer1 = new byte[64];
                sck1.BeginReceiveFrom(buffer1, 0, buffer1.Length, SocketFlags.None, ref epCRemote, new AsyncCallback(ChessCallBack), buffer1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Client1GroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
               epCLocal = new IPEndPoint(IPAddress.Parse(Client1IPBox.Text), Convert.ToInt32(CPortBox1.Text));
                epLocal = new IPEndPoint(IPAddress.Parse(Client1IPBox.Text), Convert.ToInt32(Client1PortBox.Text));
                sck.Bind(epLocal);
                sck1.Bind(epCLocal);
                epCRemote = new IPEndPoint(IPAddress.Parse(Client2IPBox.Text), Convert.ToInt32(CPortBox2.Text));
                epRemote = new IPEndPoint(IPAddress.Parse(Client2IPBox.Text), Convert.ToInt32(Client2PortBox.Text));
                sck.Connect(epRemote);
                sck1.Connect(epCRemote);
                byte[] buffer1 = new byte[64];
                sck1.BeginReceiveFrom(buffer1, 0, buffer1.Length, SocketFlags.None, ref epCRemote, new AsyncCallback(ChessCallBack), buffer1);
                byte[] buffer = new byte[4096];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                ConnectButton.Text = "Connected";
                ConnectButton.Enabled = false;
                SendButton.Enabled = true;
                WhiteButton.Enabled = true;
                BlackButton.Enabled = true;
               // SendBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] msg = new byte[4096];
                msg = enc.GetBytes(SendBox.Text);

                sck.Send(msg);
                if(SendBox.Text!="")
                listMessage.Items.Add("Me:"+ SendBox.Text);
                SendBox.Clear();

            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.ToString());
            }
        }

        private void WhiteButton_Click(object sender, EventArgs e)
        {
            player = new TextChessGame.Player(true);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var item = new Button();
                    field[i, j] = item;
                    item.Text = player.CB.arr[i, j].ToString();
                    item.Location = new Point(35 * i, 35 * j);
                    item.Size = new Size(35, 35);
                    if ((i + j) % 2 == 1)
                    {
                        item.BackColor = Color.Black;
                        item.ForeColor = Color.White;
                    }
                    item.Click += Item_Click;
                    pField.Controls.Add(item);
                }
            }
            BlackButton.Enabled = false;
            WhiteButton.Enabled = false;
        }

        private void BlackButton_Click(object sender, EventArgs e)
        {
            player = new TextChessGame.Player(false);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var item = new Button();
                    field[i, j] = item;
                    item.Text = player.CB.arr[i, j].ToString();
                    item.Location = new Point(35 * i, 35 * j);
                    item.Size = new Size(35, 35);
                    if ((i + j) % 2 == 0)
                    {
                        item.BackColor = Color.Black;
                        item.ForeColor = Color.White;
                    }
                    item.Click += Item_Click;
                    pField.Controls.Add(item);
                }
            }
            BlackButton.Enabled = false;
            WhiteButton.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
