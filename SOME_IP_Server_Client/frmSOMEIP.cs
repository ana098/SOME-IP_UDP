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

namespace SOME_IP_Server_Client
{
    public partial class Client_Form : Form
    {
        SomeIPMessage Message; 

        SomeIPClient Client;
        ConnectDataInput Connect_Form = new ConnectDataInput();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public Client_Form()
        {
            InitializeComponent();
        }
        private byte[] prepareImageMessage(Image image)  //ili Bitmap?
        {
            ImageConverter imageConverter = new ImageConverter();
            byte[] temp = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
            return Message.Payload = temp;
        }

        private void Btn_LoadData_Click(object sender, EventArgs e)
        {
            Message = new SomeIPMessage(Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.PICTURE), 0xABAB5555, Convert.ToByte(SomeIPMessage.SOMEIP_MessageType.REQUEST), Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK));
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp"; //ovime ograničavam da bude slika izabrana pa provjera i ne treba

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;

                    if (ImageExtensions.Contains(Path.GetExtension(openFile.FileName).ToUpperInvariant()))
                    {
                        pictureBox1.Image = new Bitmap(openFile.FileName);
                        prepareImageMessage(pictureBox1.Image);
                }
                    else
                    {
                        MessageBox.Show("The selected data is not an image!");
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
            checkSendMessage();
            Client.Send(Message.FullMessagePayload);//1614//1634
            Log.MessageSent("SENDING...");
            pictureBox1.Image = null;
            WriteLog();
        }

        public void checkReceiveMessage(byte[] udpPayload)
        {
            SomeIPMessage temp = new SomeIPMessage(udpPayload);
            Log.MessageSent("RECEIVING...");

            if (temp.MessageID == Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.PICTURE))
            {
                ImageConverter converter = new ImageConverter();
                pictureBox1.Image = (Image)converter.ConvertFrom(temp.Payload);
                Log.MessageSent("PICTURE");
                //Message = temp;
                
                pictureBox1.Refresh(); 
            }
            else if(temp.MessageID == Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.TEXT))
            {
                //Message = temp;
                Log.MessageSent("TEXT");
                textBox1.Text = System.Text.Encoding.Default.GetString(temp.Payload);
            }
            WriteLog();
        }

        public void WriteLog()
        {
            tbLog.AppendText(Log.Log_Txt());
            tbLog.ScrollToCaret();
        }

        private void checkSendMessage()
        {
            if(pictureBox1.Image == null)
            {
                Message = new SomeIPMessage(Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.TEXT), 0xABAB5555, Convert.ToByte(SomeIPMessage.SOMEIP_MessageType.REQUEST), Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK));
                byte[] temp = Encoding.ASCII.GetBytes(textBox1.Text);
                Message.Payload = temp;
            }
        }

    }
}
