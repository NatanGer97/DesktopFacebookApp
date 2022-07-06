using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookAppLogic.Strategy
{
    internal class FavouriteTeamsStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Collection<object> favouriteTeamsCollection = new Collection<object>();

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                favouriteTeamsCollection.Add(friend.FootballTeam);
            }

            // Using the real data (Real facebook data which you can get when facebook API supports it)
            // foreach(var friend in LoggedUser.Friends)
            // {
            //     if(friend.FavofriteTeams != null)
            //     {
            //         foreach (var favofriteTeam in friend.FavofriteTeams)
            //         {
            //             favouriteTeamsCollection.Add(favofriteTeam.Name);
            //         }
            //     }
            //     else
            //     {
            //         favouriteTeamsCollection.Add("None");
            //     }
            // }
            return FriendStatisticsLogic.GetUniqueStringsAndTheirCount(favouriteTeamsCollection, i_AmountOfResults);
        }
    }
}
