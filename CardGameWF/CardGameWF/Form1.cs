using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PacketData;
using PacketProperties;
using Cards;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CardGameWF
{
    public partial class Form1 : Form
    {
        private int playerID;
        private static Socket routeSocket;
        private IPEndPoint iPEndPoint;

        private ListCard _listCard;
        private ListCard PlayerCards { get { return _listCard; } set { _listCard = value; } }

        private ListCard _OpponentCards;
        public ListCard OpponentCards { get { return _OpponentCards; } set { _OpponentCards = value; } }

        private ListCard _selectedCards;
        public ListCard SelectedCards { get { return _selectedCards; } set { _selectedCards = value; } }

        private ListCard _historyCards;
        public ListCard HistoryCards { get { return _historyCards; } set { _historyCards = value; } }

        private GameLaw gameLaw = new GameLaw();
        private bool isMyTurn = false;
        private bool isFirstTurn = false;
        private bool isFreeTurn = false;
        private bool isHostPlayer = false;
        private int ranking = -1;
        //public event PropertyChangedEventHandler PropertyChanged;

        public void Connect()
        {
            routeSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
            try
            {
                routeSocket.Connect(iPEndPoint);
                Console.WriteLine("Connect successful to: " + routeSocket.RemoteEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                //Connect to sub-server
            }

        }
        public void ConnectToSubServer() { }
        public void Send(Packet packet)
        {
            routeSocket.Send(packet.GetBytes());
        }
        public void ReceiveFromRoute()
        {
            byte[] bytesReceive;
            int readBytes = 0;
            while (routeSocket.Connected)
            {
                try
                {
                    bytesReceive = new byte[routeSocket.Available];
                    readBytes = routeSocket.Receive(bytesReceive, 0, bytesReceive.Length, SocketFlags.None);
                    Console.WriteLine("Packet length: " + readBytes);

                    if (readBytes > 0)
                    {
                        Packet receivePacket = new Packet(bytesReceive);
                        Thread thread = new Thread(arg => RespondFromRoute(receivePacket));
                        thread.Start();
                    }
                }
                catch (SocketException ex)
                {
                    ConnectToSubServer();
                    Console.WriteLine("Client Disconnected");
                }
            }
        }


        public void RespondFromRoute(Packet packet)
        {
            Console.WriteLine(packet.ActionType);
            switch (packet.ActionType)
            {
                case ActionType.SET_TURN_FLAG:
                    if (HistoryCards != null && HistoryCards.Equals(OpponentCards))
                    {
                        isFreeTurn = true;
                        lbStatus.Text = "Free turn";
                    }
                    else
                    {
                        btnNext.Enabled = true;
                        isMyTurn = true;
                        lbStatus.Text = "Your turn";
                    }
                    break;

                case ActionType.SEND_SELECTED_CARDS_FOR_OTHERS:
                    try
                    {
                        OpponentCards = new ListCard(Encoding.UTF8.GetString(packet.Data));
                        UpdatePanel(panelOpponentCards, OpponentCards);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                    break;

                case ActionType.SET_FIRST_TURN_FLAG:
                    isFirstTurn = true;
                    lbStatus.Text = "Your turn";
                    break;

                case ActionType.SEND_DEAL_LISTCARDS:

                    try
                    {
                        PlayerCards = new ListCard(Encoding.UTF8.GetString(packet.Data));
                        UpdatePanel(panelPlayerCards, PlayerCards);
                        if (gameLaw.CheckWinTotally(PlayerCards))
                        {
                            Send(new Packet(Destination.ROUTE, ActionType.SET_WIN_TOTALLY_FLAG));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                    break;

                case ActionType.SET_ID_FOR_SOCKET:
                    playerID = int.Parse(Encoding.UTF8.GetString(packet.Data));
                    break;

                case ActionType.START_NEW_GAME_REPLY:
                    MessageBox.Show(Encoding.UTF8.GetString(packet.Data));
                    btnReady.Enabled = true;
                    break;

                case ActionType.SET_WIN_TOTALLY_FLAG:
                    Console.WriteLine(packet.ToString());
                    break;

                case ActionType.I_AM_WINNER:
                    ranking = int.Parse(Encoding.UTF8.GetString(packet.Data));
                    Console.WriteLine("Ranking: " + ranking);
                    lbStatus.Text = ranking == 1 ? "Winner" : ranking.ToString();
                    break;

                case ActionType.SET_HOST_PLAYER:
                    btnReady.Text = "New game";
                    isHostPlayer = true;
                    break;

                case ActionType.END_GAME:
                    PlayerCards = new ListCard();
                    HistoryCards = new ListCard();
                    OpponentCards = new ListCard();
                    UpdatePanel(panelOpponentCards, OpponentCards);
                    UpdatePanel(panelPlayerCards, PlayerCards);
                    btnReady.Enabled = true;
                    btnNext.Enabled = false;
                    btnPlay.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        public void UpdatePanel(Panel panel, ListCard listCard)
        {
            BeginInvoke((Action)(() =>
            {
                try
                {
                    panel.Controls.Clear();
                    if (listCard != null)
                    {
                        for (int i = 0; i < listCard.CountCards(); i++)
                        {
                            Card card = listCard.GetCardAt(i);
                            string imageKey = card.ImageSource;
                            PictureBox picture = new PictureBox();
                            picture.SizeMode = PictureBoxSizeMode.StretchImage;
                            Image image = CardList.Images[CardList.Images.IndexOfKey(imageKey)];
                            picture.Image = image;
                            picture.Tag = card;
                            picture.Size = new Size(72, 90);
                            picture.Left = 50 * i;
                            picture.Top = picture.Height - 50;
                            picture.MouseDown += new MouseEventHandler(Card_MouseClick);
                            panel.Controls.Add(picture);
                        }
                    }
                    panel.Refresh();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }));
        }
        public Form1()
        {
            InitializeComponent();
            PlayerCards = new ListCard();
            SelectedCards = new ListCard();
            HistoryCards = new ListCard();
            OpponentCards = new ListCard();
            lbStatus.Text = string.Empty;
            btnReady.Enabled = false;
        }
        private void btnReady_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isHostPlayer)
                {
                    Send(new Packet(Destination.ROUTE, ActionType.IS_READY));
                }
                else
                {
                    Send(new Packet(Destination.ROUTE, ActionType.START_NEW_GAME_REQUEST));
                }

                btnReady.Enabled = false;
                lbStatus.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                HistoryCards = SelectedCards;

                Send(new Packet(Destination.ROUTE, ActionType.SEND_CARDS_IN_MY_TURN, Encoding.UTF8.GetBytes(SelectedCards.ToString()), playerID));



                UpdatePanel(panelPlayerCards, PlayerCards);
                UpdatePanel(panelOpponentCards, SelectedCards);
                if (PlayerCards.CountCards() == 0)
                {
                    Send(new Packet(Destination.ROUTE, ActionType.I_AM_WINNER));
                }
                SelectedCards = new ListCard();
                btnPlay.Enabled = false;
                btnNext.Enabled = false;

                isMyTurn = false;
                isFirstTurn = false;
                isFreeTurn = false;
                lbStatus.Text = "";
                UpdatePanel(panelPlayerCards, PlayerCards);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Send(new Packet(Destination.ROUTE, ActionType.SEND_CARDS_IN_MY_TURN, null, playerID));
            btnPlay.Enabled = false;
            btnNext.Enabled = false;
            if (SelectedCards.CountCards() != 0)
            {
                for (int i = 0; i < SelectedCards.CountCards(); i++)
                {
                    PlayerCards.AddCardToList(SelectedCards.GetCardAt(i));
                }
                PlayerCards.Sort();
            }
            SelectedCards = new ListCard();
            isMyTurn = false;
            lbStatus.Text = "";
            UpdatePanel(panelPlayerCards, PlayerCards);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
                Thread receiveFromRouteThread = new Thread(ReceiveFromRoute);
                receiveFromRouteThread.Start();
                Send(new Packet(Destination.ROUTE, ActionType.FIRST_CONNECTING));

                btnConnect.Enabled = false;
                btnReady.Enabled = true;
            }
            catch (Exception ex)
            {
                //Connect to subserver
                Console.WriteLine(ex.StackTrace);
            }
        }
        private void CheckRulesByPriority()
        {
            if (isFirstTurn)
            {
                if (SelectedCards.CountCards() != 0)
                {
                    if (SelectedCards.GetCardAt(0).CompareTo(PlayerCards.GetCardAt(0)) == -1 && gameLaw.ValidateCards(SelectedCards))
                    {
                        btnPlay.Enabled = true;
                    }
                    else
                    {
                        btnPlay.Enabled = false;
                    }
                }
            }

            if (isFreeTurn)
            {

                if (gameLaw.ValidateCards(SelectedCards))
                {
                    btnPlay.Enabled = true;
                }
                else
                {
                    btnPlay.Enabled = false;
                }
            }

            if (isMyTurn)
            {
                if (gameLaw.CheckRules(OpponentCards, SelectedCards))
                {
                    btnPlay.Enabled = true;
                }
                else
                {
                    btnPlay.Enabled = false;
                }
            }
        }
        private void Card_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox cardImage = (PictureBox)sender;
            Card selectedCard = (Card)cardImage.Tag;
            selectedCard.IsSelected = !selectedCard.IsSelected;
            int cardIndex;
            if (selectedCard.IsSelected)
            {
                SelectedCards.AddCardToList(selectedCard);
                cardIndex = PlayerCards.Contains(selectedCard);
                if (cardIndex != -1)
                {
                    PlayerCards.RemovedCardAt(cardIndex);
                }
                cardImage.Location = new Point(cardImage.Location.X, (cardImage.Location.Y - 20));
            }
            else
            {
                cardIndex = SelectedCards.Contains(selectedCard);
                if (cardIndex != -1)
                {
                    SelectedCards.RemovedCardAt(cardIndex);
                    PlayerCards.AddCardToList(selectedCard);
                }
                cardImage.Location = new Point(cardImage.Location.X, (cardImage.Location.Y + 20));
            }
            PlayerCards.Sort();
            SelectedCards.Sort();
            CheckRulesByPriority();
        }
    }
}
