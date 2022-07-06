using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using FacebookAppLogic.Enums;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    /// <summary>
    /// Facade design pattern implementation.
    /// </summary>
    public sealed class FacebookFacade
    {
        private static FacebookFacade s_FacadeInstance;
        private CustomListCollection m_customListCollection;
        private static object s_Lock = new System.Object();
        private readonly string r_CustomFriendsListPath;
        private readonly FriendStatisticsLogic r_FriendStatisticsLogic;
        /*private List<CustomList> m_UserFriendsCustomLists;*/
        private FriendsSearcherLogic m_FriendsSearcher;

        public event Action<CustomListCollection.CustomFriendsList> NewListAddListener;

        public User User { get; set; }

        /// <summary>
        /// Start of Api section
        /// </summary>
        public List<FriendList> UserCustomListsApi { get; set; }

        public List<User> UserFriendsApi { get; }

  /*      public List<CustomList> UserCustomFriendsLists
        {
            get
            {
                if (m_UserFriendsCustomLists == null)
                {
                    loadCustomFriendLists();
                }

                return m_UserFriendsCustomLists;
            }
        }*/

        public List<FriendItem> UserFriends => GetFakeFriendsFriendItems();

        private FacebookFacade()
        {
            r_FriendStatisticsLogic = new FriendStatisticsLogic(UserFriends);
            r_CustomFriendsListPath = Application.ExecutablePath + @".customLists.xml";
            m_customListCollection = CustomListCollection.GetInstance;
            loadCustomFriendLists();
        }

        // Getter for Facade instance because this Facade also implemented in singletonic way
        public static FacebookFacade FacadeInstance
        {
            get
            {
                if (s_FacadeInstance == null)
                {
                    lock (s_Lock)
                    {
                        if (s_FacadeInstance == null)
                        {
                            s_FacadeInstance = new FacebookFacade();
                        }
                    }
                }

                return s_FacadeInstance;
            }
        }

        // Getter to retrieve the fake data in order to overcome th
        private List<FriendItem> GetFakeFriendsFriendItems()
        {
            string fileName = "DummyData.xml";
            List<FriendItem> friends = new List<FriendItem>();

            if (File.Exists(fileName))
            {
                using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<FriendItem>));

                    friends = (List<FriendItem>)xmlSerializer.Deserialize(stream);
                }
            }

            return friends;
        }

        // First feature
        public Dictionary<string, int> GetStatisticsData(eInfoType i_InfoType, int i_AmountOfResults)
        {
            return r_FriendStatisticsLogic.GetInfo(i_InfoType, i_AmountOfResults);
        }

        /// <summary>
        /// Second feature
        /// </summary>
        /// <param name="i_SearchingParams"> Params which included in order to create new list </param>
        /// <param name="i_Title"> The title of the new list </param>
        public void CreateNewList(Dictionary<eKeys, List<string>> i_SearchingParams, string i_Title)
        {
            m_FriendsSearcher = new FriendsSearcherLogic(i_SearchingParams, this.UserFriends);
            CustomListCollection.CustomFriendsList newCustomFriendsList =
                new CustomListCollection.CustomFriendsList
                { ListName = i_Title,FriendsInList = m_FriendsSearcher.FindFriends() };

            CustomListCollection.GetInstance.Add(newCustomFriendsList);
            /*notify(newCustomFriendsList);*/

            // $API$
            /*   CustomListCollection.Add(
                  new CustomListCollection.CustomFriendsList
            { FriendsApi = m_FriendsSearcher.FindFriendsApi(), ListName = i_Title });*/
        }

        private void notify(CustomListCollection.CustomFriendsList i_NewItem)
        {
            if (NewListAddListener != null)
            {
                NewListAddListener.Invoke(i_NewItem);
            }
        }

        /// <summary>
        /// Saves The Custom lists which was created
        /// </summary>
        public void SaveCustomFriendLists()
        {
            using (FileStream stream = new FileStream(r_CustomFriendsListPath, FileMode.Create))
            {
                List<CustomListCollection.CustomFriendsList> listsToSave =
                    new List<CustomListCollection.CustomFriendsList>();
                IEnumerator enumerator = (CustomListCollection.GetInstance as IEnumerable).GetEnumerator();

                while(enumerator.MoveNext())
                {
                    listsToSave.Add(enumerator.Current as CustomListCollection.CustomFriendsList);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<CustomListCollection.CustomFriendsList>));

                serializer.Serialize(stream, listsToSave);
            }
        }

        private void loadCustomFriendLists()
        {
            /*List<CustomList> userLists = null;*/
            /*m_UserFriendsCustomLists = new List<CustomList>();*/

            if (File.Exists(r_CustomFriendsListPath))
            {
                using (FileStream stream = new FileStream(r_CustomFriendsListPath, FileMode.OpenOrCreate))
                {
                    if (stream.Length != 0)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<CustomListCollection.CustomFriendsList>));
                        List<CustomListCollection.CustomFriendsList> results =
                            (List<CustomListCollection.CustomFriendsList>)serializer.Deserialize(stream);

                        foreach (var item in results)
                        {
                            CustomListCollection.GetInstance.Add(item);
                        }
                    }
                }
            }
        }
    }
}
