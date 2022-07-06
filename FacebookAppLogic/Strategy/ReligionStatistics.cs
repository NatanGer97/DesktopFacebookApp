using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookAppLogic.Strategy
{
    internal class ReligionStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Collection<object> religionCollection = new Collection<object>();

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                religionCollection.Add(friend.Religion);
            }

            // Using Real facebook friends data
            // foreach (var friend in LoggedUser.Friends)
            // {
            //     religionCollection.Add(friend.Religion);
            // }
            return FriendStatisticsLogic.GetUniqueStringsAndTheirCount(religionCollection, i_AmountOfResults);
        }
    }
}
