namespace SWHXInject
{
    partial class InjectMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InjectMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::SWHXInject.Properties.Resources.beicon;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 175);
            this.panel1.TabIndex = 0;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag .DLL files here to inject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "RunBE \'Di$able\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hook Function Name";
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(324, 70);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(216, 20);
            this.txtFunction.TabIndex = 4;
            this.txtFunction.Text = "HookEvent";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(210, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "For best security, make sure the game is closed before running the injector, and " +
    "place the injector/DLL files on a USB drive.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(212, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 85);
            this.label5.TabIndex = 6;
            this.label5.Text = "Created by Team Invonz.\r\n • Brillen \"InvokeStatic\" Hindenberg\r\n • Jason \"Fonzy\" L" +
    "ambertos\r\n • Doug \"Douggem\" Confere\r\n\r\nSpecial Thanks to Bastian Suter / $able /" +
    " Carlbyte / 16661";
            // 
            // InjectMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 200);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InjectMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunBE - Version \'Di$able\' (1.1)";
            this.Load += new System.EventHandler(this.InjectMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}