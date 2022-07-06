using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FacebookAppLogic;
using FacebookAppLogic.Enums;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormCustomListBuilder : Form
    {
        /// Because the FACEBOOK API does not currently support some of the operations we used fake data: a file of fake friends.
        /// The code that uses the FACEBOOK API is add a suffix of "Api"
        /// And the code runs on the fake data in order to display the functionality of the app.
        /// 
        // Using fake data (XML File with fake friends)
        // Using the real data (Real facebook friends which you can get when facebook API supports it)
        // $API$
        private List<User> UserFriends;

        private FacebookObjectCollection<User> friends;

        public List<FriendList> UserCustomListsApi { get; }

        public Dictionary<eKeys, List<string>> SearchingParams { get; set; }

        public List<FriendItem> Friends { get; set; }

        public List<User> FriendsAPi { get; set; }

        public List<FriendItem> FriendItems { get; }

        public FormCustomListBuilder()
        {
            Friends = FacebookFacade.FacadeInstance.UserFriends;
            SearchingParams = new Dictionary<eKeys, List<string>>();
            InitializeComponent();
        }

        // $API$

        /// <summary>
        /// Related to api functionality
        /// </summary>
        /// <param name="i_Friends"></param>
        /// <param name="i_Lists"></param>
        /*public FormCustomListBuilder()
        {
           *//* UserCustomListsApi = i_Lists;
            UserFriends = i_Friends;*//*
            UserCustomLists = FacebookFacade.FacadeInstance.UserCustomFriendsLists;
            FriendsAPi = FacebookFacade.FacadeInstance.UserFriendsApi;
            SearchingParams = new Dictionary<eKeys, List<string>>();
            InitializeComponent();
        }*/

        private void CustomListBuilder_Load(object sender, EventArgs e)
        {
            List<string> searchingParams = Enum.GetNames(typeof(eKeys)).ToList();

            foreach (var item in searchingParams)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowLayoutPanel1.Controls.Add(checkBox);
            }

            loadCostumeParamsData();

            // $API$
            /*loadCostumeParamsDataApi();*/

            // $remove$
            /* addCities();
             addCountry();
             addEducations();
             addGenders();
             addLanguages();
             addStatuses();*/
        }

        // $API$
        private void loadCostumeParamsDataApi()
        {
            addCitiesApi();
            addCountryApi();
            addEducationsApi();
            addGenders();
            addLanguagesApi();
            addStatusesApi();
        }

        private void loadCostumeParamsData()
        {
            addCities();
            addCountry();
            addEducations();
            addGenders();
            addLanguages();
            addStatuses();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxClicked = sender as CheckBox;

            if(checkBoxClicked != null)
            {
                checkBoxClicked.Enabled = true;
                if(Enum.IsDefined(typeof(eKeys), checkBoxClicked.Text))
                {
                    eKeys selectedParam = (eKeys)Enum.Parse(typeof(eKeys), checkBoxClicked.Text);

                    switch(selectedParam)
                    {
                        case eKeys.Gender:
                            checkedListBoxGender.Enabled = !checkedListBoxGender.Enabled;
                            break;
                        case eKeys.Cities:
                            checkedListBoxCity.Enabled = !checkedListBoxCity.Enabled;
                            break;
                        case eKeys.Country:
                            checkedListBoxCountry.Enabled = !checkedListBoxCountry.Enabled;
                            break;
                        case eKeys.Status:
                            checkedListBoxStatuses.Enabled = !checkedListBoxStatuses.Enabled;
                            break;
                        case eKeys.Education:
                            checkedListBoxCollege.Enabled = !checkedListBoxCollege.Enabled;
                            break;
                        case eKeys.Languages:
                            checkedListBoxLang.Enabled = !checkedListBoxLang.Enabled;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void addGenders()
        {
            SearchingParams.Add(eKeys.Gender, new List<string>());
            List<string> genders = Enum.GetNames(typeof(eGender)).ToList();

            checkedListBoxGender.Items.AddRange(genders.ToArray());
        }

        private void addCountry()
        {
            SearchingParams.Add(eKeys.Country, new List<string>());
            foreach (var friend in Friends)
            {
                if (!string.IsNullOrEmpty(friend.Country))
                {
                    if (!checkedListBoxCountry.Items.Contains(friend.Country))
                    {
                        checkedListBoxCountry.Items.Add(friend.Country);
                    }
                }
            }
        }

        private void addCities()
        {
            SearchingParams.Add(eKeys.Cities, new List<string>());
            foreach (var friend in Friends)
            {
                if (!string.IsNullOrEmpty(friend.City))
                {
                    if (!checkedListBoxCity.Items.Contains(friend.City))
                    {
                        checkedListBoxCity.Items.Add(friend.City);
                    }
                }
            }
        }

        private void addEducations()
        {
            SearchingParams.Add(eKeys.Education, new List<string>());
            foreach (FriendItem friend in Friends)
            {
                if (!string.IsNullOrEmpty(friend.Education))
                {
                    if (!checkedListBoxCollege.Items.Contains(friend.Education))
                    {
                        checkedListBoxCollege.Items.Add(friend.Education);
                    }
                }
            }
        }

        private void addStatuses()
        {
            SearchingParams.Add(eKeys.Status, new List<string>());
            foreach (FriendItem friend in Friends)
            {
                if (!string.IsNullOrEmpty(friend.Status))
                {
                    if (!checkedListBoxStatuses.Items.Contains(friend.Status))
                    {
                        checkedListBoxStatuses.Items.Add(friend.Status);
                    }
                }
            }
        }

        private void addLanguages()
        {
            SearchingParams.Add(eKeys.Languages, new List<string>());
            foreach (var friend in Friends)
            {
                foreach (var language in friend.Languages)
                {
                    if (!string.IsNullOrEmpty(language))
                    {
                        if (!checkedListBoxLang.Items.Contains(language))
                        {
                            checkedListBoxLang.Items.Add(language);
                        }
                    }
                }
            }
        }

        private void addCountryApi()
        {
            foreach (var friend in UserFriends)
            {
                if (friend.Hometown != null)
                {
                    if (!string.IsNullOrEmpty(friend.Hometown.Location.Country))
                    {
                        if (!checkedListBoxCountry.Items.Contains(friend.Hometown.Location.Country))
                        {
                            checkedListBoxCountry.Items.Add(friend.Hometown.Location.Country);
                        }
                    }
                }
            }
        }

        private void addCitiesApi()
        {
            SearchingParams.Add(eKeys.Cities, new List<string>());
            foreach (User friend in UserFriends)
            {
                try
                {
                    if (friend.Hometown != null)
                    {
                        if (!string.IsNullOrEmpty(friend.Hometown.Location.City))
                        {
                            if (!checkedListBoxCity.Items.Contains(friend.Hometown.Location.City))
                            {
                                checkedListBoxCity.Items.Add(friend.Hometown.Location.City);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error in get City");
                }
            }
        }

        private void addEducationsApi()
        {
            SearchingParams.Add(eKeys.Education, new List<string>());
            foreach (User friend in UserFriends)
            {
                if (friend.Educations != null)
                {
                    if (!string.IsNullOrEmpty(friend.Educations[0].School.Name))
                    {
                        if (!checkedListBoxCollege.Items.Contains(friend.Educations[0].School.Name))
                        {
                            checkedListBoxCollege.Items.Add(friend.Educations[0].School.Name);
                        }
                    }
                }
            }
        }

        private void addStatusesApi()
        {
            SearchingParams.Add(eKeys.Status, new List<string>());
            foreach (User friend in UserFriends)
            {
                if (friend.RelationshipStatus != null)
                {
                    if (!string.IsNullOrEmpty(friend.RelationshipStatus.Value.ToString()))
                    {
                        if (!checkedListBoxStatuses.Items.Contains(friend.RelationshipStatus.Value.ToString()))
                        {
                            checkedListBoxStatuses.Items.Add(friend.RelationshipStatus.Value.ToString());
                        }
                    }
                }
            }
        }

        private void addLanguagesApi()
        {
            SearchingParams.Add(eKeys.Languages, new List<string>());
            foreach (User friend in UserFriends)
            {
                if (friend.Languages != null)
                {
                    foreach (Page language in friend.Languages)
                    {
                        if (!string.IsNullOrEmpty(language.Name))
                        {
                            if (!checkedListBoxLang.Items.Contains(language.Name))
                            {
                                checkedListBoxLang.Items.Add(language.Name);
                            }
                        }
                    }
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxGender.CheckedItems)
            {
                SearchingParams[eKeys.Gender].Add(item.ToString());
            }

            foreach (var item in checkedListBoxCity.CheckedItems)
            {
                SearchingParams[eKeys.Cities].Add(item.ToString());
            }

            foreach (var item in checkedListBoxStatuses.CheckedItems)
            {
                SearchingParams[eKeys.Status].Add(item.ToString());
            }

            foreach (var item in checkedListBoxCountry.CheckedItems)
            {
                SearchingParams[eKeys.Country].Add(item.ToString());
            }

            foreach (var item in checkedListBoxCollege.CheckedItems)
            {
                SearchingParams[eKeys.Education].Add(item.ToString());
            }

            foreach (var item in checkedListBoxLang.CheckedItems)
            {
                SearchingParams[eKeys.Languages].Add(item.ToString());
            }

            FacebookFacade.FacadeInstance.CreateNewList(SearchingParams, textBoxListName.Text);
            this.Close();

            /*createList();*/

            // $API$
            /*createListApi();*/
        }

        // $API$
      /*  private void createListApi()
        {
            FriendsSearcherLogic searcher = new FriendsSearcherLogic(SearchingParams, UserFriends);
            List<User> friendItems = searcher.FindFriendsApi();

            if (friendItems.Count > 0)
            {
                addNewListAPI(friendItems);
            }
            else
            {
                MessageBox.Show(@"No matching Friends");
            }

            this.Close();
        }*/

        // $API$
        /*private void addNewListAPI(List<User> i_FriendItems)
        {
            if (string.IsNullOrEmpty(textBoxListName.Text))
            {
                MessageBox.Show(@"Please name the list");
            }
            else
            {
                *//*CustomList customList = new CustomList(i_FriendItems, textBoxListName.Text);*//*
                FriendList friendList = new FriendList();

                friendList.Name = textBoxListName.Text;

                foreach (User user in i_FriendItems)
                {
                    friendList.m_Members.Add(user);
                }

                UserCustomListsApi.Add(friendList);
            }
        }*/

        /// <summary>
        /// makes button visible only when the text box is fill with title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxListName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxListName.Text.Length > 0)
            {
                buttonCreate.Enabled = true;
                labelsAlert.Visible = false;
            }
            else
            {
                buttonCreate.Enabled = false;
                labelsAlert.Visible = true;
            }
        }
    }
}