﻿namespace chessy
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bishop_B.png");
            this.imageList1.Images.SetKeyName(1, "bishop_W.png");
            this.imageList1.Images.SetKeyName(2, "king_B.png");
            this.imageList1.Images.SetKeyName(3, "king_W.png");
            this.imageList1.Images.SetKeyName(4, "knight_B.png");
            this.imageList1.Images.SetKeyName(5, "knight_W.png");
            this.imageList1.Images.SetKeyName(6, "pawn_B.png");
            this.imageList1.Images.SetKeyName(7, "pawn_W.png");
            this.imageList1.Images.SetKeyName(8, "queen_B.png");
            this.imageList1.Images.SetKeyName(9, "queen_W.png");
            this.imageList1.Images.SetKeyName(10, "rook_B.png");
            this.imageList1.Images.SetKeyName(11, "rook_W.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 663);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        public ImageList imageList1;
    }
}