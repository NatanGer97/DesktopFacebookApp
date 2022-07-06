using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    partial class FormFriendStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonGetStats = new System.Windows.Forms.Button();
            this.chartColumn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBoxOptions = new System.Windows.Forms.ListBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanelCharts.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetStats
            // 
            this.buttonGetStats.Location = new System.Drawing.Point(12, 451);
            this.buttonGetStats.Name = "buttonGetStats";
            this.buttonGetStats.Size = new System.Drawing.Size(382, 143);
            this.buttonGetStats.TabIndex = 0;
            this.buttonGetStats.Text = "Get Statistics";
            this.buttonGetStats.UseVisualStyleBackColor = true;
            this.buttonGetStats.Click += new System.EventHandler(this.buttonGetStats_Click);
            // 
            // chartColumn
            // 
            this.chartColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartColumn.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartColumn.Legends.Add(legend1);
            this.chartColumn.Location = new System.Drawing.Point(3, 3);
            this.chartColumn.Name = "chartColumn";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartColumn.Series.Add(series1);
            this.chartColumn.Size = new System.Drawing.Size(1005, 903);
            this.chartColumn.TabIndex = 1;
            this.chartColumn.Text = "chart1";
            // 
            // chartPie
            // 
            this.chartPie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPie.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPie.Legends.Add(legend2);
            this.chartPie.Location = new System.Drawing.Point(1014, 3);
            this.chartPie.Name = "chartPie";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.LabelAngle = 45;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPie.Series.Add(series2);
            this.chartPie.Size = new System.Drawing.Size(1006, 903);
            this.chartPie.TabIndex = 3;
            this.chartPie.Text = "chart2";
            // 
            // listBoxOptions
            // 
            this.listBoxOptions.FormattingEnabled = true;
            this.listBoxOptions.ItemHeight = 31;
            this.listBoxOptions.Location = new System.Drawing.Point(13, 12);
            this.listBoxOptions.Name = "listBoxOptions";
            this.listBoxOptions.Size = new System.Drawing.Size(381, 283);
            this.listBoxOptions.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 614);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(381, 297);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // tableLayoutPanelCharts
            // 
            this.tableLayoutPanelCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelCharts.ColumnCount = 2;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Controls.Add(this.chartColumn, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartPie, 1, 0);
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(426, 12);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.RowCount = 1;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(2023, 909);
            this.tableLayoutPanelCharts.TabIndex = 6;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(13, 302);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(381, 38);
            this.textBoxAmount.TabIndex = 7;
            this.textBoxAmount.Text = "Enter the amount of results";
            this.textBoxAmount.Click += new System.EventHandler(this.textBoxAmount_Click);
            // 
            // FormFriendStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2461, 923);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.tableLayoutPanelCharts);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.listBoxOptions);
            this.Controls.Add(this.buttonGetStats);
            this.Name = "FormFriendStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFriendStatistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanelCharts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.ListBox listBoxOptions;
        private PictureBox pictureBox;
        private TableLayoutPanel tableLayoutPanelCharts;
        private TextBox textBoxAmount;
    }
}