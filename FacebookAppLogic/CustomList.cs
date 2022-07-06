using System.Collections;
using System.Collections.Generic;

namespace FacebookAppLogic
{
    public class CustomList
    {
        public List<FriendItem> Friends { get; set; }

        public string ListName { get; set; }

        /// <summary>
        /// $API$
        /// </summary>
        /// public List<FacebookWrapper.ObjectModel.User> FriendsApi { get; set; }
        /// <summary>
        /// $API$
        /// </summary>
        /// <param name="i_ListFriends"></param>
        /// <param name="i_ListName"></param>
        /*public CustomList(List<FacebookWrapper.ObjectModel.User> i_ListFriends, string i_ListName)
        {
            FriendsApi = i_ListFriends;
            ListName = i_ListName;
        }*/
        /// <summary>
        /// Dummy Data
        /// </summary>
        /// <param name="i_ListFriends"></param>
        /// <param name="i_ListName"></param>
  /*      public CustomList(List<FriendItem> i_ListFriends, string i_ListName)
        {
            Friends = i_ListFriends;
            ListName = i_ListName;
        }*/

        public CustomList()
        {
        }

        public IEnumerator GetEnumerator()
        {
            return Friends.GetEnumerator();
        }
    }
}