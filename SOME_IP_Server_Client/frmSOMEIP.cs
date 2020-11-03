using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace SOME_IP_Server_Client
{
    public partial class Client_Form : Form
    {
        SomeIPMessage Message;
        //SoundPlayer Player = new SoundPlayer();
        SomeIPClient Client;
        ConnectDataInput Connect_Form = new ConnectDataInput();
        OpenFileDialog openFile = new OpenFileDialog();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public Client_Form()
        {
            InitializeComponent();
        }
        private byte[] prepareImageMessage(Image image) 
        {
            ImageConverter imageConverter = new ImageConverter();
            byte[] temp = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
            return Message.Payload = temp;
        }

        private byte[] prepareSoundMessage()
        {
            byte[] temp = File.ReadAllBytes(openFile.FileName);
            return Message.Payload = temp;
        }

        private void Btn_LoadData_Click(object sender, EventArgs e)
        {

            if (cb_Choice.SelectedItem == "Picture")
            {
                openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            }
            else if(cb_Choice.SelectedItem == "Sound")
            {
                openFile.Filter = "Audio (*.cs,*.acc,*.wma, *.wav)|*.cs;*.mp3;*.wma, *.wav|All Files (*.*)|*.*";
            }

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                if (cb_Choice.SelectedItem == "Picture")
                {
                    pictureBox1.Image = new Bitmap(openFile.FileName);
                }

                else if(cb_Choice.SelectedItem == "Sound")
                {
                    PlayBtn.Enabled = true;
                }  
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
                Connect_Form.ShowDialog();

                Client = new SomeIPClient(Connect_Form.Port, Connect_Form.EndPointPort);
                Log.MessageSent("Port: " + Connect_Form.Port.ToString()+"  End Point: " + Connect_Form.EndPointPort.ToString());

                Client.ReceiveResultsEvent += checkReceiveMessage;
                Client.Receive();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            CheckSendMessage();
            Client.Send(Message.FullMessagePayload);//1614//1634
            Log.MessageSent("SENDING...");
            Log.MessageSent("MessageID:  " + Message.MessageID.ToString());
            Log.MessageSent("RequestID:  " + Message.RequestID.ToString());
            Log.MessageSent("Lenght:  " + Message.GetLength.ToString());

            pictureBox1.Image = null;
            WriteLog();
        }

        public void checkReceiveMessage(byte[] udpPayload)
        {
            SomeIPMessage temp = new SomeIPMessage(udpPayload);
            Log.MessageSent("RECEIVING...");
            Log.MessageSent("MessageID:  " + temp.MessageID.ToString());
            Log.MessageSent("RequestID:  " + temp.RequestID.ToString());
            Log.MessageSent("Lenght:  " + temp.GetLength.ToString());

            if (temp.MessageID == Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.PICTURE))
            {
                ImageConverter converter = new ImageConverter();
                pictureBox1.Image = (Image)converter.ConvertFrom(temp.Payload);
                Log.MessageSent("---PICTURE---");
                PlayBtn.Enabled = false;
                textBox1.Text = null;
                
                pictureBox1.Refresh(); 
            }
            else if(temp.MessageID == Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.TEXT))
            {
                Log.MessageSent("---TEXT---");
                textBox1.Text = System.Text.Encoding.Default.GetString(temp.Payload);
                PlayBtn.Enabled = false;
                pictureBox1.Image = null;
            }

            else if(temp.MessageID == Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.SOUND))
            {
                Log.MessageSent("---SOUND---");
                File.WriteAllBytes(@"C:\Temp\WriteSound\Temp.wav", temp.Payload);
                textBox1.Text = @"C:\Temp\WriteSound\Temp.wav";
                PlayBtn.Enabled = true;
                pictureBox1.Image = null;
            }
            else
            {
                SomeIPServiceDiscoveryMessage SDtemp = new SomeIPServiceDiscoveryMessage(udpPayload);
                uint a = SDtemp.GetLength - 3; //pomaknuti računanje payloada ili oduzeti sve sa options da znamo koliko ima. moze i tako pa pomaknuti
                //kod uzimanja entrya
            }
            WriteLog();
        }

        public void WriteLog()
        {
            tbLog.AppendText(Log.Log_Txt());
            tbLog.ScrollToCaret();
        }
        private void CheckSendMessage()
        {
            if(cb_Choice.Text=="Text")
            {
                Log.MessageSent("---TEXT---");
                Message = new SomeIPMessage(Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.TEXT), 0xABAB5555, 
                    Convert.ToByte(SomeIPMessage.SOMEIP_MessageType.REQUEST), Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK));
                byte[] temp = Encoding.ASCII.GetBytes(textBox1.Text);
                Message.Payload = temp;
                PlayBtn.Enabled = false;
            }
            else if(cb_Choice.Text=="Picture")
            {
                Log.MessageSent("---PICTURE---");
                Message = new SomeIPMessage(Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.PICTURE), 0xABAB5555, 
                    Convert.ToByte(SomeIPMessage.SOMEIP_MessageType.REQUEST), Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK));
                prepareImageMessage(pictureBox1.Image);
                PlayBtn.Enabled = false;
            }
            else if(cb_Choice.Text == "Sound")
            {
                pictureBox1.Image = null;
                Log.MessageSent("---SOUND---");
                Message = new SomeIPMessage(Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.SOUND), 0xABAB5555, 
                    Convert.ToByte(SomeIPMessage.SOMEIP_MessageType.REQUEST), Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK));
                prepareSoundMessage();
            }
            else
            {
                MessageBox.Show("You have not selected what to send!!");
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            SoundPlayer Player = new SoundPlayer(textBox1.Text);
            Player.Play();
        }

        private void btn_Publish_Click(object sender, EventArgs e)
        {
            SomeIPServiceDiscoveryMessage ServiceDiscovery;

            SomeIPServiceDiscoveryMessage.ServiceDiscoveryEntry Entry = new SomeIPServiceDiscoveryMessage.ServiceDiscoveryEntry();
            byte[] OptionsArray = new byte[16] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF };
            byte[] ReservedHeader = new byte[3] { 0x00, 0x00, 0x00 }; //ostavlja se u 0
            byte[] EntryArray = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xAA, 0xAA, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x14, 0xFF, 0xFF, 0xFF, 0xFF };
            
                //  , 0x00, 0x11, 0x00, 0x11 };
           //Convert.ToByte(0x00110011) };
           //0x14 je TTL u hex = dekadski 20 sec

            ServiceDiscovery = new SomeIPServiceDiscoveryMessage(0xFFFF8100, 0, Convert.ToByte(SomeIPMessage.SOMEIP_MessageType.NOTIFICATION),
                Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK), 1, ReservedHeader, EntryArray, OptionsArray);
            ServiceDiscovery.Payload = ReservedHeader.Concat(EntryArray).Concat(OptionsArray).ToArray();

            Client.Send(ServiceDiscovery.FullMessagePayload);

        }
    }
}
