namespace BasicFacebookFeatures
{
    partial class CustomListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCounter = new System.Windows.Forms.Label();
            this.textBoxListName = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.Enabled = false;
            this.labelCounter.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.labelCounter.Location = new System.Drawing.Point(2, 68);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(71, 24);
            this.labelCounter.TabIndex = 1;
            this.labelCounter.Text = "Amount:";
            // 
            // textBoxListName
            // 
            this.textBoxListName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxListName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxListName.Enabled = false;
            this.textBoxListName.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.textBoxListName.Location = new System.Drawing.Point(21, 26);
            this.textBoxListName.Name = "textBoxListName";
            this.textBoxListName.ReadOnly = true;
            this.textBoxListName.Size = new System.Drawing.Size(100, 27);
            this.textBoxListName.TabIndex = 2;
            this.textBoxListName.Text = "List Name";
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonEdit.BackgroundImage = global::BasicFacebookFeatures.Properties.Resources.edit;
            this.buttonEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEdit.Location = new System.Drawing.Point(170, 27);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(42, 44);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSave.BackgroundImage = global::BasicFacebookFeatures.Properties.Resources.save;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSave.Location = new System.Drawing.Point(170, 27);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(42, 44);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // CustomListItem
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxListName);
            this.Controls.Add(this.labelCounter);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.Name = "CustomListItem";
            this.Size = new System.Drawing.Size(234, 103);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCounter;
        private System.Windows.Forms.TextBox textBoxListName;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSave;
    }
}
