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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrainStimulator));
            tableLayoutPanel1 = new TableLayoutPanel();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            TabPeriodic = new TabPage();
            tbPanel_PeriodicTab = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            PeriodicTab_HeaderPanel = new TableLayoutPanel();
            PeriodicTab_AddPulse = new MaterialSkin.Controls.MaterialButton();
            PeriodicTab_RemovePulse = new MaterialSkin.Controls.MaterialButton();
            PeriodicTab_ConnectBoard = new MaterialSkin.Controls.MaterialButton();
            PeriodicTab_SendConfigToBoard = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            cbCurrents = new MaterialSkin.Controls.MaterialComboBox();
            label1 = new Label();
            PeriodicTab_GridMain = new DataGridView();
            PeriodicTab_ChartPlotView = new OxyPlot.WindowsForms.PlotView();
            TabChaotic = new TabPage();
            tableLayoutPanel1.SuspendLayout();
            materialTabControl1.SuspendLayout();
            TabPeriodic.SuspendLayout();
            tbPanel_PeriodicTab.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            PeriodicTab_HeaderPanel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PeriodicTab_GridMain).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 213F));
            tableLayoutPanel1.Controls.Add(materialTabControl1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 64);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.8770046F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.12299F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(794, 533);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(TabPeriodic);
            materialTabControl1.Controls.Add(TabChaotic);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 3);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(788, 527);
            materialTabControl1.TabIndex = 3;
            // 
            // TabPeriodic
            // 
            TabPeriodic.Controls.Add(tbPanel_PeriodicTab);
            TabPeriodic.Location = new Point(4, 24);
            TabPeriodic.Name = "TabPeriodic";
            TabPeriodic.Padding = new Padding(3);
            TabPeriodic.Size = new Size(780, 499);
            TabPeriodic.TabIndex = 0;
            TabPeriodic.Text = "Periódicos ou Não Periódicos";
            TabPeriodic.UseVisualStyleBackColor = true;
            // 
            // tbPanel_PeriodicTab
            // 
            tbPanel_PeriodicTab.ColumnCount = 1;
            tbPanel_PeriodicTab.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.53403F));
            tbPanel_PeriodicTab.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.4659653F));
            tbPanel_PeriodicTab.Controls.Add(tableLayoutPanel7, 0, 0);
            tbPanel_PeriodicTab.Controls.Add(PeriodicTab_ChartPlotView, 0, 1);
            tbPanel_PeriodicTab.Dock = DockStyle.Fill;
            tbPanel_PeriodicTab.Location = new Point(3, 3);
            tbPanel_PeriodicTab.Margin = new Padding(0);
            tbPanel_PeriodicTab.Name = "tbPanel_PeriodicTab";
            tbPanel_PeriodicTab.RowCount = 2;
            tbPanel_PeriodicTab.RowStyles.Add(new RowStyle(SizeType.Percent, 40.77079F));
            tbPanel_PeriodicTab.RowStyles.Add(new RowStyle(SizeType.Percent, 59.22921F));
            tbPanel_PeriodicTab.Size = new Size(774, 493);
            tbPanel_PeriodicTab.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.43979F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.56021F));
            tableLayoutPanel7.Controls.Add(PeriodicTab_HeaderPanel, 0, 0);
            tableLayoutPanel7.Controls.Add(PeriodicTab_GridMain, 1, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Margin = new Padding(0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 21.393034F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 78.6069641F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Size = new Size(774, 201);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // PeriodicTab_HeaderPanel
            // 
            PeriodicTab_HeaderPanel.ColumnCount = 5;
            PeriodicTab_HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.6063824F));
            PeriodicTab_HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.6755314F));
            PeriodicTab_HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.4053154F));
            PeriodicTab_HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.408638F));
            PeriodicTab_HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            PeriodicTab_HeaderPanel.Controls.Add(PeriodicTab_AddPulse, 0, 0);
            PeriodicTab_HeaderPanel.Controls.Add(PeriodicTab_RemovePulse, 1, 0);
            PeriodicTab_HeaderPanel.Controls.Add(PeriodicTab_ConnectBoard, 2, 0);
            PeriodicTab_HeaderPanel.Controls.Add(PeriodicTab_SendConfigToBoard, 3, 0);
            PeriodicTab_HeaderPanel.Controls.Add(tableLayoutPanel2, 4, 0);
            PeriodicTab_HeaderPanel.Dock = DockStyle.Fill;
            PeriodicTab_HeaderPanel.Location = new Point(0, 0);
            PeriodicTab_HeaderPanel.Margin = new Padding(0);
            PeriodicTab_HeaderPanel.Name = "PeriodicTab_HeaderPanel";
            PeriodicTab_HeaderPanel.RowCount = 1;
            PeriodicTab_HeaderPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            PeriodicTab_HeaderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            PeriodicTab_HeaderPanel.Size = new Size(774, 43);
            PeriodicTab_HeaderPanel.TabIndex = 6;
            // 
            // PeriodicTab_AddPulse
            // 
            PeriodicTab_AddPulse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            PeriodicTab_AddPulse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PeriodicTab_AddPulse.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            PeriodicTab_AddPulse.Depth = 0;
            PeriodicTab_AddPulse.HighEmphasis = true;
            PeriodicTab_AddPulse.Icon = null;
            PeriodicTab_AddPulse.Location = new Point(4, 6);
            PeriodicTab_AddPulse.Margin = new Padding(4, 6, 4, 6);
            PeriodicTab_AddPulse.MouseState = MaterialSkin.MouseState.HOVER;
            PeriodicTab_AddPulse.Name = "PeriodicTab_AddPulse";
            PeriodicTab_AddPulse.NoAccentTextColor = Color.Empty;
            PeriodicTab_AddPulse.Size = new Size(128, 31);
            PeriodicTab_AddPulse.TabIndex = 0;
            PeriodicTab_AddPulse.Text = "adicionar pulsos";
            PeriodicTab_AddPulse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            PeriodicTab_AddPulse.UseAccentColor = false;
            PeriodicTab_AddPulse.UseVisualStyleBackColor = true;
            PeriodicTab_AddPulse.Click += PeriodicTab_AddPulse_Click;
            // 
            // PeriodicTab_RemovePulse
            // 
            PeriodicTab_RemovePulse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            PeriodicTab_RemovePulse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PeriodicTab_RemovePulse.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            PeriodicTab_RemovePulse.Depth = 0;
            PeriodicTab_RemovePulse.HighEmphasis = true;
            PeriodicTab_RemovePulse.Icon = null;
            PeriodicTab_RemovePulse.Location = new Point(140, 6);
            PeriodicTab_RemovePulse.Margin = new Padding(4, 6, 4, 6);
            PeriodicTab_RemovePulse.MouseState = MaterialSkin.MouseState.HOVER;
            PeriodicTab_RemovePulse.Name = "PeriodicTab_RemovePulse";
            PeriodicTab_RemovePulse.NoAccentTextColor = Color.Empty;
            PeriodicTab_RemovePulse.Size = new Size(122, 31);
            PeriodicTab_RemovePulse.TabIndex = 5;
            PeriodicTab_RemovePulse.Text = "Remover pulsos";
            PeriodicTab_RemovePulse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            PeriodicTab_RemovePulse.UseAccentColor = false;
            PeriodicTab_RemovePulse.UseVisualStyleBackColor = true;
            PeriodicTab_RemovePulse.Click += PeriodicTab_RemovePulse_Click;
            // 
            // PeriodicTab_ConnectBoard
            // 
            PeriodicTab_ConnectBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            PeriodicTab_ConnectBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PeriodicTab_ConnectBoard.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            PeriodicTab_ConnectBoard.Depth = 0;
            PeriodicTab_ConnectBoard.HighEmphasis = true;
            PeriodicTab_ConnectBoard.Icon = null;
            PeriodicTab_ConnectBoard.Location = new Point(270, 6);
            PeriodicTab_ConnectBoard.Margin = new Padding(4, 6, 4, 6);
            PeriodicTab_ConnectBoard.MouseState = MaterialSkin.MouseState.HOVER;
            PeriodicTab_ConnectBoard.Name = "PeriodicTab_ConnectBoard";
            PeriodicTab_ConnectBoard.NoAccentTextColor = Color.Empty;
            PeriodicTab_ConnectBoard.Size = new Size(163, 31);
            PeriodicTab_ConnectBoard.TabIndex = 7;
            PeriodicTab_ConnectBoard.Text = "Conectar com a placa";
            PeriodicTab_ConnectBoard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            PeriodicTab_ConnectBoard.UseAccentColor = false;
            PeriodicTab_ConnectBoard.UseVisualStyleBackColor = true;
            PeriodicTab_ConnectBoard.Click += PeriodicTab_ConnectBoard_Click;
            // 
            // PeriodicTab_SendConfigToBoard
            // 
            PeriodicTab_SendConfigToBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            PeriodicTab_SendConfigToBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PeriodicTab_SendConfigToBoard.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            PeriodicTab_SendConfigToBoard.Depth = 0;
            PeriodicTab_SendConfigToBoard.Enabled = false;
            PeriodicTab_SendConfigToBoard.HighEmphasis = true;
            PeriodicTab_SendConfigToBoard.Icon = null;
            PeriodicTab_SendConfigToBoard.Location = new Point(441, 6);
            PeriodicTab_SendConfigToBoard.Margin = new Padding(4, 6, 4, 6);
            PeriodicTab_SendConfigToBoard.MouseState = MaterialSkin.MouseState.HOVER;
            PeriodicTab_SendConfigToBoard.Name = "PeriodicTab_SendConfigToBoard";
            PeriodicTab_SendConfigToBoard.NoAccentTextColor = Color.Empty;
            PeriodicTab_SendConfigToBoard.Size = new Size(157, 31);
            PeriodicTab_SendConfigToBoard.TabIndex = 8;
            PeriodicTab_SendConfigToBoard.Text = "Enviar Config à placa";
            PeriodicTab_SendConfigToBoard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            PeriodicTab_SendConfigToBoard.UseAccentColor = false;
            PeriodicTab_SendConfigToBoard.UseVisualStyleBackColor = true;
            PeriodicTab_SendConfigToBoard.Click += PeriodicTab_SendConfigToBoard_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.44186F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.55814F));
            tableLayoutPanel2.Controls.Add(cbCurrents, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Location = new Point(602, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(172, 43);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // cbCurrents
            // 
            cbCurrents.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbCurrents.AutoResize = false;
            cbCurrents.BackColor = Color.FromArgb(255, 255, 255);
            cbCurrents.Depth = 0;
            cbCurrents.DrawMode = DrawMode.OwnerDrawVariable;
            cbCurrents.DropDownHeight = 174;
            cbCurrents.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrents.DropDownWidth = 121;
            cbCurrents.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbCurrents.ForeColor = Color.White;
            cbCurrents.FormattingEnabled = true;
            cbCurrents.IntegralHeight = false;
            cbCurrents.ItemHeight = 43;
            cbCurrents.Location = new Point(76, 3);
            cbCurrents.MaxDropDownItems = 4;
            cbCurrents.MouseState = MaterialSkin.MouseState.OUT;
            cbCurrents.Name = "cbCurrents";
            cbCurrents.Size = new Size(93, 49);
            cbCurrents.StartIndex = 0;
            cbCurrents.TabIndex = 11;
            cbCurrents.SelectedIndexChanged += cbCurrents_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(10, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 43);
            label1.TabIndex = 12;
            label1.Text = "Corrente";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PeriodicTab_GridMain
            // 
            PeriodicTab_GridMain.AllowUserToAddRows = false;
            PeriodicTab_GridMain.AllowUserToDeleteRows = false;
            PeriodicTab_GridMain.AllowUserToOrderColumns = true;
            PeriodicTab_GridMain.AllowUserToResizeRows = false;
            PeriodicTab_GridMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PeriodicTab_GridMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PeriodicTab_GridMain.Dock = DockStyle.Fill;
            PeriodicTab_GridMain.Location = new Point(0, 43);
            PeriodicTab_GridMain.Margin = new Padding(0);
            PeriodicTab_GridMain.Name = "PeriodicTab_GridMain";
            PeriodicTab_GridMain.RowTemplate.Height = 25;
            PeriodicTab_GridMain.Size = new Size(774, 158);
            PeriodicTab_GridMain.TabIndex = 1;
            PeriodicTab_GridMain.CellEndEdit += PeriodicTab_GridMain_CellEndEdit;
            PeriodicTab_GridMain.ColumnDataPropertyNameChanged += PeriodicTab_GridMain_ColumnDataPropertyNameChanged;
            PeriodicTab_GridMain.DataError += PeriodicTab_GridMain_DataError;
            // 
            // PeriodicTab_ChartPlotView
            // 
            PeriodicTab_ChartPlotView.Dock = DockStyle.Fill;
            PeriodicTab_ChartPlotView.Location = new Point(3, 204);
            PeriodicTab_ChartPlotView.Name = "PeriodicTab_ChartPlotView";
            PeriodicTab_ChartPlotView.PanCursor = Cursors.Hand;
            PeriodicTab_ChartPlotView.Size = new Size(768, 286);
            PeriodicTab_ChartPlotView.TabIndex = 1;
            PeriodicTab_ChartPlotView.Text = "plotView1";
            PeriodicTab_ChartPlotView.ZoomHorizontalCursor = Cursors.SizeWE;
            PeriodicTab_ChartPlotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            PeriodicTab_ChartPlotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // TabChaotic
            // 
            TabChaotic.Location = new Point(4, 24);
            TabChaotic.Name = "TabChaotic";
            TabChaotic.Padding = new Padding(3);
            TabChaotic.Size = new Size(780, 499);
            TabChaotic.TabIndex = 1;
            TabChaotic.Text = "Caótico";
            TabChaotic.UseVisualStyleBackColor = true;
            // 
            // BrainStimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BrainStimulator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estimulador Cerebral";
            Load += BrainStimulator_Load;
            tableLayoutPanel1.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            TabPeriodic.ResumeLayout(false);
            tbPanel_PeriodicTab.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            PeriodicTab_HeaderPanel.ResumeLayout(false);
            PeriodicTab_HeaderPanel.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PeriodicTab_GridMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage TabPeriodic;
        private TableLayoutPanel tbPanel_PeriodicTab;
        private TabPage TabChaotic;
        private TableLayoutPanel tableLayoutPanel7;
        private DataGridView PeriodicTab_GridMain;
        private TableLayoutPanel PeriodicTab_HeaderPanel;
        private MaterialSkin.Controls.MaterialButton PeriodicTab_RemovePulse;
        private MaterialSkin.Controls.MaterialButton PeriodicTab_AddPulse;
        private MaterialSkin.Controls.MaterialButton PeriodicTab_ConnectBoard;
        private OxyPlot.WindowsForms.PlotView PeriodicTab_ChartPlotView;
        private MaterialSkin.Controls.MaterialButton PeriodicTab_SendConfigToBoard;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialComboBox cbCurrents;
        private Label label1;
    }
}