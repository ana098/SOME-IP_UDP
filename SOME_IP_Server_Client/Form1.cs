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
        byte[] polje = Encoding.ASCII.GetBytes("Tekst za test");
        
        public Client_Form()
        {
            InitializeComponent();
        }

        private void Client_Form_Load(object sender, EventArgs e)
        {
            SomeIPMessage message = new SomeIPMessage(polje);

            //mesage.MessageID = 4027558570;
            
            
        }

    }
}
