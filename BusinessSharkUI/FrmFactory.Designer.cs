namespace BusinessSharkUI
{
    partial class FrmFactory
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
            factoryPropertyGrid = new PropertyGrid();
            SuspendLayout();
            // 
            // factoryPropertyGrid
            // 
            factoryPropertyGrid.BackColor = SystemColors.Control;
            factoryPropertyGrid.Dock = DockStyle.Fill;
            factoryPropertyGrid.Location = new Point(0, 0);
            factoryPropertyGrid.Name = "factoryPropertyGrid";
            factoryPropertyGrid.Size = new Size(800, 450);
            factoryPropertyGrid.TabIndex = 0;
            // 
            // FrmFactory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(factoryPropertyGrid);
            Name = "FrmFactory";
            Text = "FrmFactory";
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid factoryPropertyGrid;
    }
}