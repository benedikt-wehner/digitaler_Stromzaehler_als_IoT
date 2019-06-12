namespace Zaehlerauswertung_Konfiguration
{
    partial class ZaehlerkopfKonfigurator
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZaehlerkopfKonfigurator));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPortAuswählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxCOMPort = new System.Windows.Forms.ToolStripComboBox();
            this.cOMPortsAktualisierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeAufrufenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ESP8266Serial = new System.IO.Ports.SerialPort(this.components);
            this.btnInitCom = new System.Windows.Forms.Button();
            this.lblCOMPort = new System.Windows.Forms.Label();
            this.lblSerialDat = new System.Windows.Forms.Label();
            this.txtboxWLANPSWD = new System.Windows.Forms.TextBox();
            this.instructionlblWLAN = new System.Windows.Forms.Label();
            this.btnWLANPSWD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMQTTPass = new System.Windows.Forms.Button();
            this.instructionlblMQTTPass = new System.Windows.Forms.Label();
            this.txtboxMQTTPSWD = new System.Windows.Forms.TextBox();
            this.btnMQTTAPIK = new System.Windows.Forms.Button();
            this.instructionlblMQTTAPI = new System.Windows.Forms.Label();
            this.txtboxMQTTAPIK = new System.Windows.Forms.TextBox();
            this.btnChnlID = new System.Windows.Forms.Button();
            this.instructionlblchnlID = new System.Windows.Forms.Label();
            this.txtboxChnlID = new System.Windows.Forms.TextBox();
            this.panelWLANconfig = new System.Windows.Forms.Panel();
            this.btnWLANssid = new System.Windows.Forms.Button();
            this.WLANNetzwerke = new System.Windows.Forms.Label();
            this.cmbboxWLANSSID = new System.Windows.Forms.ComboBox();
            this.btnWLANscan = new System.Windows.Forms.Button();
            this.lblUeberschriftWLAN = new System.Windows.Forms.Label();
            this.btnWLANPanel = new System.Windows.Forms.Button();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThingSpeakPanel = new System.Windows.Forms.Button();
            this.btnSerialPanel = new System.Windows.Forms.Button();
            this.panelThingSpeak = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelWLANconfig.SuspendLayout();
            this.panelSerial.SuspendLayout();
            this.panelThingSpeak.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOMPortAuswählenToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // cOMPortAuswählenToolStripMenuItem
            // 
            this.cOMPortAuswählenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxCOMPort,
            this.cOMPortsAktualisierenToolStripMenuItem});
            this.cOMPortAuswählenToolStripMenuItem.Name = "cOMPortAuswählenToolStripMenuItem";
            this.cOMPortAuswählenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cOMPortAuswählenToolStripMenuItem.Text = "COM-Port auswählen";
            // 
            // toolStripComboBoxCOMPort
            // 
            this.toolStripComboBoxCOMPort.Name = "toolStripComboBoxCOMPort";
            this.toolStripComboBoxCOMPort.Size = new System.Drawing.Size(121, 23);
            // 
            // cOMPortsAktualisierenToolStripMenuItem
            // 
            this.cOMPortsAktualisierenToolStripMenuItem.Name = "cOMPortsAktualisierenToolStripMenuItem";
            this.cOMPortsAktualisierenToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.cOMPortsAktualisierenToolStripMenuItem.Text = "COM-Ports aktualisieren";
            this.cOMPortsAktualisierenToolStripMenuItem.Click += new System.EventHandler(this.cOMPortsAktualisierenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeAufrufenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // hilfeAufrufenToolStripMenuItem
            // 
            this.hilfeAufrufenToolStripMenuItem.Name = "hilfeAufrufenToolStripMenuItem";
            this.hilfeAufrufenToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.hilfeAufrufenToolStripMenuItem.Text = "Hilfe aufrufen";
            this.hilfeAufrufenToolStripMenuItem.Click += new System.EventHandler(this.hilfeAufrufenToolStripMenuItem_Click);
            // 
            // ESP8266Serial
            // 
            this.ESP8266Serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ESP8266Serial_DataReceived);
            // 
            // btnInitCom
            // 
            this.btnInitCom.Location = new System.Drawing.Point(117, 130);
            this.btnInitCom.Name = "btnInitCom";
            this.btnInitCom.Size = new System.Drawing.Size(138, 58);
            this.btnInitCom.TabIndex = 2;
            this.btnInitCom.Text = "mit Zählerkopf verbinden";
            this.btnInitCom.UseVisualStyleBackColor = true;
            this.btnInitCom.Click += new System.EventHandler(this.btnInitCom_Click);
            // 
            // lblCOMPort
            // 
            this.lblCOMPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCOMPort.Location = new System.Drawing.Point(146, 221);
            this.lblCOMPort.Name = "lblCOMPort";
            this.lblCOMPort.Size = new System.Drawing.Size(67, 26);
            this.lblCOMPort.TabIndex = 3;
            this.lblCOMPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerialDat
            // 
            this.lblSerialDat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSerialDat.Location = new System.Drawing.Point(208, 17);
            this.lblSerialDat.Name = "lblSerialDat";
            this.lblSerialDat.Size = new System.Drawing.Size(268, 23);
            this.lblSerialDat.TabIndex = 4;
            this.lblSerialDat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtboxWLANPSWD
            // 
            this.txtboxWLANPSWD.Location = new System.Drawing.Point(35, 273);
            this.txtboxWLANPSWD.Name = "txtboxWLANPSWD";
            this.txtboxWLANPSWD.PasswordChar = '*';
            this.txtboxWLANPSWD.Size = new System.Drawing.Size(178, 20);
            this.txtboxWLANPSWD.TabIndex = 5;
            this.txtboxWLANPSWD.TextChanged += new System.EventHandler(this.txtboxWLANPSWD_TextChanged);
            // 
            // instructionlblWLAN
            // 
            this.instructionlblWLAN.AutoSize = true;
            this.instructionlblWLAN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.instructionlblWLAN.Location = new System.Drawing.Point(38, 254);
            this.instructionlblWLAN.Name = "instructionlblWLAN";
            this.instructionlblWLAN.Size = new System.Drawing.Size(135, 13);
            this.instructionlblWLAN.TabIndex = 6;
            this.instructionlblWLAN.Text = "WLAN Passwort eintragen:";
            // 
            // btnWLANPSWD
            // 
            this.btnWLANPSWD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWLANPSWD.Location = new System.Drawing.Point(219, 269);
            this.btnWLANPSWD.Name = "btnWLANPSWD";
            this.btnWLANPSWD.Size = new System.Drawing.Size(93, 27);
            this.btnWLANPSWD.TabIndex = 7;
            this.btnWLANPSWD.Text = "übertragen\r\n";
            this.btnWLANPSWD.UseVisualStyleBackColor = false;
            this.btnWLANPSWD.Click += new System.EventHandler(this.btnWLANPSWD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Status:";
            // 
            // btnMQTTPass
            // 
            this.btnMQTTPass.Location = new System.Drawing.Point(233, 136);
            this.btnMQTTPass.Name = "btnMQTTPass";
            this.btnMQTTPass.Size = new System.Drawing.Size(93, 27);
            this.btnMQTTPass.TabIndex = 11;
            this.btnMQTTPass.Text = "übertragen\r\n";
            this.btnMQTTPass.UseVisualStyleBackColor = true;
            this.btnMQTTPass.Click += new System.EventHandler(this.btnMQTTPass_Click);
            // 
            // instructionlblMQTTPass
            // 
            this.instructionlblMQTTPass.AutoSize = true;
            this.instructionlblMQTTPass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.instructionlblMQTTPass.Location = new System.Drawing.Point(52, 121);
            this.instructionlblMQTTPass.Name = "instructionlblMQTTPass";
            this.instructionlblMQTTPass.Size = new System.Drawing.Size(129, 13);
            this.instructionlblMQTTPass.TabIndex = 10;
            this.instructionlblMQTTPass.Text = "MQTT API Key eintragen:";
            // 
            // txtboxMQTTPSWD
            // 
            this.txtboxMQTTPSWD.Location = new System.Drawing.Point(49, 140);
            this.txtboxMQTTPSWD.Name = "txtboxMQTTPSWD";
            this.txtboxMQTTPSWD.Size = new System.Drawing.Size(178, 20);
            this.txtboxMQTTPSWD.TabIndex = 9;
            this.txtboxMQTTPSWD.TextChanged += new System.EventHandler(this.txtboxMQTTPSWD_TextChanged);
            // 
            // btnMQTTAPIK
            // 
            this.btnMQTTAPIK.Location = new System.Drawing.Point(233, 180);
            this.btnMQTTAPIK.Name = "btnMQTTAPIK";
            this.btnMQTTAPIK.Size = new System.Drawing.Size(93, 27);
            this.btnMQTTAPIK.TabIndex = 14;
            this.btnMQTTAPIK.Text = "übertragen\r\n";
            this.btnMQTTAPIK.UseVisualStyleBackColor = true;
            this.btnMQTTAPIK.Click += new System.EventHandler(this.btnMQTTAPIK_Click);
            // 
            // instructionlblMQTTAPI
            // 
            this.instructionlblMQTTAPI.AutoSize = true;
            this.instructionlblMQTTAPI.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.instructionlblMQTTAPI.Location = new System.Drawing.Point(52, 165);
            this.instructionlblMQTTAPI.Name = "instructionlblMQTTAPI";
            this.instructionlblMQTTAPI.Size = new System.Drawing.Size(157, 13);
            this.instructionlblMQTTAPI.TabIndex = 13;
            this.instructionlblMQTTAPI.Text = "MQTT API Write Key eintragen:";
            // 
            // txtboxMQTTAPIK
            // 
            this.txtboxMQTTAPIK.Location = new System.Drawing.Point(49, 184);
            this.txtboxMQTTAPIK.Name = "txtboxMQTTAPIK";
            this.txtboxMQTTAPIK.Size = new System.Drawing.Size(178, 20);
            this.txtboxMQTTAPIK.TabIndex = 12;
            this.txtboxMQTTAPIK.TextChanged += new System.EventHandler(this.txtboxMQTTAPIK_TextChanged);
            // 
            // btnChnlID
            // 
            this.btnChnlID.Location = new System.Drawing.Point(233, 229);
            this.btnChnlID.Name = "btnChnlID";
            this.btnChnlID.Size = new System.Drawing.Size(93, 27);
            this.btnChnlID.TabIndex = 17;
            this.btnChnlID.Text = "übertragen\r\n";
            this.btnChnlID.UseVisualStyleBackColor = true;
            this.btnChnlID.Click += new System.EventHandler(this.btnChnlID_Click);
            // 
            // instructionlblchnlID
            // 
            this.instructionlblchnlID.AutoSize = true;
            this.instructionlblchnlID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.instructionlblchnlID.Location = new System.Drawing.Point(52, 214);
            this.instructionlblchnlID.Name = "instructionlblchnlID";
            this.instructionlblchnlID.Size = new System.Drawing.Size(171, 13);
            this.instructionlblchnlID.TabIndex = 16;
            this.instructionlblchnlID.Text = "ThingSpeak Channel ID eintragen:";
            // 
            // txtboxChnlID
            // 
            this.txtboxChnlID.Location = new System.Drawing.Point(49, 233);
            this.txtboxChnlID.Name = "txtboxChnlID";
            this.txtboxChnlID.Size = new System.Drawing.Size(178, 20);
            this.txtboxChnlID.TabIndex = 15;
            this.txtboxChnlID.TextChanged += new System.EventHandler(this.txtboxChnlID_TextChanged);
            // 
            // panelWLANconfig
            // 
            this.panelWLANconfig.Controls.Add(this.btnWLANssid);
            this.panelWLANconfig.Controls.Add(this.WLANNetzwerke);
            this.panelWLANconfig.Controls.Add(this.cmbboxWLANSSID);
            this.panelWLANconfig.Controls.Add(this.btnWLANscan);
            this.panelWLANconfig.Controls.Add(this.lblUeberschriftWLAN);
            this.panelWLANconfig.Controls.Add(this.btnWLANPSWD);
            this.panelWLANconfig.Controls.Add(this.txtboxWLANPSWD);
            this.panelWLANconfig.Controls.Add(this.instructionlblWLAN);
            this.panelWLANconfig.Location = new System.Drawing.Point(138, 27);
            this.panelWLANconfig.Name = "panelWLANconfig";
            this.panelWLANconfig.Size = new System.Drawing.Size(384, 368);
            this.panelWLANconfig.TabIndex = 18;
            // 
            // btnWLANssid
            // 
            this.btnWLANssid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWLANssid.Location = new System.Drawing.Point(229, 130);
            this.btnWLANssid.Name = "btnWLANssid";
            this.btnWLANssid.Size = new System.Drawing.Size(93, 27);
            this.btnWLANssid.TabIndex = 12;
            this.btnWLANssid.Text = "übertragen";
            this.btnWLANssid.UseVisualStyleBackColor = false;
            this.btnWLANssid.Click += new System.EventHandler(this.btnWLANssid_Click);
            // 
            // WLANNetzwerke
            // 
            this.WLANNetzwerke.AutoSize = true;
            this.WLANNetzwerke.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.WLANNetzwerke.Location = new System.Drawing.Point(37, 80);
            this.WLANNetzwerke.Name = "WLANNetzwerke";
            this.WLANNetzwerke.Size = new System.Drawing.Size(166, 13);
            this.WLANNetzwerke.TabIndex = 11;
            this.WLANNetzwerke.Text = "Auswahl eines WLAN Netzwerks:";
            // 
            // cmbboxWLANSSID
            // 
            this.cmbboxWLANSSID.FormattingEnabled = true;
            this.cmbboxWLANSSID.Location = new System.Drawing.Point(34, 102);
            this.cmbboxWLANSSID.Name = "cmbboxWLANSSID";
            this.cmbboxWLANSSID.Size = new System.Drawing.Size(178, 21);
            this.cmbboxWLANSSID.TabIndex = 10;
            this.cmbboxWLANSSID.SelectedIndexChanged += new System.EventHandler(this.cmbboxWLANSSID_SelectedIndexChanged);
            // 
            // btnWLANscan
            // 
            this.btnWLANscan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWLANscan.Location = new System.Drawing.Point(229, 65);
            this.btnWLANscan.Name = "btnWLANscan";
            this.btnWLANscan.Size = new System.Drawing.Size(93, 43);
            this.btnWLANscan.TabIndex = 9;
            this.btnWLANscan.Text = "Scan";
            this.btnWLANscan.UseVisualStyleBackColor = false;
            this.btnWLANscan.Click += new System.EventHandler(this.btnWLANscan_Click);
            // 
            // lblUeberschriftWLAN
            // 
            this.lblUeberschriftWLAN.AutoSize = true;
            this.lblUeberschriftWLAN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUeberschriftWLAN.Location = new System.Drawing.Point(109, 19);
            this.lblUeberschriftWLAN.Name = "lblUeberschriftWLAN";
            this.lblUeberschriftWLAN.Size = new System.Drawing.Size(150, 19);
            this.lblUeberschriftWLAN.TabIndex = 8;
            this.lblUeberschriftWLAN.Text = "WLAN Konfiguration";
            // 
            // btnWLANPanel
            // 
            this.btnWLANPanel.Location = new System.Drawing.Point(0, 142);
            this.btnWLANPanel.Name = "btnWLANPanel";
            this.btnWLANPanel.Size = new System.Drawing.Size(132, 48);
            this.btnWLANPanel.TabIndex = 19;
            this.btnWLANPanel.Text = "WLAN Konfiguration";
            this.btnWLANPanel.UseVisualStyleBackColor = true;
            this.btnWLANPanel.Click += new System.EventHandler(this.btnWLANPanel_Click);
            // 
            // panelSerial
            // 
            this.panelSerial.Controls.Add(this.label1);
            this.panelSerial.Controls.Add(this.btnInitCom);
            this.panelSerial.Controls.Add(this.lblCOMPort);
            this.panelSerial.Location = new System.Drawing.Point(0, 0);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(384, 371);
            this.panelSerial.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "serielle Verbindung";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnThingSpeakPanel
            // 
            this.btnThingSpeakPanel.Location = new System.Drawing.Point(0, 196);
            this.btnThingSpeakPanel.Name = "btnThingSpeakPanel";
            this.btnThingSpeakPanel.Size = new System.Drawing.Size(132, 48);
            this.btnThingSpeakPanel.TabIndex = 21;
            this.btnThingSpeakPanel.Text = "ThingSpeak";
            this.btnThingSpeakPanel.UseVisualStyleBackColor = true;
            this.btnThingSpeakPanel.Click += new System.EventHandler(this.btnThingSpeakPanel_Click);
            // 
            // btnSerialPanel
            // 
            this.btnSerialPanel.Location = new System.Drawing.Point(0, 88);
            this.btnSerialPanel.Name = "btnSerialPanel";
            this.btnSerialPanel.Size = new System.Drawing.Size(132, 48);
            this.btnSerialPanel.TabIndex = 22;
            this.btnSerialPanel.Text = "serielle Kommunikation";
            this.btnSerialPanel.UseVisualStyleBackColor = true;
            this.btnSerialPanel.Click += new System.EventHandler(this.btnSerialPanel_Click);
            // 
            // panelThingSpeak
            // 
            this.panelThingSpeak.Controls.Add(this.label3);
            this.panelThingSpeak.Controls.Add(this.instructionlblMQTTPass);
            this.panelThingSpeak.Controls.Add(this.panelSerial);
            this.panelThingSpeak.Controls.Add(this.txtboxMQTTPSWD);
            this.panelThingSpeak.Controls.Add(this.btnMQTTPass);
            this.panelThingSpeak.Controls.Add(this.txtboxMQTTAPIK);
            this.panelThingSpeak.Controls.Add(this.instructionlblMQTTAPI);
            this.panelThingSpeak.Controls.Add(this.btnMQTTAPIK);
            this.panelThingSpeak.Controls.Add(this.btnChnlID);
            this.panelThingSpeak.Controls.Add(this.txtboxChnlID);
            this.panelThingSpeak.Controls.Add(this.instructionlblchnlID);
            this.panelThingSpeak.Location = new System.Drawing.Point(138, 27);
            this.panelThingSpeak.Name = "panelThingSpeak";
            this.panelThingSpeak.Size = new System.Drawing.Size(384, 371);
            this.panelThingSpeak.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "ThingSpeak Kommunikation";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblSerialDat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 51);
            this.panel1.TabIndex = 24;
            // 
            // ZaehlerkopfKonfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 451);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelThingSpeak);
            this.Controls.Add(this.btnSerialPanel);
            this.Controls.Add(this.btnThingSpeakPanel);
            this.Controls.Add(this.btnWLANPanel);
            this.Controls.Add(this.panelWLANconfig);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ZaehlerkopfKonfigurator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zählerkopf-Konfigurator";
            this.Load += new System.EventHandler(this.ZaehlerkopfKonfigurator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelWLANconfig.ResumeLayout(false);
            this.panelWLANconfig.PerformLayout();
            this.panelSerial.ResumeLayout(false);
            this.panelSerial.PerformLayout();
            this.panelThingSpeak.ResumeLayout(false);
            this.panelThingSpeak.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.IO.Ports.SerialPort ESP8266Serial;
        private System.Windows.Forms.ToolStripMenuItem cOMPortAuswählenToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCOMPort;
        private System.Windows.Forms.ToolStripMenuItem cOMPortsAktualisierenToolStripMenuItem;
        private System.Windows.Forms.Button btnInitCom;
        private System.Windows.Forms.Label lblCOMPort;
        private System.Windows.Forms.Label lblSerialDat;
        private System.Windows.Forms.TextBox txtboxWLANPSWD;
        private System.Windows.Forms.Label instructionlblWLAN;
        private System.Windows.Forms.Button btnWLANPSWD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.Button btnMQTTPass;
        private System.Windows.Forms.Label instructionlblMQTTPass;
        private System.Windows.Forms.TextBox txtboxMQTTPSWD;
        private System.Windows.Forms.Button btnMQTTAPIK;
        private System.Windows.Forms.Label instructionlblMQTTAPI;
        private System.Windows.Forms.TextBox txtboxMQTTAPIK;
        private System.Windows.Forms.Button btnChnlID;
        private System.Windows.Forms.Label instructionlblchnlID;
        private System.Windows.Forms.TextBox txtboxChnlID;
        private System.Windows.Forms.ToolStripMenuItem hilfeAufrufenToolStripMenuItem;
        private System.Windows.Forms.Panel panelWLANconfig;
        private System.Windows.Forms.Label WLANNetzwerke;
        private System.Windows.Forms.ComboBox cmbboxWLANSSID;
        private System.Windows.Forms.Button btnWLANscan;
        private System.Windows.Forms.Label lblUeberschriftWLAN;
        private System.Windows.Forms.Button btnWLANssid;
        private System.Windows.Forms.Button btnWLANPanel;
        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.Button btnThingSpeakPanel;
        private System.Windows.Forms.Button btnSerialPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelThingSpeak;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}

