
namespace BasicFacebookFeatures
{
    partial class FormEditCustomList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label listNameLabel;
            System.Windows.Forms.Label label1;
            this.customListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelCounter = new System.Windows.Forms.Label();
            this.listNameTextBox = new System.Windows.Forms.TextBox();
            this.friendsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            listNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customListBindingSource)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listNameLabel
            // 
            listNameLabel.AutoSize = true;
            listNameLabel.Location = new System.Drawing.Point(12, 58);
            listNameLabel.Name = "listNameLabel";
            listNameLabel.Size = new System.Drawing.Size(96, 21);
            listNameLabel.TabIndex = 0;
            listNameLabel.Text = "List Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 226);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 21);
            label1.TabIndex = 2;
            label1.Text = "Counter";
            // 
            // customListBindingSource
            // 
            this.customListBindingSource.DataSource = typeof(FacebookAppLogic.CustomList);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.labelCounter);
            this.panelLeft.Controls.Add(label1);
            this.panelLeft.Controls.Add(listNameLabel);
            this.panelLeft.Controls.Add(this.listNameTextBox);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(357, 472);
            this.panelLeft.TabIndex = 1;
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.Location = new System.Drawing.Point(110, 227);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(49, 21);
            this.labelCounter.TabIndex = 3;
            this.labelCounter.Text = "label1";
            // 
            // listNameTextBox
            // 
            this.listNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customListBindingSource, "ListName", true));
            this.listNameTextBox.Location = new System.Drawing.Point(111, 55);
            this.listNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listNameTextBox.Name = "listNameTextBox";
            this.listNameTextBox.Size = new System.Drawing.Size(216, 33);
            this.listNameTextBox.TabIndex = 1;
            // 
            // friendsBindingSource
            // 
            this.friendsBindingSource.DataMember = "Friends";
            this.friendsBindingSource.DataSource = this.customListBindingSource;
            // 
            // friendsListBox
            // 
            this.friendsListBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this.friendsListBox.DataSource = this.friendsBindingSource;
            this.friendsListBox.DisplayMember = "Name";
            this.friendsListBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.ItemHeight = 21;
            this.friendsListBox.Location = new System.Drawing.Point(560, 0);
            this.friendsListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(300, 472);
            this.friendsListBox.TabIndex = 1;
            this.friendsListBox.ValueMember = "Birthday";
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(357, 426);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(203, 46);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormEditCustomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(860, 472);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.friendsListBox);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormEditCustomList";
            this.Text = "Edit List";
            ((System.ComponentModel.ISupportInitialize)(this.customListBindingSource)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource customListBindingSource;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TextBox listNameTextBox;
        private System.Windows.Forms.BindingSource friendsBindingSource;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelCounter;
    }
}