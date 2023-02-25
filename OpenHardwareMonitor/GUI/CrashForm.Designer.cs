/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2010 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/


namespace OpenHardwareMonitor.GUI
{
    partial class CrashForm
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
            sendButton=new System.Windows.Forms.Button();
            exitButton=new System.Windows.Forms.Button();
            commentTextBox=new System.Windows.Forms.TextBox();
            titleLabel=new System.Windows.Forms.Label();
            label3=new System.Windows.Forms.Label();
            label1=new System.Windows.Forms.Label();
            commentPanel=new System.Windows.Forms.Panel();
            reportPanel=new System.Windows.Forms.Panel();
            reportTextBox=new System.Windows.Forms.TextBox();
            textBox1=new System.Windows.Forms.TextBox();
            label2=new System.Windows.Forms.Label();
            emailTextBox=new System.Windows.Forms.TextBox();
            commentPanel.SuspendLayout();
            reportPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Right;
            sendButton.Location=new System.Drawing.Point(524, 541);
            sendButton.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            sendButton.Name="sendButton";
            sendButton.Size=new System.Drawing.Size(88, 27);
            sendButton.TabIndex=2;
            sendButton.Text="Send";
            sendButton.UseVisualStyleBackColor=true;
            sendButton.Click+=sendButton_Click;
            // 
            // exitButton
            // 
            exitButton.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Right;
            exitButton.DialogResult=System.Windows.Forms.DialogResult.Cancel;
            exitButton.Location=new System.Drawing.Point(618, 541);
            exitButton.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name="exitButton";
            exitButton.Size=new System.Drawing.Size(88, 27);
            exitButton.TabIndex=3;
            exitButton.Text="Exit";
            exitButton.UseVisualStyleBackColor=true;
            // 
            // commentTextBox
            // 
            commentTextBox.AcceptsReturn=true;
            commentTextBox.BorderStyle=System.Windows.Forms.BorderStyle.None;
            commentTextBox.Dock=System.Windows.Forms.DockStyle.Fill;
            commentTextBox.Location=new System.Drawing.Point(5, 5);
            commentTextBox.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            commentTextBox.Multiline=true;
            commentTextBox.Name="commentTextBox";
            commentTextBox.ScrollBars=System.Windows.Forms.ScrollBars.Vertical;
            commentTextBox.Size=new System.Drawing.Size(684, 88);
            commentTextBox.TabIndex=1;
            // 
            // titleLabel
            // 
            titleLabel.Anchor=System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            titleLabel.BackColor=System.Drawing.SystemColors.Window;
            titleLabel.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            titleLabel.Font=new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            titleLabel.Location=new System.Drawing.Point(-1, -1);
            titleLabel.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            titleLabel.Name="titleLabel";
            titleLabel.Padding=new System.Windows.Forms.Padding(12, 12, 12, 12);
            titleLabel.Size=new System.Drawing.Size(722, 60);
            titleLabel.TabIndex=4;
            titleLabel.Text="Open Hardware Monitor has encountered a problem and needs to close. We are sorry for the inconvenience.";
            // 
            // label3
            // 
            label3.Anchor=System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            label3.AutoEllipsis=true;
            label3.AutoSize=true;
            label3.Location=new System.Drawing.Point(10, 73);
            label3.Margin=new System.Windows.Forms.Padding(4, 14, 4, 9);
            label3.Name="label3";
            label3.Size=new System.Drawing.Size(637, 15);
            label3.TabIndex=5;
            label3.Text="To help diagnose and fix the problem, you can send a crash report. The following report has been created automatically:";
            // 
            // label1
            // 
            label1.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            label1.AutoEllipsis=true;
            label1.AutoSize=true;
            label1.Location=new System.Drawing.Point(10, 400);
            label1.Margin=new System.Windows.Forms.Padding(4, 14, 4, 9);
            label1.Name="label1";
            label1.Size=new System.Drawing.Size(321, 15);
            label1.TabIndex=6;
            label1.Text="You can add additional information to the report (optional):";
            // 
            // commentPanel
            // 
            commentPanel.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            commentPanel.BackColor=System.Drawing.SystemColors.Window;
            commentPanel.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            commentPanel.Controls.Add(commentTextBox);
            commentPanel.Location=new System.Drawing.Point(14, 428);
            commentPanel.Margin=new System.Windows.Forms.Padding(4, 3, 4, 9);
            commentPanel.Name="commentPanel";
            commentPanel.Padding=new System.Windows.Forms.Padding(5, 5, 1, 5);
            commentPanel.Size=new System.Drawing.Size(692, 100);
            commentPanel.TabIndex=1;
            commentPanel.TabStop=true;
            // 
            // reportPanel
            // 
            reportPanel.Anchor=System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            reportPanel.BackColor=System.Drawing.SystemColors.Window;
            reportPanel.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            reportPanel.Controls.Add(reportTextBox);
            reportPanel.Controls.Add(textBox1);
            reportPanel.Location=new System.Drawing.Point(14, 100);
            reportPanel.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            reportPanel.Name="reportPanel";
            reportPanel.Padding=new System.Windows.Forms.Padding(5, 5, 1, 5);
            reportPanel.Size=new System.Drawing.Size(692, 244);
            reportPanel.TabIndex=8;
            // 
            // reportTextBox
            // 
            reportTextBox.BackColor=System.Drawing.SystemColors.Window;
            reportTextBox.BorderStyle=System.Windows.Forms.BorderStyle.None;
            reportTextBox.Dock=System.Windows.Forms.DockStyle.Fill;
            reportTextBox.Location=new System.Drawing.Point(5, 5);
            reportTextBox.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            reportTextBox.Multiline=true;
            reportTextBox.Name="reportTextBox";
            reportTextBox.ReadOnly=true;
            reportTextBox.ScrollBars=System.Windows.Forms.ScrollBars.Vertical;
            reportTextBox.Size=new System.Drawing.Size(684, 232);
            reportTextBox.TabIndex=9;
            reportTextBox.TabStop=false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle=System.Windows.Forms.BorderStyle.None;
            textBox1.Dock=System.Windows.Forms.DockStyle.Fill;
            textBox1.Location=new System.Drawing.Point(5, 5);
            textBox1.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox1.Multiline=true;
            textBox1.Name="textBox1";
            textBox1.Size=new System.Drawing.Size(684, 232);
            textBox1.TabIndex=2;
            // 
            // label2
            // 
            label2.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            label2.AutoEllipsis=true;
            label2.AutoSize=true;
            label2.Location=new System.Drawing.Point(10, 367);
            label2.Margin=new System.Windows.Forms.Padding(4, 14, 4, 9);
            label2.Name="label2";
            label2.Size=new System.Drawing.Size(194, 15);
            label2.TabIndex=9;
            label2.Text="Enter your email address (optional):";
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            emailTextBox.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            emailTextBox.Location=new System.Drawing.Point(219, 363);
            emailTextBox.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            emailTextBox.Name="emailTextBox";
            emailTextBox.Size=new System.Drawing.Size(486, 23);
            emailTextBox.TabIndex=0;
            // 
            // CrashForm
            // 
            AcceptButton=sendButton;
            AutoScaleDimensions=new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            CancelButton=exitButton;
            ClientSize=new System.Drawing.Size(720, 582);
            ControlBox=false;
            Controls.Add(emailTextBox);
            Controls.Add(label2);
            Controls.Add(reportPanel);
            Controls.Add(commentPanel);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(titleLabel);
            Controls.Add(exitButton);
            Controls.Add(sendButton);
            Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox=false;
            MinimizeBox=false;
            Name="CrashForm";
            ShowIcon=false;
            StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Text="Open Hardware Monitor";
            commentPanel.ResumeLayout(false);
            commentPanel.PerformLayout();
            reportPanel.ResumeLayout(false);
            reportPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel commentPanel;
        private System.Windows.Forms.Panel reportPanel;
        private System.Windows.Forms.TextBox reportTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTextBox;
    }
}