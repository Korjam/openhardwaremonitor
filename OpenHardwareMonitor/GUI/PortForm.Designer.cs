namespace OpenHardwareMonitor.GUI
{
    partial class PortForm
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
            portOKButton=new System.Windows.Forms.Button();
            portCancelButton=new System.Windows.Forms.Button();
            label1=new System.Windows.Forms.Label();
            label2=new System.Windows.Forms.Label();
            label3=new System.Windows.Forms.Label();
            label4=new System.Windows.Forms.Label();
            webServerLinkLabel=new System.Windows.Forms.LinkLabel();
            portNumericUpDn=new System.Windows.Forms.NumericUpDown();
            label5=new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)portNumericUpDn).BeginInit();
            SuspendLayout();
            // 
            // portOKButton
            // 
            portOKButton.Location=new System.Drawing.Point(285, 158);
            portOKButton.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            portOKButton.Name="portOKButton";
            portOKButton.Size=new System.Drawing.Size(88, 27);
            portOKButton.TabIndex=0;
            portOKButton.Text="OK";
            portOKButton.UseVisualStyleBackColor=true;
            portOKButton.Click+=portOKButton_Click;
            // 
            // portCancelButton
            // 
            portCancelButton.DialogResult=System.Windows.Forms.DialogResult.Cancel;
            portCancelButton.Location=new System.Drawing.Point(189, 158);
            portCancelButton.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            portCancelButton.Name="portCancelButton";
            portCancelButton.Size=new System.Drawing.Size(88, 27);
            portCancelButton.TabIndex=1;
            portCancelButton.Text="Cancel";
            portCancelButton.UseVisualStyleBackColor=true;
            portCancelButton.Click+=portCancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new System.Drawing.Point(15, 122);
            label1.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name="label1";
            label1.Size=new System.Drawing.Size(427, 15);
            label1.TabIndex=3;
            label1.Text="Note: You will need to open the port in firewall settings of the operating system.";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new System.Drawing.Point(15, 10);
            label2.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name="label2";
            label2.Size=new System.Drawing.Size(218, 15);
            label2.TabIndex=4;
            label2.Text="Port number for  the remote web server:";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new System.Drawing.Point(15, 45);
            label3.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name="label3";
            label3.Size=new System.Drawing.Size(495, 15);
            label3.TabIndex=5;
            label3.Text="If the web server is running then it will need to be restarted for the port change to take effect.";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new System.Drawing.Point(15, 72);
            label4.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name="label4";
            label4.Size=new System.Drawing.Size(288, 15);
            label4.TabIndex=6;
            label4.Text="The web server will be accessible from the browser at ";
            // 
            // webServerLinkLabel
            // 
            webServerLinkLabel.AutoSize=true;
            webServerLinkLabel.Location=new System.Drawing.Point(314, 72);
            webServerLinkLabel.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            webServerLinkLabel.Name="webServerLinkLabel";
            webServerLinkLabel.Size=new System.Drawing.Size(60, 15);
            webServerLinkLabel.TabIndex=7;
            webServerLinkLabel.TabStop=true;
            webServerLinkLabel.Text="linkLabel1";
            webServerLinkLabel.LinkClicked+=webServerLinkLabel_LinkClicked;
            // 
            // portNumericUpDn
            // 
            portNumericUpDn.Location=new System.Drawing.Point(243, 8);
            portNumericUpDn.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            portNumericUpDn.Maximum=new decimal(new int[] { 20000, 0, 0, 0 });
            portNumericUpDn.Minimum=new decimal(new int[] { 8080, 0, 0, 0 });
            portNumericUpDn.Name="portNumericUpDn";
            portNumericUpDn.Size=new System.Drawing.Size(88, 23);
            portNumericUpDn.TabIndex=8;
            portNumericUpDn.Value=new decimal(new int[] { 8080, 0, 0, 0 });
            portNumericUpDn.ValueChanged+=portNumericUpDn_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new System.Drawing.Point(15, 97);
            label5.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name="label5";
            label5.Size=new System.Drawing.Size(340, 15);
            label5.TabIndex=9;
            label5.Text="You will have to start the server by clicking Run from the menu.";
            // 
            // PortForm
            // 
            AutoScaleDimensions=new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            CancelButton=portCancelButton;
            ClientSize=new System.Drawing.Size(544, 196);
            Controls.Add(label5);
            Controls.Add(portNumericUpDn);
            Controls.Add(webServerLinkLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(portCancelButton);
            Controls.Add(portOKButton);
            Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox=false;
            MinimizeBox=false;
            Name="PortForm";
            SizeGripStyle=System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition=System.Windows.Forms.FormStartPosition.CenterParent;
            Text="Set Port";
            Load+=PortForm_Load;
            ((System.ComponentModel.ISupportInitialize)portNumericUpDn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button portOKButton;
        private System.Windows.Forms.Button portCancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel webServerLinkLabel;
        private System.Windows.Forms.NumericUpDown portNumericUpDn;
        private System.Windows.Forms.Label label5;
    }
}