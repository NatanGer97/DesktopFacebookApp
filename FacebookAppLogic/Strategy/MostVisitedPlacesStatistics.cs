using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookAppLogic.Strategy
{
    internal class MostVisitedPlacesStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Collection<object> checkinLocationCollection = new Collection<object>();

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                foreach (var location in friend.Locations)
                {
                    checkinLocationCollection.Add(location);
                }
            }

            // Using the real data (Real facebook data which you can get when facebook API supports it)
            // foreach(User friend in LoggedUser.Friends)
            // {
            //     foreach(Checkin checkIn in friend.Checkins)
            //     {
            //         checkinLocationCollection.Add(checkIn.Place.Location);
            //     }
            // }
            return FriendStatisticsLogic.GetUniqueStringsAndTheirCount(checkinLocationCollection, i_AmountOfResults);
        }
    }
}
