using System;
using System.Collections.Generic;
using FacebookAppLogic.Enums;

namespace FacebookAppLogic.Strategy
{
    internal class FriendPopularityStatistics : IStatisticsStrategy
    {
        /// <summary>
        /// Counts the amount of friends each of your friends has and assign them
        /// to 5 categories : 1.Very popular (more than 5000 friends)
        ///                   2.Popular (2000 - 5000 friends)
        ///                   3.Known (1000 - 2000 friends)
        ///                   4.Normal (100 - 1000 friends)
        ///                   5.Unpopular (1 - 100 friends)
        /// and show statistical information about them.
        /// </summary>
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Dictionary<string, int> popularityDictionary = new Dictionary<string, int>();

            foreach (var name in Enum.GetNames(typeof(ePopularity)))
            {
                popularityDictionary.Add(name, 0);
            }

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                popularityDictionary[getFriendPopularityValue(friend.NumberOfFriends)]++;
            }

            // Using the real data (Real facebook data which you can get when facebook API supports it)
            // foreach(var friend in LoggedUser.Friends)
            // {
            //     popularityDictionary[getFriendPopularityValue(friend.Friends.Count)]++;
            // }
            return popularityDictionary;
        }

        private string getFriendPopularityValue(int i_FriendsCount)
        {
            int friendsCount = i_FriendsCount;
            string popularityValue = null;

            if (friendsCount > 0 && friendsCount < 100)
            {
                popularityValue = ePopularity.Unpopular.ToString();
            }
            else
            {
                if (friendsCount > 100 && friendsCount < 1000)
                {
                    popularityValue = ePopularity.Normal.ToString();
                }
                else
                {
                    if (friendsCount > 1000 && friendsCount < 2000)
                    {
                        popularityValue = ePopularity.Known.ToString();
                    }
                    else
                    {
                        if (friendsCount > 2000 && friendsCount < 5000)
                        {
                            popularityValue = ePopularity.Popular.ToString();
                        }
                        else
                        {
                            popularityValue = ePopularity.VeryPopular.ToString();
                        }
                    }
                }
            }

            return popularityValue;
        }
    }
}
