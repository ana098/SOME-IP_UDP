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
        SomeIPMessage imgMessage = new SomeIPMessage(Convert.ToUInt32( SomeIPMessage.SOMEIP_MessageID.PICTURE), 0xAAAA, Convert.ToByte( SomeIPMessage.SOMEIP_MessageType.REQUEST), Convert.ToByte(SomeIPMessage.SOMEIP_ReturnCode.E_OK));
        SomeIPClient RaisingEvent = new SomeIPClient();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public Client_Form()
        {
            InitializeComponent();
            TaskHandler();
            RaisingEvent.ReceiveResultsEvent += checkReceiveMessage;
        }

        private byte[] prepareImageMessage(Image image)  //ili Bitmap?
        {
            ImageConverter imageConverter = new ImageConverter();
            byte[] temp = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
            return imgMessage.Payload = temp;
        }

        private void Btn_LoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp"; //ovime ograničavam da bude slika izabrana pa provjera i ne treba

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;

                    if (ImageExtensions.Contains(Path.GetExtension(openFile.FileName).ToUpperInvariant()))
                    {
                        pictureBox1.Image = new Bitmap(openFile.FileName);
                    }
                    else
                    {
                        MessageBox.Show("The selected data is not an image!");
                    }
                
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            RaisingEvent.Connect();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            RaisingEvent.Send(prepareImageMessage(pictureBox1.Image));
            //RaisingEvent.CloseConnection();

        }

        public void checkReceiveMessage(byte[] udpPayload)
        {
            SomeIPMessage temp = new SomeIPMessage(udpPayload);

            if (temp.MessageID == Convert.ToUInt32(SomeIPMessage.SOMEIP_MessageID.PICTURE))
            {
                imgMessage = temp;
                pictureBox1.Refresh(); //da ne moram praviti metodu ShowMessage
            }

            else
            {
                //text je ili vec nesto drugo
            }
        }

        private void Client_Form_Load(object sender, EventArgs e)
        {
            //RaisingEvent.Close();
        }

        private async void TaskHandler()
        {
            await RaisingEvent.Receive();
        }

    }
}
