namespace SerialPortController
{
    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            btnUpdate = new MaterialSkin.Controls.MaterialButton();
            materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
            cbComPortsList = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            groupBox1 = new GroupBox();
            cbHandShake = new MaterialSkin.Controls.MaterialComboBox();
            cbStopBits = new MaterialSkin.Controls.MaterialComboBox();
            cbParity = new MaterialSkin.Controls.MaterialComboBox();
            txtDataBits = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            txtWriteTimeOut = new MaterialSkin.Controls.MaterialTextBox();
            txtReadTimeOut = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            txtBaudRate = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            switchDefaultParameters = new MaterialSkin.Controls.MaterialSwitch();
            btnConnect = new MaterialSkin.Controls.MaterialButton();
            btnDisconnect = new MaterialSkin.Controls.MaterialButton();
            groupBox2 = new GroupBox();
            txtReceivedData = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpdate.Depth = 0;
            btnUpdate.HighEmphasis = true;
            btnUpdate.Icon = null;
            btnUpdate.Location = new Point(167, 105);
            btnUpdate.Margin = new Padding(4, 6, 4, 6);
            btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.NoAccentTextColor = Color.Empty;
            btnUpdate.Size = new Size(99, 36);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Atualizar";
            btnUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpdate.UseAccentColor = false;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // materialDrawer1
            // 
            materialDrawer1.AutoHide = false;
            materialDrawer1.AutoShow = false;
            materialDrawer1.BackgroundWithAccent = false;
            materialDrawer1.BaseTabControl = null;
            materialDrawer1.Depth = 0;
            materialDrawer1.HighlightWithAccent = true;
            materialDrawer1.IndicatorWidth = 0;
            materialDrawer1.IsOpen = false;
            materialDrawer1.Location = new Point(-163, 299);
            materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
            materialDrawer1.Name = "materialDrawer1";
            materialDrawer1.ShowIconsWhenHidden = false;
            materialDrawer1.Size = new Size(163, 99);
            materialDrawer1.TabIndex = 2;
            materialDrawer1.Text = "materialDrawer1";
            materialDrawer1.UseColors = false;
            // 
            // cbComPortsList
            // 
            cbComPortsList.AutoResize = false;
            cbComPortsList.BackColor = Color.FromArgb(255, 255, 255);
            cbComPortsList.Depth = 0;
            cbComPortsList.DrawMode = DrawMode.OwnerDrawVariable;
            cbComPortsList.DropDownHeight = 118;
            cbComPortsList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbComPortsList.DropDownWidth = 121;
            cbComPortsList.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbComPortsList.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbComPortsList.FormattingEnabled = true;
            cbComPortsList.IntegralHeight = false;
            cbComPortsList.ItemHeight = 29;
            cbComPortsList.Location = new Point(6, 105);
            cbComPortsList.MaxDropDownItems = 4;
            cbComPortsList.MouseState = MaterialSkin.MouseState.OUT;
            cbComPortsList.Name = "cbComPortsList";
            cbComPortsList.Size = new Size(154, 35);
            cbComPortsList.StartIndex = 0;
            cbComPortsList.TabIndex = 4;
            cbComPortsList.UseTallSize = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(6, 83);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(99, 19);
            materialLabel1.TabIndex = 6;
            materialLabel1.Text = "Portas Seriais";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbHandShake);
            groupBox1.Controls.Add(cbStopBits);
            groupBox1.Controls.Add(cbParity);
            groupBox1.Controls.Add(txtDataBits);
            groupBox1.Controls.Add(materialLabel10);
            groupBox1.Controls.Add(txtWriteTimeOut);
            groupBox1.Controls.Add(txtReadTimeOut);
            groupBox1.Controls.Add(materialLabel9);
            groupBox1.Controls.Add(txtBaudRate);
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(materialLabel6);
            groupBox1.Controls.Add(materialLabel7);
            groupBox1.Controls.Add(materialLabel8);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(6, 188);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 369);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parâmetros";
            // 
            // cbHandShake
            // 
            cbHandShake.AutoResize = false;
            cbHandShake.BackColor = Color.FromArgb(255, 255, 255);
            cbHandShake.Depth = 0;
            cbHandShake.DrawMode = DrawMode.OwnerDrawVariable;
            cbHandShake.DropDownHeight = 118;
            cbHandShake.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHandShake.DropDownWidth = 121;
            cbHandShake.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbHandShake.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbHandShake.FormattingEnabled = true;
            cbHandShake.IntegralHeight = false;
            cbHandShake.ItemHeight = 29;
            cbHandShake.Location = new Point(6, 326);
            cbHandShake.MaxDropDownItems = 4;
            cbHandShake.MouseState = MaterialSkin.MouseState.OUT;
            cbHandShake.Name = "cbHandShake";
            cbHandShake.Size = new Size(248, 35);
            cbHandShake.StartIndex = 0;
            cbHandShake.TabIndex = 23;
            cbHandShake.UseTallSize = false;
            // 
            // cbStopBits
            // 
            cbStopBits.AutoResize = false;
            cbStopBits.BackColor = Color.FromArgb(255, 255, 255);
            cbStopBits.Depth = 0;
            cbStopBits.DrawMode = DrawMode.OwnerDrawVariable;
            cbStopBits.DropDownHeight = 118;
            cbStopBits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStopBits.DropDownWidth = 121;
            cbStopBits.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbStopBits.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbStopBits.FormattingEnabled = true;
            cbStopBits.IntegralHeight = false;
            cbStopBits.ItemHeight = 29;
            cbStopBits.Location = new Point(6, 258);
            cbStopBits.MaxDropDownItems = 4;
            cbStopBits.MouseState = MaterialSkin.MouseState.OUT;
            cbStopBits.Name = "cbStopBits";
            cbStopBits.Size = new Size(248, 35);
            cbStopBits.StartIndex = 0;
            cbStopBits.TabIndex = 22;
            cbStopBits.UseTallSize = false;
            // 
            // cbParity
            // 
            cbParity.AutoResize = false;
            cbParity.BackColor = Color.FromArgb(255, 255, 255);
            cbParity.Depth = 0;
            cbParity.DrawMode = DrawMode.OwnerDrawVariable;
            cbParity.DropDownHeight = 118;
            cbParity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbParity.DropDownWidth = 121;
            cbParity.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbParity.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbParity.FormattingEnabled = true;
            cbParity.IntegralHeight = false;
            cbParity.ItemHeight = 29;
            cbParity.Location = new Point(6, 188);
            cbParity.MaxDropDownItems = 4;
            cbParity.MouseState = MaterialSkin.MouseState.OUT;
            cbParity.Name = "cbParity";
            cbParity.Size = new Size(248, 35);
            cbParity.StartIndex = 0;
            cbParity.TabIndex = 15;
            cbParity.UseTallSize = false;
            // 
            // txtDataBits
            // 
            txtDataBits.AnimateReadOnly = false;
            txtDataBits.BorderStyle = BorderStyle.None;
            txtDataBits.Depth = 0;
            txtDataBits.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDataBits.LeadingIcon = null;
            txtDataBits.Location = new Point(144, 47);
            txtDataBits.MaxLength = 50;
            txtDataBits.MouseState = MaterialSkin.MouseState.OUT;
            txtDataBits.Multiline = false;
            txtDataBits.Name = "txtDataBits";
            txtDataBits.Size = new Size(110, 36);
            txtDataBits.TabIndex = 18;
            txtDataBits.Text = "";
            txtDataBits.TrailingIcon = null;
            txtDataBits.UseTallSize = false;
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(6, 306);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(91, 19);
            materialLabel10.TabIndex = 14;
            materialLabel10.Text = "Hand Shake:";
            // 
            // txtWriteTimeOut
            // 
            txtWriteTimeOut.AnimateReadOnly = false;
            txtWriteTimeOut.BorderStyle = BorderStyle.None;
            txtWriteTimeOut.Depth = 0;
            txtWriteTimeOut.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtWriteTimeOut.LeadingIcon = null;
            txtWriteTimeOut.Location = new Point(144, 118);
            txtWriteTimeOut.MaxLength = 50;
            txtWriteTimeOut.MouseState = MaterialSkin.MouseState.OUT;
            txtWriteTimeOut.Multiline = false;
            txtWriteTimeOut.Name = "txtWriteTimeOut";
            txtWriteTimeOut.Size = new Size(110, 36);
            txtWriteTimeOut.TabIndex = 17;
            txtWriteTimeOut.Text = "";
            txtWriteTimeOut.TrailingIcon = null;
            txtWriteTimeOut.UseTallSize = false;
            // 
            // txtReadTimeOut
            // 
            txtReadTimeOut.AnimateReadOnly = false;
            txtReadTimeOut.BorderStyle = BorderStyle.None;
            txtReadTimeOut.Depth = 0;
            txtReadTimeOut.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtReadTimeOut.LeadingIcon = null;
            txtReadTimeOut.Location = new Point(6, 118);
            txtReadTimeOut.MaxLength = 50;
            txtReadTimeOut.MouseState = MaterialSkin.MouseState.OUT;
            txtReadTimeOut.Multiline = false;
            txtReadTimeOut.Name = "txtReadTimeOut";
            txtReadTimeOut.Size = new Size(110, 36);
            txtReadTimeOut.TabIndex = 16;
            txtReadTimeOut.Text = "";
            txtReadTimeOut.TrailingIcon = null;
            txtReadTimeOut.UseTallSize = false;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(6, 236);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(69, 19);
            materialLabel9.TabIndex = 13;
            materialLabel9.Text = "Stop Bits:";
            // 
            // txtBaudRate
            // 
            txtBaudRate.AnimateReadOnly = false;
            txtBaudRate.BorderStyle = BorderStyle.None;
            txtBaudRate.Depth = 0;
            txtBaudRate.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBaudRate.LeadingIcon = null;
            txtBaudRate.Location = new Point(6, 47);
            txtBaudRate.MaxLength = 50;
            txtBaudRate.MouseState = MaterialSkin.MouseState.OUT;
            txtBaudRate.Multiline = false;
            txtBaudRate.Name = "txtBaudRate";
            txtBaudRate.Size = new Size(110, 36);
            txtBaudRate.TabIndex = 15;
            txtBaudRate.Text = "";
            txtBaudRate.TrailingIcon = null;
            txtBaudRate.UseTallSize = false;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(6, 25);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(78, 19);
            materialLabel4.TabIndex = 8;
            materialLabel4.Text = "Baud Rate:";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(144, 25);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(70, 19);
            materialLabel5.TabIndex = 9;
            materialLabel5.Text = "Data Bits:";
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(6, 96);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(110, 19);
            materialLabel6.TabIndex = 10;
            materialLabel6.Text = "Read Time Out:";
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(144, 96);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(110, 19);
            materialLabel7.TabIndex = 11;
            materialLabel7.Text = "Write Time Out:";
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(6, 166);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(46, 19);
            materialLabel8.TabIndex = 12;
            materialLabel8.Text = "Parity:";
            // 
            // switchDefaultParameters
            // 
            switchDefaultParameters.AutoSize = true;
            switchDefaultParameters.Checked = true;
            switchDefaultParameters.CheckState = CheckState.Checked;
            switchDefaultParameters.Depth = 0;
            switchDefaultParameters.Location = new Point(6, 145);
            switchDefaultParameters.Margin = new Padding(0);
            switchDefaultParameters.MouseLocation = new Point(-1, -1);
            switchDefaultParameters.MouseState = MaterialSkin.MouseState.HOVER;
            switchDefaultParameters.Name = "switchDefaultParameters";
            switchDefaultParameters.Ripple = true;
            switchDefaultParameters.Size = new Size(229, 37);
            switchDefaultParameters.TabIndex = 12;
            switchDefaultParameters.Text = "Usar parâmetros padrão";
            switchDefaultParameters.UseVisualStyleBackColor = true;
            switchDefaultParameters.CheckedChanged += switchDefaultParameters_CheckedChanged;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConnect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnConnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConnect.Depth = 0;
            btnConnect.HighEmphasis = true;
            btnConnect.Icon = null;
            btnConnect.Location = new Point(24, 566);
            btnConnect.Margin = new Padding(4, 6, 4, 6);
            btnConnect.MouseState = MaterialSkin.MouseState.HOVER;
            btnConnect.Name = "btnConnect";
            btnConnect.NoAccentTextColor = Color.Empty;
            btnConnect.Size = new Size(98, 36);
            btnConnect.TabIndex = 13;
            btnConnect.Text = "Conectar";
            btnConnect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConnect.UseAccentColor = false;
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDisconnect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDisconnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDisconnect.Depth = 0;
            btnDisconnect.Enabled = false;
            btnDisconnect.HighEmphasis = true;
            btnDisconnect.Icon = null;
            btnDisconnect.Location = new Point(135, 566);
            btnDisconnect.Margin = new Padding(4, 6, 4, 6);
            btnDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.NoAccentTextColor = Color.Empty;
            btnDisconnect.Size = new Size(125, 36);
            btnDisconnect.TabIndex = 14;
            btnDisconnect.Text = "Desconectar";
            btnDisconnect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDisconnect.UseAccentColor = false;
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtReceivedData);
            groupBox2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(277, 83);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(335, 519);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados Recebidos";
            // 
            // txtReceivedData
            // 
            txtReceivedData.BackColor = Color.FromArgb(255, 255, 255);
            txtReceivedData.BorderStyle = BorderStyle.None;
            txtReceivedData.Depth = 0;
            txtReceivedData.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtReceivedData.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtReceivedData.Location = new Point(6, 31);
            txtReceivedData.MouseState = MaterialSkin.MouseState.HOVER;
            txtReceivedData.Name = "txtReceivedData";
            txtReceivedData.ReadOnly = true;
            txtReceivedData.Size = new Size(323, 482);
            txtReceivedData.TabIndex = 0;
            txtReceivedData.Text = "";
            txtReceivedData.TextChanged += txtReceivedData_TextChanged;
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 611);
            Controls.Add(groupBox2);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(switchDefaultParameters);
            Controls.Add(groupBox1);
            Controls.Add(materialLabel1);
            Controls.Add(cbComPortsList);
            Controls.Add(materialDrawer1);
            Controls.Add(btnUpdate);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Interface";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Porta Serial";
            FormClosing += Interface_FormClosing;
            FormClosed += Interface_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnUpdate;
        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
        private MaterialSkin.Controls.MaterialComboBox cbComPortsList;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSwitch switchDefaultParameters;
        private MaterialSkin.Controls.MaterialButton btnConnect;
        private MaterialSkin.Controls.MaterialButton btnDisconnect;
        private MaterialSkin.Controls.MaterialTextBox txtDataBits;
        private MaterialSkin.Controls.MaterialTextBox txtWriteTimeOut;
        private MaterialSkin.Controls.MaterialTextBox txtReadTimeOut;
        private MaterialSkin.Controls.MaterialTextBox txtBaudRate;
        private MaterialSkin.Controls.MaterialComboBox cbHandShake;
        private MaterialSkin.Controls.MaterialComboBox cbStopBits;
        private MaterialSkin.Controls.MaterialComboBox cbParity;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox txtReceivedData;
    }
}