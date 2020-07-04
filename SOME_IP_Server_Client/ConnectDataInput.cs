using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOME_IP_Server_Client
{
    public partial class ConnectDataInput : Form
    {
        int port, endPointPort;
        SomeIPClient Client;
        public ConnectDataInput()
        {
            InitializeComponent();
        }

        public int Port
        {
            get { return port; }
            set 
            {
                if (string.IsNullOrWhiteSpace(portTxtBox.Text))
                {
                    port = 1200;
                }
                else
                {
                    port = value;
                }
            }
        }

        public int EndPointPort
        {
            get { return endPointPort; }
            set
            {
                endPointPort = value;
            }
        }

        private void ConnectDataInput_Load(object sender, EventArgs e)
        {

        }

        private void InputDataBtn_Click(object sender, EventArgs e)
        {
            Port = Convert.ToInt32(portTxtBox.Text);
            EndPointPort = Convert.ToInt32(EPtxtBox.Text);
            this.Close();
        }

    }
}
