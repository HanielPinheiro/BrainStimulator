namespace BrainStimulator
{
    partial class BrainStimulator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnUpdateCom = new Button();
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnStartStimulus = new Button();
            btnStopStimulus = new Button();
            cbComPorts = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            gpBox_ArduinoData = new GroupBox();
            txtArea_ArduinoData = new RichTextBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnSendDataToBoard = new Button();
            gpBox_Terminal = new GroupBox();
            txtTerminal = new TextBox();
            tabController = new TabControl();
            tabPeriodic = new TabPage();
            tbPanel_PeriodicTab = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            PeriodicTab_AddPulse = new Button();
            PeriodicTab_RemovePulse = new Button();
            PeriodicTab_GridMain = new DataGridView();
            chartPeriodic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabChaotic = new TabPage();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            gpBox_ArduinoData.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            gpBox_Terminal.SuspendLayout();
            tabController.SuspendLayout();
            tabPeriodic.SuspendLayout();
            tbPanel_PeriodicTab.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PeriodicTab_GridMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPeriodic).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tabController, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.7076645F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.2923355F));
            tableLayoutPanel1.Size = new Size(784, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(784, 133);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(btnUpdateCom, 1, 0);
            tableLayoutPanel3.Controls.Add(btnConnect, 0, 1);
            tableLayoutPanel3.Controls.Add(btnDisconnect, 1, 1);
            tableLayoutPanel3.Controls.Add(btnStartStimulus, 0, 2);
            tableLayoutPanel3.Controls.Add(btnStopStimulus, 1, 2);
            tableLayoutPanel3.Controls.Add(cbComPorts, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tableLayoutPanel3.Size = new Size(392, 133);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // btnUpdateCom
            // 
            btnUpdateCom.Dock = DockStyle.Fill;
            btnUpdateCom.FlatStyle = FlatStyle.Flat;
            btnUpdateCom.Location = new Point(196, 0);
            btnUpdateCom.Margin = new Padding(0);
            btnUpdateCom.Name = "btnUpdateCom";
            btnUpdateCom.Size = new Size(196, 43);
            btnUpdateCom.TabIndex = 0;
            btnUpdateCom.Text = "Atualizar Lista de Portas";
            btnUpdateCom.UseVisualStyleBackColor = true;
            btnUpdateCom.Click += btnUpdateCom_Click;
            // 
            // btnConnect
            // 
            btnConnect.Dock = DockStyle.Fill;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Location = new Point(0, 43);
            btnConnect.Margin = new Padding(0);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(196, 43);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Dock = DockStyle.Fill;
            btnDisconnect.Enabled = false;
            btnDisconnect.FlatStyle = FlatStyle.Flat;
            btnDisconnect.Location = new Point(196, 43);
            btnDisconnect.Margin = new Padding(0);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(196, 43);
            btnDisconnect.TabIndex = 2;
            btnDisconnect.Text = "Desconectar";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnStartStimulus
            // 
            btnStartStimulus.Dock = DockStyle.Fill;
            btnStartStimulus.Enabled = false;
            btnStartStimulus.FlatStyle = FlatStyle.Flat;
            btnStartStimulus.Location = new Point(0, 86);
            btnStartStimulus.Margin = new Padding(0);
            btnStartStimulus.Name = "btnStartStimulus";
            btnStartStimulus.Size = new Size(196, 47);
            btnStartStimulus.TabIndex = 3;
            btnStartStimulus.Text = "Estimular";
            btnStartStimulus.UseVisualStyleBackColor = true;
            btnStartStimulus.Click += btnStartStimulus_Click;
            // 
            // btnStopStimulus
            // 
            btnStopStimulus.Dock = DockStyle.Fill;
            btnStopStimulus.Enabled = false;
            btnStopStimulus.FlatStyle = FlatStyle.Flat;
            btnStopStimulus.Location = new Point(196, 86);
            btnStopStimulus.Margin = new Padding(0);
            btnStopStimulus.Name = "btnStopStimulus";
            btnStopStimulus.Size = new Size(196, 47);
            btnStopStimulus.TabIndex = 4;
            btnStopStimulus.Text = "Parar Estimulação";
            btnStopStimulus.UseVisualStyleBackColor = true;
            btnStopStimulus.Click += btnStopStimulus_Click;
            // 
            // cbComPorts
            // 
            cbComPorts.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbComPorts.FormattingEnabled = true;
            cbComPorts.Location = new Point(3, 10);
            cbComPorts.Name = "cbComPorts";
            cbComPorts.Size = new Size(190, 23);
            cbComPorts.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(gpBox_ArduinoData, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(392, 0);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(392, 133);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // gpBox_ArduinoData
            // 
            gpBox_ArduinoData.Controls.Add(txtArea_ArduinoData);
            gpBox_ArduinoData.Dock = DockStyle.Fill;
            gpBox_ArduinoData.Location = new Point(3, 3);
            gpBox_ArduinoData.Name = "gpBox_ArduinoData";
            gpBox_ArduinoData.Size = new Size(190, 127);
            gpBox_ArduinoData.TabIndex = 0;
            gpBox_ArduinoData.TabStop = false;
            gpBox_ArduinoData.Text = "Dados do Arduino";
            // 
            // txtArea_ArduinoData
            // 
            txtArea_ArduinoData.Dock = DockStyle.Fill;
            txtArea_ArduinoData.Enabled = false;
            txtArea_ArduinoData.Location = new Point(3, 19);
            txtArea_ArduinoData.Name = "txtArea_ArduinoData";
            txtArea_ArduinoData.Size = new Size(184, 105);
            txtArea_ArduinoData.TabIndex = 0;
            txtArea_ArduinoData.Text = "";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(btnSendDataToBoard, 0, 1);
            tableLayoutPanel5.Controls.Add(gpBox_Terminal, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Right;
            tableLayoutPanel5.Location = new Point(196, 0);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(196, 133);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // btnSendDataToBoard
            // 
            btnSendDataToBoard.Dock = DockStyle.Fill;
            btnSendDataToBoard.Enabled = false;
            btnSendDataToBoard.FlatStyle = FlatStyle.Flat;
            btnSendDataToBoard.Location = new Point(0, 66);
            btnSendDataToBoard.Margin = new Padding(0);
            btnSendDataToBoard.Name = "btnSendDataToBoard";
            btnSendDataToBoard.Size = new Size(196, 67);
            btnSendDataToBoard.TabIndex = 3;
            btnSendDataToBoard.Text = "Enviar dados para placa";
            btnSendDataToBoard.UseVisualStyleBackColor = true;
            btnSendDataToBoard.Click += btnSendDataToBoard_Click;
            // 
            // gpBox_Terminal
            // 
            gpBox_Terminal.Controls.Add(txtTerminal);
            gpBox_Terminal.Dock = DockStyle.Fill;
            gpBox_Terminal.Location = new Point(3, 3);
            gpBox_Terminal.Name = "gpBox_Terminal";
            gpBox_Terminal.Size = new Size(190, 60);
            gpBox_Terminal.TabIndex = 1;
            gpBox_Terminal.TabStop = false;
            gpBox_Terminal.Text = "Terminal";
            // 
            // txtTerminal
            // 
            txtTerminal.Dock = DockStyle.Fill;
            txtTerminal.Enabled = false;
            txtTerminal.Location = new Point(3, 19);
            txtTerminal.Name = "txtTerminal";
            txtTerminal.Size = new Size(184, 23);
            txtTerminal.TabIndex = 0;
            // 
            // tabController
            // 
            tabController.Controls.Add(tabPeriodic);
            tabController.Controls.Add(tabChaotic);
            tabController.Dock = DockStyle.Fill;
            tabController.Location = new Point(3, 136);
            tabController.Name = "tabController";
            tabController.SelectedIndex = 0;
            tabController.Size = new Size(778, 422);
            tabController.TabIndex = 1;
            // 
            // tabPeriodic
            // 
            tabPeriodic.Controls.Add(tbPanel_PeriodicTab);
            tabPeriodic.Location = new Point(4, 24);
            tabPeriodic.Name = "tabPeriodic";
            tabPeriodic.Padding = new Padding(3);
            tabPeriodic.Size = new Size(770, 394);
            tabPeriodic.TabIndex = 0;
            tabPeriodic.Text = "Periódico ou Nao Periódico";
            tabPeriodic.UseVisualStyleBackColor = true;
            // 
            // tbPanel_PeriodicTab
            // 
            tbPanel_PeriodicTab.ColumnCount = 1;
            tbPanel_PeriodicTab.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.53403F));
            tbPanel_PeriodicTab.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.4659653F));
            tbPanel_PeriodicTab.Controls.Add(tableLayoutPanel7, 0, 0);
            tbPanel_PeriodicTab.Controls.Add(chartPeriodic, 0, 1);
            tbPanel_PeriodicTab.Dock = DockStyle.Fill;
            tbPanel_PeriodicTab.Location = new Point(3, 3);
            tbPanel_PeriodicTab.Margin = new Padding(0);
            tbPanel_PeriodicTab.Name = "tbPanel_PeriodicTab";
            tbPanel_PeriodicTab.RowCount = 2;
            tbPanel_PeriodicTab.RowStyles.Add(new RowStyle(SizeType.Percent, 34.02062F));
            tbPanel_PeriodicTab.RowStyles.Add(new RowStyle(SizeType.Percent, 65.97938F));
            tbPanel_PeriodicTab.Size = new Size(764, 388);
            tbPanel_PeriodicTab.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.43979F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.56021F));
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 0);
            tableLayoutPanel7.Controls.Add(PeriodicTab_GridMain, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Margin = new Padding(0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(764, 132);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(PeriodicTab_AddPulse, 0, 0);
            tableLayoutPanel8.Controls.Add(PeriodicTab_RemovePulse, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Margin = new Padding(0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(202, 132);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // PeriodicTab_AddPulse
            // 
            PeriodicTab_AddPulse.Dock = DockStyle.Fill;
            PeriodicTab_AddPulse.FlatStyle = FlatStyle.Flat;
            PeriodicTab_AddPulse.Location = new Point(0, 0);
            PeriodicTab_AddPulse.Margin = new Padding(0);
            PeriodicTab_AddPulse.Name = "PeriodicTab_AddPulse";
            PeriodicTab_AddPulse.Size = new Size(202, 66);
            PeriodicTab_AddPulse.TabIndex = 0;
            PeriodicTab_AddPulse.Text = "Adicionar Pulso";
            PeriodicTab_AddPulse.UseVisualStyleBackColor = true;
            PeriodicTab_AddPulse.Click += PeriodicTab_AddPulse_Click;
            // 
            // PeriodicTab_RemovePulse
            // 
            PeriodicTab_RemovePulse.Dock = DockStyle.Fill;
            PeriodicTab_RemovePulse.FlatStyle = FlatStyle.Flat;
            PeriodicTab_RemovePulse.Location = new Point(0, 66);
            PeriodicTab_RemovePulse.Margin = new Padding(0);
            PeriodicTab_RemovePulse.Name = "PeriodicTab_RemovePulse";
            PeriodicTab_RemovePulse.Size = new Size(202, 66);
            PeriodicTab_RemovePulse.TabIndex = 1;
            PeriodicTab_RemovePulse.Text = "Remover Pulso";
            PeriodicTab_RemovePulse.UseVisualStyleBackColor = true;
            PeriodicTab_RemovePulse.Click += PeriodicTab_RemovePulse_Click;
            // 
            // PeriodicTab_GridMain
            // 
            PeriodicTab_GridMain.AllowUserToAddRows = false;
            PeriodicTab_GridMain.AllowUserToDeleteRows = false;
            PeriodicTab_GridMain.AllowUserToOrderColumns = true;
            PeriodicTab_GridMain.AllowUserToResizeRows = false;
            PeriodicTab_GridMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PeriodicTab_GridMain.Dock = DockStyle.Fill;
            PeriodicTab_GridMain.Location = new Point(202, 0);
            PeriodicTab_GridMain.Margin = new Padding(0);
            PeriodicTab_GridMain.Name = "PeriodicTab_GridMain";
            PeriodicTab_GridMain.RowTemplate.Height = 25;
            PeriodicTab_GridMain.Size = new Size(562, 132);
            PeriodicTab_GridMain.TabIndex = 1;
            // 
            // chartPeriodic
            // 
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.Name = "ChartArea1";
            chartPeriodic.ChartAreas.Add(chartArea1);
            chartPeriodic.Dock = DockStyle.Fill;
            chartPeriodic.Location = new Point(0, 132);
            chartPeriodic.Margin = new Padding(0);
            chartPeriodic.Name = "chartPeriodic";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Name = "Pulses";
            chartPeriodic.Series.Add(series1);
            chartPeriodic.Size = new Size(764, 256);
            chartPeriodic.TabIndex = 1;
            chartPeriodic.Text = "chart1";
            // 
            // tabChaotic
            // 
            tabChaotic.Location = new Point(4, 24);
            tabChaotic.Name = "tabChaotic";
            tabChaotic.Padding = new Padding(3);
            tabChaotic.Size = new Size(770, 394);
            tabChaotic.TabIndex = 1;
            tabChaotic.Text = "Caótico";
            tabChaotic.UseVisualStyleBackColor = true;
            // 
            // BrainStimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "BrainStimulator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stimulator";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            gpBox_ArduinoData.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            gpBox_Terminal.ResumeLayout(false);
            gpBox_Terminal.PerformLayout();
            tabController.ResumeLayout(false);
            tabPeriodic.ResumeLayout(false);
            tbPanel_PeriodicTab.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PeriodicTab_GridMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPeriodic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnUpdateCom;
        private Button btnConnect;
        private Button btnDisconnect;
        private Button btnStartStimulus;
        private Button btnStopStimulus;
        private ComboBox cbComPorts;
        private GroupBox gpBox_ArduinoData;
        private RichTextBox txtArea_ArduinoData;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnSendDataToBoard;
        private GroupBox gpBox_Terminal;
        private TabControl tabController;
        private TabPage tabPeriodic;
        private TableLayoutPanel tbPanel_PeriodicTab;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private Button PeriodicTab_AddPulse;
        private Button PeriodicTab_RemovePulse;
        private DataGridView PeriodicTab_GridMain;
        private TabPage tabChaotic;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeriodic;
        private TextBox txtTerminal;
    }
}