using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookAppLogic.Strategy
{
    internal class LanguagesStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Collection<object> languagesCollection = new Collection<object>();

            // Using fake data (XML File with fake friends)
            foreach (var friend in i_Friends)
            {
                if (friend.Languages != null)
                {
                    foreach (var friendLanguages in friend.Languages)
                    {
                        languagesCollection.Add(friendLanguages);
                    }
                }
            }

            /*  Using the real data(Real facebook data which you can get when facebook API supports it)
              foreach (var friend in LoggedUser.Friends)
             {
                 if (friend.Languages != null)
                 {
                     foreach (var friendLanguages in friend.Languages)
                     {
                         genderCollection.Add(friendLanguages.Name);
                     }
                 }
             }
            */

            return FriendStatisticsLogic.GetUniqueStringsAndTheirCount(languagesCollection, i_AmountOfResults);
        }
    }
}
