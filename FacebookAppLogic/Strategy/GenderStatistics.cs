using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookAppLogic.Strategy
{
    internal class GenderStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Collection<object> genderCollection = new Collection<object>();

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                genderCollection.Add(friend.Gender);
            }

            // Using Real facebook friends data
            // foreach (var friend in LoggedUser.Friends)
            // {
            //     genderCollection.Add(friend.Gender);
            // }
            return FriendStatisticsLogic.GetUniqueStringsAndTheirCount(genderCollection, i_AmountOfResults);
        }
    }
}
