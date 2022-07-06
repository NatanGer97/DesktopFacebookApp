namespace BasicFacebookFeatures
{
    partial class FormCustomListBuilder
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
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxListName = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxLanguages = new System.Windows.Forms.GroupBox();
            this.checkedListBoxLang = new System.Windows.Forms.CheckedListBox();
            this.groupBoxCountry = new System.Windows.Forms.GroupBox();
            this.checkedListBoxCountry = new System.Windows.Forms.CheckedListBox();
            this.groupBoxCities = new System.Windows.Forms.GroupBox();
            this.checkedListBoxCity = new System.Windows.Forms.CheckedListBox();
            this.groupBoxColleges = new System.Windows.Forms.GroupBox();
            this.checkedListBoxCollege = new System.Windows.Forms.CheckedListBox();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.checkedListBoxStatuses = new System.Windows.Forms.CheckedListBox();
            this.groupBoxGender = new System.Windows.Forms.GroupBox();
            this.checkedListBoxGender = new System.Windows.Forms.CheckedListBox();
            this.labelsAlert = new System.Windows.Forms.Label();
            this.groupBoxParams.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxLanguages.SuspendLayout();
            this.groupBoxCountry.SuspendLayout();
            this.groupBoxCities.SuspendLayout();
            this.groupBoxColleges.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.groupBoxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxParams.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxParams.Location = new System.Drawing.Point(0, 0);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Size = new System.Drawing.Size(268, 597);
            this.groupBoxParams.TabIndex = 2;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "Parameters";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 508);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelsAlert);
            this.panel1.Controls.Add(this.textBoxListName);
            this.panel1.Controls.Add(this.buttonCreate);
            this.panel1.Controls.Add(this.groupBoxLanguages);
            this.panel1.Controls.Add(this.groupBoxCountry);
            this.panel1.Controls.Add(this.groupBoxCities);
            this.panel1.Controls.Add(this.groupBoxColleges);
            this.panel1.Controls.Add(this.groupBoxStatus);
            this.panel1.Controls.Add(this.groupBoxGender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(268, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 597);
            this.panel1.TabIndex = 3;
            // 
            // textBoxListName
            // 
            this.textBoxListName.Location = new System.Drawing.Point(409, 433);
            this.textBoxListName.Name = "textBoxListName";
            this.textBoxListName.Size = new System.Drawing.Size(337, 26);
            this.textBoxListName.TabIndex = 10;
            this.textBoxListName.TextChanged += new System.EventHandler(this.textBoxListName_TextChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Enabled = false;
            this.buttonCreate.Location = new System.Drawing.Point(829, 430);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 29);
            this.buttonCreate.TabIndex = 9;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBoxLanguages
            // 
            this.groupBoxLanguages.Controls.Add(this.checkedListBoxLang);
            this.groupBoxLanguages.Location = new System.Drawing.Point(518, 15);
            this.groupBoxLanguages.Name = "groupBoxLanguages";
            this.groupBoxLanguages.Size = new System.Drawing.Size(316, 169);
            this.groupBoxLanguages.TabIndex = 8;
            this.groupBoxLanguages.TabStop = false;
            this.groupBoxLanguages.Text = "Languages";
            // 
            // checkedListBoxLang
            // 
            this.checkedListBoxLang.Enabled = false;
            this.checkedListBoxLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkedListBoxLang.FormattingEnabled = true;
            this.checkedListBoxLang.Location = new System.Drawing.Point(16, 29);
            this.checkedListBoxLang.Name = "checkedListBoxLang";
            this.checkedListBoxLang.Size = new System.Drawing.Size(282, 58);
            this.checkedListBoxLang.TabIndex = 3;
            // 
            // groupBoxCountry
            // 
            this.groupBoxCountry.Controls.Add(this.checkedListBoxCountry);
            this.groupBoxCountry.Location = new System.Drawing.Point(6, 203);
            this.groupBoxCountry.Name = "groupBoxCountry";
            this.groupBoxCountry.Size = new System.Drawing.Size(374, 142);
            this.groupBoxCountry.TabIndex = 5;
            this.groupBoxCountry.TabStop = false;
            this.groupBoxCountry.Text = "Country";
            // 
            // checkedListBoxCountry
            // 
            this.checkedListBoxCountry.Enabled = false;
            this.checkedListBoxCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkedListBoxCountry.FormattingEnabled = true;
            this.checkedListBoxCountry.Location = new System.Drawing.Point(15, 28);
            this.checkedListBoxCountry.Name = "checkedListBoxCountry";
            this.checkedListBoxCountry.Size = new System.Drawing.Size(324, 50);
            this.checkedListBoxCountry.TabIndex = 2;
            // 
            // groupBoxCities
            // 
            this.groupBoxCities.AutoSize = true;
            this.groupBoxCities.Controls.Add(this.checkedListBoxCity);
            this.groupBoxCities.Location = new System.Drawing.Point(518, 208);
            this.groupBoxCities.Name = "groupBoxCities";
            this.groupBoxCities.Size = new System.Drawing.Size(330, 145);
            this.groupBoxCities.TabIndex = 6;
            this.groupBoxCities.TabStop = false;
            this.groupBoxCities.Text = "Cities";
            // 
            // checkedListBoxCity
            // 
            this.checkedListBoxCity.Enabled = false;
            this.checkedListBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkedListBoxCity.FormattingEnabled = true;
            this.checkedListBoxCity.Location = new System.Drawing.Point(18, 25);
            this.checkedListBoxCity.Name = "checkedListBoxCity";
            this.checkedListBoxCity.ScrollAlwaysVisible = true;
            this.checkedListBoxCity.Size = new System.Drawing.Size(298, 50);
            this.checkedListBoxCity.TabIndex = 1;
            // 
            // groupBoxColleges
            // 
            this.groupBoxColleges.Controls.Add(this.checkedListBoxCollege);
            this.groupBoxColleges.Location = new System.Drawing.Point(6, 368);
            this.groupBoxColleges.Name = "groupBoxColleges";
            this.groupBoxColleges.Size = new System.Drawing.Size(339, 137);
            this.groupBoxColleges.TabIndex = 7;
            this.groupBoxColleges.TabStop = false;
            this.groupBoxColleges.Text = "College";
            // 
            // checkedListBoxCollege
            // 
            this.checkedListBoxCollege.Enabled = false;
            this.checkedListBoxCollege.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkedListBoxCollege.FormattingEnabled = true;
            this.checkedListBoxCollege.Location = new System.Drawing.Point(22, 26);
            this.checkedListBoxCollege.Name = "checkedListBoxCollege";
            this.checkedListBoxCollege.Size = new System.Drawing.Size(300, 73);
            this.checkedListBoxCollege.TabIndex = 2;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.checkedListBoxStatuses);
            this.groupBoxStatus.Location = new System.Drawing.Point(250, 15);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(248, 169);
            this.groupBoxStatus.TabIndex = 6;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // checkedListBoxStatuses
            // 
            this.checkedListBoxStatuses.Enabled = false;
            this.checkedListBoxStatuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checkedListBoxStatuses.FormattingEnabled = true;
            this.checkedListBoxStatuses.Location = new System.Drawing.Point(14, 34);
            this.checkedListBoxStatuses.Name = "checkedListBoxStatuses";
            this.checkedListBoxStatuses.Size = new System.Drawing.Size(211, 73);
            this.checkedListBoxStatuses.TabIndex = 0;
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Controls.Add(this.checkedListBoxGender);
            this.groupBoxGender.Location = new System.Drawing.Point(6, 12);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(224, 172);
            this.groupBoxGender.TabIndex = 4;
            this.groupBoxGender.TabStop = false;
            this.groupBoxGender.Text = "Gender";
            // 
            // checkedListBoxGender
            // 
            this.checkedListBoxGender.CheckOnClick = true;
            this.checkedListBoxGender.Enabled = false;
            this.checkedListBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkedListBoxGender.FormattingEnabled = true;
            this.checkedListBoxGender.Location = new System.Drawing.Point(20, 26);
            this.checkedListBoxGender.Name = "checkedListBoxGender";
            this.checkedListBoxGender.Size = new System.Drawing.Size(170, 73);
            this.checkedListBoxGender.TabIndex = 3;
            // 
            // labelsAlert
            // 
            this.labelsAlert.AutoSize = true;
            this.labelsAlert.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsAlert.ForeColor = System.Drawing.Color.DarkRed;
            this.labelsAlert.Location = new System.Drawing.Point(427, 406);
            this.labelsAlert.Name = "labelsAlert";
            this.labelsAlert.Size = new System.Drawing.Size(92, 24);
            this.labelsAlert.TabIndex = 11;
            this.labelsAlert.Text = "required!";
            this.labelsAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCustomListBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 597);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxParams);
            this.Name = "FormCustomListBuilder";
            this.Text = "FormCustomListBuilder";
            this.Load += new System.EventHandler(this.CustomListBuilder_Load);
            this.groupBoxParams.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxLanguages.ResumeLayout(false);
            this.groupBoxCountry.ResumeLayout(false);
            this.groupBoxCities.ResumeLayout(false);
            this.groupBoxColleges.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxGender.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.GroupBox groupBoxLanguages;
        private System.Windows.Forms.GroupBox groupBoxCities;
        private System.Windows.Forms.GroupBox groupBoxColleges;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxCountry;
        private System.Windows.Forms.CheckedListBox checkedListBoxLang;
        private System.Windows.Forms.CheckedListBox checkedListBoxCity;
        private System.Windows.Forms.CheckedListBox checkedListBoxCollege;
        private System.Windows.Forms.CheckedListBox checkedListBoxStatuses;
        private System.Windows.Forms.CheckedListBox checkedListBoxCountry;
        private System.Windows.Forms.CheckedListBox checkedListBoxGender;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxListName;
        private System.Windows.Forms.Label labelsAlert;
    }
}