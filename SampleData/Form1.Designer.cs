namespace Project
{
    partial class Soil
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.map1 = new DotSpatial.Controls.Map();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Layer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Remove Layer";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "Zoom In";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(219, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "Zoom Out";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(288, 39);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 52);
            this.button5.TabIndex = 4;
            this.button5.Text = "Draw Line";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(357, 39);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(63, 52);
            this.button6.TabIndex = 5;
            this.button6.Text = "Draw Polyline";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // spatialToolStrip1
            // 
            this.spatialToolStrip1.ApplicationManager = null;
            this.spatialToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.spatialToolStrip1.Map = null;
            this.spatialToolStrip1.Name = "spatialToolStrip1";
            this.spatialToolStrip1.Size = new System.Drawing.Size(826, 25);
            this.spatialToolStrip1.TabIndex = 6;
            this.spatialToolStrip1.Text = "spatialToolStrip1";
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = null;
            this.map1.Location = new System.Drawing.Point(199, 122);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = null;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(616, 433);
            this.map1.TabIndex = 7;
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 187, 433);
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(6, 122);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(187, 433);
            this.legend1.TabIndex = 8;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // Soil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 570);
            this.Controls.Add(this.legend1);
            this.Controls.Add(this.map1);
            this.Controls.Add(this.spatialToolStrip1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Soil";
            this.Text = "Soil Profiler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private DotSpatial.Controls.SpatialToolStrip spatialToolStrip1;
        private DotSpatial.Controls.Map map1;
        private DotSpatial.Controls.Legend legend1;
    }
}

