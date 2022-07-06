using System.Collections.Generic;
using FacebookAppLogic.Enums;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public class FriendsSearcherLogic
    {
        /// Because the FACEBOOK API does not currently support some of the operations we used fake data: a file of fake friends.
        /// The code that uses the FACEBOOK API is add a suffix of "Api"
        /// And the code runs on the fake data in order to display the functionality of the app.
        ///
        // Using fake data (XML File with fake friends)
        // Using the real data (Real facebook friends which you can get when facebook API supports it)
        public Dictionary<eKeys, List<string>> SearchingParams { get; }

        /*public FacebookObjectCollection<User> FittingFriendsApi { get; set; }*/

        public List<FriendItem> FittingFriends { get; set; }

        public List<FriendItem> Friends { get; set; }

        public List<User> FriendsApi { get; set; }

        /*public FacebookObjectCollection<User> UserFriends { get; }*/

        /// <summary>
        /// ctor for Api data;
        /// </summary>
        /// <param name="i_SearchingParams"></param>
        /// <param name="i_UserFriends"> List of current login user friends</param>
        public FriendsSearcherLogic(Dictionary<eKeys, List<string>> i_SearchingParams, List<User> i_UserFriends)
        {
            SearchingParams = i_SearchingParams;
            FriendsApi = i_UserFriends;
        }

        /// <summary>
        /// ctor with dummy data
        /// </summary>
        /// <param name="i_SearchingParams"></param>
        /// <param name="i_Friends"></param>
        public FriendsSearcherLogic(Dictionary<eKeys, List<string>> i_SearchingParams, List<FriendItem> i_Friends)
        {
            SearchingParams = i_SearchingParams;
            Friends = i_Friends;
            FittingFriends = new List<FriendItem>();
        }

        public List<FriendItem> FindFriends()
        {
            foreach (KeyValuePair<eKeys, List<string>> item in SearchingParams)
            {
                if (item.Value.Count > 0)
                {
                    switch (item.Key)
                    {
                        case eKeys.Cities:
                            Friends.RemoveAll((friend) => !item.Value.Contains(friend.City));
                            break;
                        case eKeys.Gender:
                            Friends.RemoveAll((friend) => !item.Value.Contains(friend.Gender));
                            break;
                        case eKeys.Status:
                            Friends.RemoveAll((friend) => !item.Value.Contains(friend.Status));
                            break;
                        case eKeys.Country:
                            Friends.RemoveAll((friend) => !item.Value.Contains(friend.Country));
                            break;
                        case eKeys.Education:
                            Friends.RemoveAll((friend) => !item.Value.Contains(friend.Education));
                            break;
                        case eKeys.Languages:
                            searchByLanguages(Friends, item.Value);
                            break;
                        }
                }
            }

            if(Friends.Count == 0)
            {
                throw new System.Exception(@"Didnt find fitting friends");
            }
            else
            {
                return Friends;
            }
        }

        /// <summary>
        /// Methods for finding data with the api data
        /// </summary>
        /// <returns></returns>
        public List<User> FindFriendsApi()
        {
            foreach (KeyValuePair<eKeys, List<string>> item in SearchingParams)
            {
                if (item.Value.Count > 0)
                {
                    switch (item.Key)
                    {
                        case eKeys.Cities:
                            FriendsApi.RemoveAll((friend) => !item.Value.Contains(friend.Hometown.Location.City));
                            break;
                        case eKeys.Gender:
                            FriendsApi.RemoveAll((friend) => !item.Value.Contains(friend.Gender.Value.ToString()));
                            break;
                        case eKeys.Status:
                            FriendsApi.RemoveAll((friend) => !item.Value.Contains(friend.RelationshipStatus.ToString()));
                            break;
                        case eKeys.Country:
                            FriendsApi.RemoveAll((friend) => !item.Value.Contains(friend.Hometown.Location.Country));
                            break;
                        case eKeys.Education:
                            FriendsApi.RemoveAll((friend) => !item.Value.Contains(friend.Educations[0].School.Name));
                            break;
                        case eKeys.Languages:
                            searchByLanguagesApi(FriendsApi, item.Value);
                            break;
                    }
                }
            }

            return FriendsApi;
        }

        private void searchByLanguages(List<FriendItem> io_FittingFriends, List<string> i_Languages)
        {
            bool isFitting = false;

            if (io_FittingFriends.Count == 0)
            {
                io_FittingFriends = Friends;
                foreach (FriendItem friend in io_FittingFriends)
                {
                    foreach (string lang in friend.Languages)
                    {
                        if (i_Languages.Contains(lang))
                        {
                            isFitting = true;
                            break;
                        }
                    }

                    if (!isFitting)
                    {
                        Friends.Remove(friend);
                    }
                }
            }
            else
            {
                List<FriendItem> currentFittingFriends = new List<FriendItem>(io_FittingFriends);

                foreach (FriendItem fittingFriend in currentFittingFriends)
                {
                    isFitting = false;
                    foreach (var fittingFriendLang in fittingFriend.Languages)
                    {
                        if (i_Languages.Contains(fittingFriendLang))
                        {
                            isFitting = true;
                            break;
                        }
                    }

                    if (!isFitting)
                    {
                        Friends.Remove(fittingFriend);
                    }
                }
            }
        }

        /// <summary>
        /// Related to Api functionality
        /// </summary>
        /// <param name="i_FittingFriends"></param>
        /// <param name="i_Languages"></param>
        private void searchByLanguagesApi(List<User> i_FittingFriends, List<string> i_Languages)
        {
            bool isFitting = false;

            if (i_FittingFriends.Count == 0)
            {
                i_FittingFriends = FriendsApi;
                foreach (User friend in i_FittingFriends)
                {
                    for (int i = 0; i < i_Languages.Count; i++)
                    {
                        if (i_Languages.Contains(i_Languages[i]))
                        {
                            isFitting = true;
                            break;
                        }
                    }

                    if (!isFitting)
                    {
                        FriendsApi.Remove(friend);
                    }
                }
            }
            else
            {
                List<User> currentFittingFriends = new List<User>(i_FittingFriends);

                foreach (User fittingFriend in currentFittingFriends)
                {
                    isFitting = false;
                    foreach (var fittingFriendLang in fittingFriend.Languages)
                    {
                        if (i_Languages.Contains(fittingFriendLang.Name))
                        {
                            isFitting = true;
                            break;
                        }
                    }

                    if (!isFitting)
                    {
                        FriendsApi.Remove(fittingFriend);
                    }
                }
            }
        }
    }
}
