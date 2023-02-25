/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2010 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

namespace OpenHardwareMonitor.GUI
{
    partial class ParameterForm
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
            components=new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            okButton=new System.Windows.Forms.Button();
            cancelButton=new System.Windows.Forms.Button();
            captionLabel=new System.Windows.Forms.Label();
            dataGridView=new System.Windows.Forms.DataGridView();
            NameColumn=new System.Windows.Forms.DataGridViewTextBoxColumn();
            Default=new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ValueColumn=new System.Windows.Forms.DataGridViewTextBoxColumn();
            bindingSource=new System.Windows.Forms.BindingSource(components);
            descriptionLabel=new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Right;
            okButton.DialogResult=System.Windows.Forms.DialogResult.OK;
            okButton.Location=new System.Drawing.Point(217, 246);
            okButton.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            okButton.Name="okButton";
            okButton.Size=new System.Drawing.Size(88, 27);
            okButton.TabIndex=2;
            okButton.Text="OK";
            okButton.UseVisualStyleBackColor=true;
            okButton.Click+=okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Right;
            cancelButton.DialogResult=System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location=new System.Drawing.Point(312, 246);
            cancelButton.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            cancelButton.Name="cancelButton";
            cancelButton.Size=new System.Drawing.Size(88, 27);
            cancelButton.TabIndex=3;
            cancelButton.Text="Cancel";
            cancelButton.UseVisualStyleBackColor=true;
            // 
            // captionLabel
            // 
            captionLabel.AutoSize=true;
            captionLabel.Font=new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            captionLabel.Location=new System.Drawing.Point(14, 10);
            captionLabel.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            captionLabel.Name="captionLabel";
            captionLabel.Size=new System.Drawing.Size(80, 13);
            captionLabel.TabIndex=4;
            captionLabel.Text="captionLabel";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows=false;
            dataGridView.AllowUserToDeleteRows=false;
            dataGridView.AllowUserToResizeRows=false;
            dataGridView.Anchor=System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            dataGridView.AutoGenerateColumns=false;
            dataGridView.AutoSizeColumnsMode=System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor=System.Drawing.SystemColors.Window;
            dataGridView.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersHeightSizeMode=System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { NameColumn, Default, ValueColumn });
            dataGridView.DataSource=bindingSource;
            dataGridViewCellStyle2.Alignment=System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor=System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font=new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor=System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor=System.Drawing.Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle2.SelectionForeColor=System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode=System.Windows.Forms.DataGridViewTriState.False;
            dataGridView.DefaultCellStyle=dataGridViewCellStyle2;
            dataGridView.Location=new System.Drawing.Point(18, 35);
            dataGridView.Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridView.MultiSelect=false;
            dataGridView.Name="dataGridView";
            dataGridView.RowHeadersVisible=false;
            dataGridView.SelectionMode=System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ShowRowErrors=false;
            dataGridView.Size=new System.Drawing.Size(382, 140);
            dataGridView.TabIndex=0;
            dataGridView.CellEndEdit+=dataGridView_CellEndEdit;
            dataGridView.CellValidating+=dataGridView_CellValidating;
            dataGridView.CurrentCellDirtyStateChanged+=dataGridView_CurrentCellDirtyStateChanged;
            dataGridView.RowEnter+=dataGridView_RowEnter;
            // 
            // NameColumn
            // 
            NameColumn.DataPropertyName="Name";
            NameColumn.HeaderText="Name";
            NameColumn.Name="NameColumn";
            NameColumn.ReadOnly=true;
            NameColumn.SortMode=System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Default
            // 
            Default.AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            Default.DataPropertyName="Default";
            Default.HeaderText="Default";
            Default.Name="Default";
            Default.Width=51;
            // 
            // ValueColumn
            // 
            ValueColumn.DataPropertyName="Value";
            ValueColumn.HeaderText="Value";
            ValueColumn.Name="ValueColumn";
            ValueColumn.SortMode=System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bindingSource
            // 
            bindingSource.AllowNew=false;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor=System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right;
            descriptionLabel.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            descriptionLabel.Location=new System.Drawing.Point(18, 178);
            descriptionLabel.Margin=new System.Windows.Forms.Padding(4, 0, 4, 0);
            descriptionLabel.Name="descriptionLabel";
            descriptionLabel.Padding=new System.Windows.Forms.Padding(2);
            descriptionLabel.Size=new System.Drawing.Size(381, 57);
            descriptionLabel.TabIndex=6;
            descriptionLabel.Text="descriptionLabel";
            // 
            // ParameterForm
            // 
            AcceptButton=okButton;
            AutoScaleDimensions=new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            ClientSize=new System.Drawing.Size(413, 286);
            Controls.Add(descriptionLabel);
            Controls.Add(dataGridView);
            Controls.Add(captionLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Margin=new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox=false;
            MinimizeBox=false;
            Name="ParameterForm";
            ShowIcon=false;
            ShowInTaskbar=false;
            StartPosition=System.Windows.Forms.FormStartPosition.CenterParent;
            Text="Parameters";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Default;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;

    }
}