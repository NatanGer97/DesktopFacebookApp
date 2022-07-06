using System;
using System.Collections;
using System.Collections.Generic;

namespace FacebookAppLogic
{
    public sealed class CustomListCollection : IEnumerable<CustomListCollection.CustomFriendsList>
    {
        private static CustomListCollection s_CustomListCollection;
        private List<CustomFriendsList> m_UserFriendsList;

        private CustomListCollection()
        {
            m_UserFriendsList = new List<CustomFriendsList>();
        }

        public void Add(CustomFriendsList i_CustomFriendsList)
        {
            m_UserFriendsList.Add(
                new CustomFriendsList
                {
                    FriendsInList = i_CustomFriendsList.FriendsInList,
                    ListName = i_CustomFriendsList.ListName,
                });
        }

        public IEnumerator<CustomFriendsList> GetEnumerator()
        {
            return ((IEnumerable<CustomFriendsList>)m_UserFriendsList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_UserFriendsList).GetEnumerator();
        }

        /* public List<CustomFriendsList> GetItems()
         {
             return m_UserFriendsList;
         }*/

        public static CustomListCollection GetInstance
        {
            get
            {
                if (s_CustomListCollection == null)
                {
                    s_CustomListCollection = new CustomListCollection();
                }

                return s_CustomListCollection;
            }
        }

        public class CustomFriendsList
        {
            public List<FriendItem> FriendsInList { get; set; }

            public string ListName { get; set; }

            /// <summary>
            /// $API$
            /// </summary>
            /// public List<FacebookWrapper.ObjectModel.User> FriendsApi { get; set; }
            /// <summary>
            ///
            /// $API$
            /// </summary>
            /// <param name="i_ListFriends"></param>
            /// <param name="i_ListName"></param>
            ///
            /*public CustomFriendsList(List<FacebookWrapper.ObjectModel.User> i_ListFriends, string i_ListName)
            {
                FriendsApi = i_ListFriends;
                ListName = i_ListName;
            }*/
            public CustomFriendsList()
            {
            }
        }
    }
}
