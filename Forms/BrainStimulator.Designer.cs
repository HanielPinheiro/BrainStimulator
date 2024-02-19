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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrainStimulator));
            tableLayoutPanel1 = new TableLayoutPanel();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            TabPeriodic = new TabPage();
            tbPanel_PeriodicTab = new TableLayoutPanel();
            chartPeriodic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel7 = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            btnDeleteRows = new MaterialSkin.Controls.MaterialButton();
            btnAddRows = new MaterialSkin.Controls.MaterialButton();
            PeriodicTab_GridMain = new DataGridView();
            TabChaotic = new TabPage();
            tableLayoutPanel1.SuspendLayout();
            materialTabControl1.SuspendLayout();
            TabPeriodic.SuspendLayout();
            tbPanel_PeriodicTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartPeriodic).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
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
            tbPanel_PeriodicTab.Controls.Add(chartPeriodic, 0, 1);
            tbPanel_PeriodicTab.Controls.Add(tableLayoutPanel7, 0, 0);
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
            chartPeriodic.Location = new Point(0, 201);
            chartPeriodic.Margin = new Padding(0);
            chartPeriodic.Name = "chartPeriodic";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Name = "Pulses";
            chartPeriodic.Series.Add(series1);
            chartPeriodic.Size = new Size(774, 292);
            chartPeriodic.TabIndex = 2;
            chartPeriodic.Text = "chart1";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.43979F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.56021F));
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 0);
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
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222214F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.77778F));
            tableLayoutPanel8.Controls.Add(btnDeleteRows, 0, 0);
            tableLayoutPanel8.Controls.Add(btnAddRows, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Margin = new Padding(0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 49.1017952F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50.8982048F));
            tableLayoutPanel8.Size = new Size(774, 43);
            tableLayoutPanel8.TabIndex = 6;
            // 
            // btnDeleteRows
            // 
            btnDeleteRows.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteRows.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteRows.Depth = 0;
            btnDeleteRows.HighEmphasis = true;
            btnDeleteRows.Icon = null;
            btnDeleteRows.Location = new Point(176, 6);
            btnDeleteRows.Margin = new Padding(4, 6, 4, 6);
            btnDeleteRows.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteRows.Name = "btnDeleteRows";
            btnDeleteRows.NoAccentTextColor = Color.Empty;
            btnDeleteRows.Size = new Size(148, 31);
            btnDeleteRows.TabIndex = 5;
            btnDeleteRows.Text = "Remover pulsos";
            btnDeleteRows.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteRows.UseAccentColor = false;
            btnDeleteRows.UseVisualStyleBackColor = true;
            btnDeleteRows.Click += PeriodicTab_RemovePulse_Click;
            // 
            // btnAddRows
            // 
            btnAddRows.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddRows.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddRows.Depth = 0;
            btnAddRows.HighEmphasis = true;
            btnAddRows.Icon = null;
            btnAddRows.Location = new Point(4, 6);
            btnAddRows.Margin = new Padding(4, 6, 4, 6);
            btnAddRows.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddRows.Name = "btnAddRows";
            btnAddRows.NoAccentTextColor = Color.Empty;
            btnAddRows.Size = new Size(157, 31);
            btnAddRows.TabIndex = 0;
            btnAddRows.Text = "adicionar pulsos";
            btnAddRows.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddRows.UseAccentColor = false;
            btnAddRows.UseVisualStyleBackColor = true;
            btnAddRows.Click += PeriodicTab_AddPulse_Click;
            // 
            // PeriodicTab_GridMain
            // 
            PeriodicTab_GridMain.AllowUserToAddRows = false;
            PeriodicTab_GridMain.AllowUserToDeleteRows = false;
            PeriodicTab_GridMain.AllowUserToOrderColumns = true;
            PeriodicTab_GridMain.AllowUserToResizeRows = false;
            PeriodicTab_GridMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PeriodicTab_GridMain.Dock = DockStyle.Fill;
            PeriodicTab_GridMain.Location = new Point(0, 43);
            PeriodicTab_GridMain.Margin = new Padding(0);
            PeriodicTab_GridMain.Name = "PeriodicTab_GridMain";
            PeriodicTab_GridMain.RowTemplate.Height = 25;
            PeriodicTab_GridMain.Size = new Size(774, 158);
            PeriodicTab_GridMain.TabIndex = 1;
            PeriodicTab_GridMain.DataError += PeriodicTab_GridMain_DataError;
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
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "BrainStimulator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estimulador Cerebral";
            tableLayoutPanel1.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            TabPeriodic.ResumeLayout(false);
            tbPanel_PeriodicTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartPeriodic).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeriodic;
        private TableLayoutPanel tableLayoutPanel8;
        private MaterialSkin.Controls.MaterialButton btnDeleteRows;
        private MaterialSkin.Controls.MaterialButton btnAddRows;
    }
}