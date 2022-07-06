using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using BasicFacebookFeatures.Properties;
using FacebookAppLogic;
using FacebookAppLogic.Enums;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormTabs : Form, ITitleChangedObserver
    {
        private const string k_TitleUpdatedMsg = "Title Updated";
        private int m_Ticks = 0;

        // $API$
        public List<FriendList> UserCustomListsApi { get; set; }

        public List<CustomListItem> CustomListItems { get; set; }

        public List<User> UserFriendsApi { get; private set; }

        public User User { get; set; }

        public FormTabs()
        {
            User = FacebookFacade.FacadeInstance.User;
            /*setUsersApi();*/
            InitializeComponent();
            CustomListItems = new List<CustomListItem>();
            /*FacebookFacade.FacadeInstance.NewListAddListener += onNewItemAdded;*/
        }

        private void onNewItemAdded(CustomListCollection.CustomFriendsList obj)
        {
            CustomListItem newItem = new CustomListItem(obj);

            newItem.EditFinished += onEditFinished;
            newItem.EditStart += doWhenInEditMode;
            newItem.ReportListWasClicked += OnListClicked;
            newItem.AttachObserver(this);
            CustomListItems.Add(newItem);

        }

        private void OnListClicked(CustomListCollection.CustomFriendsList obj)
        {
            dataGridViewCurrentList.DataSource = obj.FriendsInList;
        }

        private void onEditFinished()
        {
            foreach (var item in flowLayoutLists.Controls)
            {
                if (item is CustomListItem)
                {
                    (item as CustomListItem).Enabled = true;
                }
            }
        }

        private void OnLabelTimerTick(object sender, EventArgs e)
        {
            m_Ticks++;
            if (m_Ticks == 3)
            {
                timerLabel.Stop();
                labelAlert.Visible = false;
            }
        }

        private void doWhenInEditMode(CustomListCollection.CustomFriendsList i_Item)
        {
            foreach (var item in flowLayoutLists.Controls)
            {
                if (item is CustomListItem)
                {
                    if ((item as CustomListItem).CustomListOfFriends != i_Item)
                    {
                        (item as CustomListItem).Enabled = false;
                    }
                }
            }

        }

        private void initCustomListItems()
        {
            IEnumerator enumerator = CustomListCollection.GetInstance.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Invoke(new Action(() =>
                {
                    CustomListItem newList = new CustomListItem(enumerator.Current
                        as CustomListCollection.CustomFriendsList);

                    newList.EditFinished += onEditFinished;
                    newList.EditStart += doWhenInEditMode;
                    newList.ReportListWasClicked += OnListClicked;
                    newList.AttachObserver(this);
                    CustomListItems.Add(newList);
                }));
            }
        }

        private void setUsersApi()
        {
            UserFriendsApi = new List<User>();
            UserCustomListsApi = new List<FriendList>();

            try
            {
                if (User.FriendLists.Count > 0)
                {
                    UserCustomListsApi.AddRange(User.FriendLists);

                    foreach (User user in User.Friends)
                    {
                        UserFriendsApi.Add(user);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while trying to get friends list");
            }
        }

        private void displayBasicUserDataInAboutTab()
        {
            Invoke(new Action(() =>
            {
                userBindingSource.DataSource = FacebookFacade.FacadeInstance.User;
                /*MessageBox.Show(User.Birthday);*/
                DateTime dateOfBirth = Convert.ToDateTime(FacebookFacade.FacadeInstance.User.Birthday);
                DateTime presentYear = DateTime.Now;
                TimeSpan timeSpan = presentYear - dateOfBirth;
                DateTime age = DateTime.MinValue.AddDays(timeSpan.Days);

                pictureBoxProfile.Visible = true;
                groupBoxUserInfo.Visible = true;
                labelUserDate.Text = string.IsNullOrEmpty(FacebookFacade.FacadeInstance.User.Birthday)
                ? string.Empty : FacebookFacade.FacadeInstance.User.Birthday;
                labelUserName.Text = FacebookFacade.FacadeInstance.User.Name;
                labelGender.Text = FacebookFacade.FacadeInstance.User.Gender.ToString();
                labelEmail.Text = FacebookFacade.FacadeInstance.User.Email;
                labelUserLocation.Text = FacebookFacade.FacadeInstance.User.Location.Name;
                labelUserAge.Text = $"{age.Year - 1} years";
                pictureBoxProfile.LoadAsync(FacebookFacade.FacadeInstance.User.PictureNormalURL);
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FacebookFacade.FacadeInstance.SaveCustomFriendLists();
            Application.Exit();
        }

        /*   protected override void OnFormClosed(FormClosedEventArgs e)
           {
               base.OnFormClosed(e);
               Application.Exit();
           }
   */
        private void tabGroups_Enter(object sender, EventArgs e)
        {
            new Thread(fetchGroups).Start();
        }

        private void fetchGroups()
        {
            var groups = FacebookFacade.FacadeInstance.User.Groups;

            listBoxGroups.Invoke(new Action(() =>
            {
                try
                {
                    groupBindingSource.DataSource = groups;
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant get Groups");
                }
            }));
        }

        /// <summary>
        /// This open the friends tab and fiil the data with dummy data,
        /// Beacuse the api cant actually get us all the login user friends.
        /// So, in order to make the app more friednly with data we use this dummy data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabFriends_Enter(object sender, EventArgs e)
        {
            /*List<FriendItem> dummyFriends = FriendItem.GetFakeFriendsFriendItems();*/

            listBoxFriends.DisplayMember = "Name";
            foreach (FriendItem dummyFriend in FacebookFacade.FacadeInstance.UserFriends)
            {
                listBoxFriends.Items.Add(dummyFriend);
            }

            // Api data
            /*
              foreach (User friend in User.Friends)
              {
                  listBoxFriends.Items.Add(friend);
              }*/
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            FriendItem friend = listBoxFriends.SelectedItem as FriendItem;

            textBoxBirthDay.Text = friend.Birthday;
            labelFriendGender.Text = $"Gender: {friend.Gender}";
            labelStatus.Text = $"Status: {friend.Status}";
            labelFriendName.Text = $"Name: {friend.Name}";
            linkLabelPhoneNumber.Text = friend.Phone;
            linkLabelEmailFriend.Text = friend.Email;
            labelCity.Text = $"City: {friend.City}";
            pictureBoxFriend.Image = friend.Gender == eGender.Female.ToString() ? Resources.female1 : Resources.male1;

            // $API$

            /* User friendApi = listBoxFriends.SelectedItem as User;
              User friendApi = listBoxFriends.SelectedItem as User;
            if (friendApi.Birthday != null)
             {
                 textBoxBirthDay.Text = friendApi.Birthday;
             }

             if (friendApi.Gender != null)
             {
                 labelFriendGender.Text = $"Gender: {friendApi.Gender}";
                 pictureBoxFriend.Image = friendApi.Gender.Value.ToString() == eGender.Female.ToString() ? Resources.female1 : Resources.male1;

             }

             if (friendApi.RelationshipStatus != null)
             {
                 labelStatus.Text = $"Status: {friendApi.RelationshipStatus}";
             }
             if (string.IsNullOrEmpty(friendApi.FirstName))
             {
                 labelFriendName.Text = $"Name: {friendApi.Name}";
             }
            */
        }

        private void buttonFriendStatistics_Click(object sender, EventArgs e)
        {
            FormFriendStatistics formFriendStatistics =
                FacebookAppFormFactory.CreateFacebookAppForm(eFormTypes.FormFriendStatistics) as FormFriendStatistics;

            if (formFriendStatistics != null)
            {
                formFriendStatistics.Show();
            }
        }

        /// <summary>
        /// The next method is the the start point of one of the new fetuers we asked to create.
        /// durig all the code who related to the feature we "assume" that code work will the retrived data from
        /// the api. Becasue the api dont working proper. we used Dummpy freind data in xml format which all most
        /// equivalen to the api data, in order to show the functionality of the the feature.
        /// All the code which realavent to ap data are in comments.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewList_Click(object sender, EventArgs e)
        {
            FormCustomListBuilder customListBuilder =
                FacebookAppFormFactory.CreateFacebookAppForm(eFormTypes.FormCustomListBuilder) as FormCustomListBuilder;

            if (customListBuilder != null)
            {
                customListBuilder.ShowDialog();
            }

            tabControl.SelectedTab = tabPageFriendLists;

            // $API$

            /*FormCustomListBuilder customListBuilder = new FormCustomListBuilder(UserFriendsApi, UserCustomListsApi);*/
            /*flowLayoutLists.Controls.Clear();
            flowLayoutLists.FlowDirection = FlowDirection.TopDown;
            foreach (var item in FacebookLogic.UserCustomFriendsLists)
            {
                addNewItemToCustomListsList(item);
            }*/
        }

        private void buttonLoginLogout_Click(object sender, EventArgs e)
        {
            Form loginForm = Application.OpenForms["FormLogin"];

            if (loginForm != null)
            {
                loginForm.Show();
            }
        }

        /*     private void addNewItemToCustomListsList(CustomList i_Item)
             {
                 CustomListItem listItem = new CustomListItem(i_Item);

                 listItem.Click += ButtonShowMe_Click;
                 flowLayoutLists.Controls.Add(listItem);
             }

             private void ButtonShowMe_Click(object sender, EventArgs e)
             {
                 CustomListItem customListItem = sender as CustomListItem;

                 onFriendListSelected(customListItem.CustomListOfFriends);
             }*/

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            /*new Thread(fetchFriendLists).Start();*/
            new Thread(displayBasicUserDataInAboutTab).Start();
            /*new Thread(initCustomListItems).Start();*/
            /*new Thread(loadEvents).Start(); // only for data binding test - need to be removed*/
        }

        private void fetchFriendLists()
        {
            CustomListItems.Clear();
            IEnumerator enumerator = CustomListCollection.GetInstance.GetEnumerator();

            while (enumerator.MoveNext())
            {
                CustomListItem newList = new CustomListItem(enumerator.Current
                    as CustomListCollection.CustomFriendsList);

                newList.EditFinished += onEditFinished;
                newList.EditStart += doWhenInEditMode;
                newList.ReportListWasClicked += OnListClicked;
                newList.AttachObserver(this);

                CustomListItems.Add(newList);
            }

            Invoke(new Action(() =>
            {
                flowLayoutLists.Controls.AddRange(CustomListItems.ToArray());
            }));
        }

    /*    protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            FacebookFacade.FacadeInstance.SaveCustomFriendLists();
        }
*/
        private void fetchLikedPages()
        {
            var pages = FacebookFacade.FacadeInstance.User.LikedPages;

            listBoxLikedPages.Invoke(new Action(() =>
            {
                pageBindingSource.DataSource = pages;
            }));
        }

        private void tabLikedPaged_Enter(object sender, EventArgs e)
        {

            new Thread(fetchLikedPages).Start();
        }

        private void tabPageFriendLists_Enter(object sender, EventArgs e)
        {
            flowLayoutLists.Controls.Clear();

            new Thread(fetchFriendLists).Start();
        }

        public void OnTitleChanged(string i_NewTitle)
        {
            m_Ticks = 0;
            timerLabel.Start();
            labelAlert.Visible = true;
            labelAlert.BackColor = System.Drawing.Color.Red;
            labelAlert.Text = k_TitleUpdatedMsg + i_NewTitle;
        }
    }
}