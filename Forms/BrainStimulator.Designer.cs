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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrainStimulator));
            tableLayoutPanel1 = new TableLayoutPanel();
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
            tableLayoutPanel4 = new TableLayoutPanel();
            gpBox_ArduinoData = new GroupBox();
            txtArea_ArduinoData = new RichTextBox();
            gpBox_Terminal = new GroupBox();
            txtTerminal = new TextBox();
            btnSendDataToBoard = new Button();
            tableLayoutPanel1.SuspendLayout();
            tabController.SuspendLayout();
            tabPeriodic.SuspendLayout();
            tbPanel_PeriodicTab.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PeriodicTab_GridMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPeriodic).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            gpBox_ArduinoData.SuspendLayout();
            gpBox_Terminal.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 213F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel1.Controls.Add(tabController, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.8770046F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.12299F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(784, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tabController
            // 
            tabController.Controls.Add(tabPeriodic);
            tabController.Controls.Add(tabChaotic);
            tabController.Dock = DockStyle.Fill;
            tabController.Location = new Point(3, 3);
            tabController.Name = "tabController";
            tabController.SelectedIndex = 0;
            tabController.Size = new Size(565, 555);
            tabController.TabIndex = 1;
            // 
            // tabPeriodic
            // 
            tabPeriodic.Controls.Add(tbPanel_PeriodicTab);
            tabPeriodic.Location = new Point(4, 24);
            tabPeriodic.Name = "tabPeriodic";
            tabPeriodic.Padding = new Padding(3);
            tabPeriodic.Size = new Size(557, 527);
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
            tbPanel_PeriodicTab.Size = new Size(551, 521);
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
            tableLayoutPanel7.Size = new Size(551, 177);
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
            tableLayoutPanel8.Size = new Size(145, 177);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // PeriodicTab_AddPulse
            // 
            PeriodicTab_AddPulse.Dock = DockStyle.Fill;
            PeriodicTab_AddPulse.FlatStyle = FlatStyle.Flat;
            PeriodicTab_AddPulse.Location = new Point(0, 0);
            PeriodicTab_AddPulse.Margin = new Padding(0);
            PeriodicTab_AddPulse.Name = "PeriodicTab_AddPulse";
            PeriodicTab_AddPulse.Size = new Size(145, 88);
            PeriodicTab_AddPulse.TabIndex = 0;
            PeriodicTab_AddPulse.Text = "Adicionar Pulso";
            PeriodicTab_AddPulse.UseVisualStyleBackColor = true;
            PeriodicTab_AddPulse.Click += PeriodicTab_AddPulse_Click;
            // 
            // PeriodicTab_RemovePulse
            // 
            PeriodicTab_RemovePulse.Dock = DockStyle.Fill;
            PeriodicTab_RemovePulse.FlatStyle = FlatStyle.Flat;
            PeriodicTab_RemovePulse.Location = new Point(0, 88);
            PeriodicTab_RemovePulse.Margin = new Padding(0);
            PeriodicTab_RemovePulse.Name = "PeriodicTab_RemovePulse";
            PeriodicTab_RemovePulse.Size = new Size(145, 89);
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
            PeriodicTab_GridMain.Location = new Point(145, 0);
            PeriodicTab_GridMain.Margin = new Padding(0);
            PeriodicTab_GridMain.Name = "PeriodicTab_GridMain";
            PeriodicTab_GridMain.RowTemplate.Height = 25;
            PeriodicTab_GridMain.Size = new Size(406, 177);
            PeriodicTab_GridMain.TabIndex = 1;
            // 
            // chartPeriodic
            // 
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.LineWidth = 0;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.Name = "ChartArea1";
            chartPeriodic.ChartAreas.Add(chartArea2);
            chartPeriodic.Dock = DockStyle.Fill;
            chartPeriodic.Location = new Point(0, 177);
            chartPeriodic.Margin = new Padding(0);
            chartPeriodic.Name = "chartPeriodic";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Name = "Pulses";
            chartPeriodic.Series.Add(series2);
            chartPeriodic.Size = new Size(551, 344);
            chartPeriodic.TabIndex = 1;
            chartPeriodic.Text = "chart1";
            // 
            // tabChaotic
            // 
            tabChaotic.Location = new Point(4, 24);
            tabChaotic.Name = "tabChaotic";
            tabChaotic.Padding = new Padding(3);
            tabChaotic.Size = new Size(557, 527);
            tabChaotic.TabIndex = 1;
            tabChaotic.Text = "Caótico";
            tabChaotic.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(btnSendDataToBoard, 0, 2);
            tableLayoutPanel4.Controls.Add(gpBox_Terminal, 0, 1);
            tableLayoutPanel4.Controls.Add(gpBox_ArduinoData, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(571, 0);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel4.Size = new Size(213, 561);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // gpBox_ArduinoData
            // 
            gpBox_ArduinoData.Controls.Add(txtArea_ArduinoData);
            gpBox_ArduinoData.Dock = DockStyle.Fill;
            gpBox_ArduinoData.Location = new Point(3, 3);
            gpBox_ArduinoData.Name = "gpBox_ArduinoData";
            gpBox_ArduinoData.Size = new Size(207, 386);
            gpBox_ArduinoData.TabIndex = 0;
            gpBox_ArduinoData.TabStop = false;
            gpBox_ArduinoData.Text = "Dados do Estimulador";
            // 
            // txtArea_ArduinoData
            // 
            txtArea_ArduinoData.Dock = DockStyle.Fill;
            txtArea_ArduinoData.Enabled = false;
            txtArea_ArduinoData.Location = new Point(3, 19);
            txtArea_ArduinoData.Name = "txtArea_ArduinoData";
            txtArea_ArduinoData.Size = new Size(201, 364);
            txtArea_ArduinoData.TabIndex = 0;
            txtArea_ArduinoData.Text = "";
            // 
            // gpBox_Terminal
            // 
            gpBox_Terminal.Controls.Add(txtTerminal);
            gpBox_Terminal.Dock = DockStyle.Fill;
            gpBox_Terminal.Location = new Point(3, 395);
            gpBox_Terminal.Name = "gpBox_Terminal";
            gpBox_Terminal.Size = new Size(207, 78);
            gpBox_Terminal.TabIndex = 2;
            gpBox_Terminal.TabStop = false;
            gpBox_Terminal.Text = "Terminal";
            // 
            // txtTerminal
            // 
            txtTerminal.Dock = DockStyle.Fill;
            txtTerminal.Enabled = false;
            txtTerminal.Location = new Point(3, 19);
            txtTerminal.Name = "txtTerminal";
            txtTerminal.Size = new Size(201, 23);
            txtTerminal.TabIndex = 0;
            // 
            // btnSendDataToBoard
            // 
            btnSendDataToBoard.Dock = DockStyle.Fill;
            btnSendDataToBoard.Enabled = false;
            btnSendDataToBoard.FlatStyle = FlatStyle.Flat;
            btnSendDataToBoard.Location = new Point(0, 476);
            btnSendDataToBoard.Margin = new Padding(0);
            btnSendDataToBoard.Name = "btnSendDataToBoard";
            btnSendDataToBoard.Size = new Size(213, 85);
            btnSendDataToBoard.TabIndex = 4;
            btnSendDataToBoard.Text = "Enviar dados para placa";
            btnSendDataToBoard.UseVisualStyleBackColor = true;
            // 
            // BrainStimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "BrainStimulator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estimulador Cerebral";
            tableLayoutPanel1.ResumeLayout(false);
            tabController.ResumeLayout(false);
            tabPeriodic.ResumeLayout(false);
            tbPanel_PeriodicTab.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PeriodicTab_GridMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPeriodic).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            gpBox_ArduinoData.ResumeLayout(false);
            gpBox_Terminal.ResumeLayout(false);
            gpBox_Terminal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
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
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnSendDataToBoard;
        private GroupBox gpBox_Terminal;
        private TextBox txtTerminal;
        private GroupBox gpBox_ArduinoData;
        private RichTextBox txtArea_ArduinoData;
    }
}