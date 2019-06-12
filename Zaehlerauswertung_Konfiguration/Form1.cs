using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Zaehlerauswertung_Konfiguration
{
    public partial class ZaehlerkopfKonfigurator : Form
    {

        //globale Variablen:
        bool initSuccf = false;
        bool passwortSent = false;
        bool checkPasswort = false;
        bool mqttPasswortSent = false;
        bool userDataCheck = false;
        bool mqttApiKeySent = false;
        bool tsChnlIDSent = false;
        bool tsSSIDSent = false;
        bool comInit = false;

        bool stateWLANPSWD = false;
        bool stateMQTTPass = false;
        bool stateMQTTAPIK = false;


        String checkData;
        String pswd;
        String userSerialData;

        List<string> receivedDataESP = new List<string>();





        public ZaehlerkopfKonfigurator()
        {
            InitializeComponent();
        }

        private void digitalerStromzählerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ZaehlerkopfKonfigurator_Load(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                toolStripComboBoxCOMPort.Items.Add(s);

            }
            if (toolStripComboBoxCOMPort.Items.Count == 0)
            {
                MessageBox.Show("Bitte COM-Port wählen.");

            }
            else
            {
                toolStripComboBoxCOMPort.SelectedIndex = 0;
                if (!ESP8266Serial.IsOpen)
                {
                    if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                    {
                        MessageBox.Show("Bitte COM-Port auswählen!");
                    }
                    else
                    {
                        ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                        ESP8266Serial.BaudRate = 9600;
                        ESP8266Serial.Open();

                    }
                }

            }
            panelSerial.BringToFront();
            panelSerial.Show();
            panelThingSpeak.SendToBack();
            //panelThingSpeak.Hide();
            panelWLANconfig.SendToBack();
            //panelWLANconfig.Hide();
        }

        private void cOMPortsAktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                toolStripComboBoxCOMPort.Items.Remove(s);
                toolStripComboBoxCOMPort.Items.Add(s);

            }
        }

        private void btnInitCom_Click(object sender, EventArgs e)
        {
            string COMPort = toolStripComboBoxCOMPort.Text;
            lblCOMPort.Text = COMPort;
            lblSerialDat.Text = "";
            userSerialData = "comInit#";
            comInit = true;
            
            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }

            if (ESP8266Serial.IsOpen)
            {
               
                String init = "comInit#";
                ESP8266Serial.Write(init);
                
               
            }


        }

        private void ESP8266Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ESP8266Serial.DataReceived += ESP8266Serial_DataReceived1;
        }

        private void ESP8266Serial_DataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
            
            //throw new NotImplementedException();
            string data = ESP8266Serial.ReadTo("\x03");//Read until the EOT code
            string[] dataArray = data.Split(new string[] { "\x02", ";" }, StringSplitOptions.RemoveEmptyEntries); //, "$" 

            foreach (string dataItem in dataArray.ToList())      
            {
                checkData = dataItem;
                //receivedDataESP.Add(dataItem);

            }

            string checkDataSSID = dataArray[0];
            //MessageBox.Show(dataArray[0]);
            if (checkDataSSID == "WLSEARCH")
            {
                cmbboxWLANSSID.Items.Clear();
                //MessageBox.Show("combo box ssids eintragen");
                foreach (string dataItem in dataArray.ToList())
                {
                    cmbboxWLANSSID.Items.Add(dataItem);
                }
                cmbboxWLANSSID.Items.RemoveAt(0);
                //MessageBox.Show("WLAN Suche erfolgreich");
                
            }



            if (checkData == "#PCMode#")
            {
                if (!ESP8266Serial.IsOpen)
                {
                    if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                    {
                        MessageBox.Show("Bitte COM-Port auswählen!");
                    }
                    else
                    {
                        ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                        ESP8266Serial.BaudRate = 9600;
                        ESP8266Serial.Open();

                    }
                }
                else //(ESP8266Serial.IsOpen)
                {
                    lblSerialDat.Text = "Desktop Modus aktiv";
                    ESP8266Serial.Write("#PCMode#");


                }
            }
           
            if ((checkData == userSerialData))
            {
                //userDataCheck = true;
                if (passwortSent)
                {
                    btnWLANPSWD.BackColor = Color.LightGreen;
                    passwortSent = false;
                }
                if (mqttPasswortSent)
                {
                    btnMQTTPass.BackColor = Color.LightGreen;
                    mqttPasswortSent = false;
                }
                if (mqttApiKeySent)
                {
                    btnMQTTAPIK.BackColor = Color.LightGreen;
                    mqttApiKeySent = false;
                }
                if (tsChnlIDSent)
                {
                    btnChnlID.BackColor = Color.LightGreen;
                    tsChnlIDSent = false;
                }
                if (comInit)
                {
                    lblSerialDat.Text = "Verbindung zu Zählerkopf hergestellt.";
                }
                if (tsSSIDSent)
                {
                    btnWLANssid.BackColor = Color.LightGreen;
                    tsSSIDSent = false;
                }
                
            }
            if ((checkData != userSerialData))
            {
                if ((checkData != "#PCMode#"))
                {

                    userDataCheck = false;
                    if (checkDataSSID == "WLSEARCH")
                    {
                        MessageBox.Show("WLAN Suche erfolgreich");
                        lblSerialDat.Text = "WLAN Suche erfolgreich";
                        checkDataSSID = "";
                    }
                    else
                    {
                        MessageBox.Show("Bitte die Reset Taste betätigen und Passwort erneut eingeben");
                    }
                    
                }
                else
                {
                    MessageBox.Show("PC Verbindung aktiv!");
                }
            }




        }

        private void btnWLANPSWD_Click(object sender, EventArgs e)
        {

            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }
            else //(ESP8266Serial.IsOpen)
            {

                userSerialData = "WLANPSWD";
                userSerialData += txtboxWLANPSWD.Text;
                ESP8266Serial.Write(userSerialData);
                passwortSent = true;
                

            }

        }

        

        private void btnMQTTPass_Click(object sender, EventArgs e)
        {
            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }
            else //(ESP8266Serial.IsOpen)
            {

                userSerialData = "mqttPass";
                userSerialData += txtboxMQTTPSWD.Text;
                ESP8266Serial.Write(userSerialData);
                mqttPasswortSent = true;
                

            }
        }

        private void btnMQTTAPIK_Click(object sender, EventArgs e)
        {
            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }
            else //(ESP8266Serial.IsOpen)
            {

                userSerialData = "mqttApik";
                userSerialData += txtboxMQTTAPIK.Text;
                ESP8266Serial.Write(userSerialData);
                mqttApiKeySent = true;


            }
        }

        private void btnChnlID_Click(object sender, EventArgs e)
        {
            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }
            else //(ESP8266Serial.IsOpen)
            {

                userSerialData = "chnlID##";
                userSerialData += txtboxChnlID.Text;
                ESP8266Serial.Write(userSerialData);
                tsChnlIDSent = true;


            }
        }
        private void txtboxWLANPSWD_TextChanged(object sender, EventArgs e)
        {
            btnWLANPSWD.BackColor = Color.LightGray;
        }

        private void txtboxMQTTPSWD_TextChanged(object sender, EventArgs e)
        {
            btnMQTTPass.BackColor = Color.LightGray;
        }

        private void txtboxMQTTAPIK_TextChanged(object sender, EventArgs e)
        {
            btnMQTTAPIK.BackColor = Color.LightGray;
        }

        private void txtboxChnlID_TextChanged(object sender, EventArgs e)
        {
            btnChnlID.BackColor = Color.LightGray;
        }

        private void hilfeAufrufenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hilfe_Form hilfe_Form = new Hilfe_Form();
            hilfe_Form.Show();
            
           
            
        }

        private void btnWLANscan_Click(object sender, EventArgs e)
        {
            lblSerialDat.Text = "Suche WLAN Netzwerk";
            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }
            else //(ESP8266Serial.IsOpen)
            {

                userSerialData = "WLSEARCH";
                userSerialData += txtboxChnlID.Text;
                ESP8266Serial.Write(userSerialData);


            }

        }

        private void btnWLANssid_Click(object sender, EventArgs e)
        {
            if (!ESP8266Serial.IsOpen)
            {
                if (string.IsNullOrEmpty(toolStripComboBoxCOMPort.Text))
                {
                    MessageBox.Show("Bitte COM-Port auswählen!");
                }
                else
                {
                    ESP8266Serial.PortName = Convert.ToString(toolStripComboBoxCOMPort.SelectedItem);
                    ESP8266Serial.BaudRate = 9600;
                    ESP8266Serial.Open();

                }
            }
            else //(ESP8266Serial.IsOpen)
            {

                userSerialData = "WLANSSID";
                if (cmbboxWLANSSID.Text == "")
                {
                    MessageBox.Show("bitte Netzwerk aus Liste auswählen");
                }
                else
                {
                    userSerialData += cmbboxWLANSSID.Text;
                    ESP8266Serial.Write(userSerialData);
                    tsSSIDSent = true;
                }
                


            }

        }

        private void btnWLANPanel_Click(object sender, EventArgs e)
        {
            panelWLANconfig.Show();
            panelThingSpeak.SendToBack();
            panelSerial.SendToBack();
            panelWLANconfig.BringToFront();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSerialPanel_Click(object sender, EventArgs e)
        {
            panelSerial.Show();
            panelThingSpeak.SendToBack();
            panelWLANconfig.SendToBack();
            panelSerial.BringToFront();
        }

        private void btnThingSpeakPanel_Click(object sender, EventArgs e)
        {
            panelThingSpeak.Show();
            panelThingSpeak.BringToFront();
            panelSerial.Hide();
            panelWLANconfig.Hide();
            panelSerial.SendToBack();
            panelWLANconfig.SendToBack();
            
        }

        private void cmbboxWLANSSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWLANssid.BackColor = Color.LightGray;
        }
    }
}
