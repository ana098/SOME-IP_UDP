using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOME_IP_Server_Client
{
    public partial class Client_Form : Form
    {
        byte[] test = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xFF, 0xFF, 0xFF, 0xFA, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0xAA, 0xBB, 0xCC, 0xDD, 0x01, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0xAA, 0xBB, 0xCC, 0xDD, 0x01, 0x11, 0x22, 0x33 };

        
        public Client_Form()
        {
            InitializeComponent();
            SomeIPMessage message = new SomeIPMessage();
            SomeIPServiceDiscoveryMessage.ServiceDiscoveryEntry DS_message = new SomeIPServiceDiscoveryMessage.ServiceDiscoveryEntry();
            message.SomeIPHeader = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0xAA, 0xBB, 0xCC, 0xDD };
            DS_message.Entries_Array = new byte[] { 0xFF, 0xFF, 0xFF, 0xFA, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0xAA, 0xBB, 0xCC, 0xDD };
            SomeIPServiceDiscoveryMessage sd = new SomeIPServiceDiscoveryMessage(test);
           
        }

        private void Client_Form_Load(object sender, EventArgs e)
        {

            //mesage.MessageID = 4027558570;
            
            
        }

    }
}
