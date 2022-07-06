using System;
using System.Windows.Forms;
using FacebookAppLogic;

namespace BasicFacebookFeatures
{
    public partial class FormEditCustomList : Form
    {
        public CustomList FriendsList { get; set; }
        
        private enum eOptions
        {
            Save,
            Close,
        }

        public FormEditCustomList()
        {
            InitializeComponent();
            /*FriendsList = i_CustomList;*/
            listNameTextBox.TextChanged += ListNameTextBox_TextChanged;
            initData();
        }

        private void ListNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (listNameTextBox.Text != FriendsList.ListName)
            {
                buttonSave.Text = eOptions.Save.ToString();
            }
            else
            {
                buttonSave.Text = eOptions.Close.ToString();
            }
        }

        private void initData()
        {
            friendsListBox.DataSource = FriendsList.Friends;
            listNameTextBox.Text = FriendsList.ListName;
            labelCounter.Text = FriendsList.Friends.Count.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (buttonSave.Text == eOptions.Save.ToString())
            {
                DialogResult dialogResult = MessageBox.Show("Save Changes?", "Alert", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    FriendsList.ListName = listNameTextBox.Text;
                }
            }

            this.Dispose();
        }
    }
}
