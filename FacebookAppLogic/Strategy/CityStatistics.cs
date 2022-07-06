using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookAppLogic.Strategy
{
    internal class CityStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Collection<object> citiesCollection = new Collection<object>();

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                citiesCollection.Add(friend.City);
            }

            // Using Real facebook friends data
            // foreach(var friend in LoggedUser.Friends)
            // {
            //     if(friend.Location != null)
            //     {
            //         citiesCollection.Add(friend.Location.Name);
            //     }
            // }
            return FriendStatisticsLogic.GetUniqueStringsAndTheirCount(citiesCollection, i_AmountOfResults);
        }
    }
}
