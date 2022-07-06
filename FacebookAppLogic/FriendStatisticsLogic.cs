using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FacebookAppLogic.Enums;
using FacebookAppLogic.Strategy;

namespace FacebookAppLogic
{
    /// <summary>
    /// Because the FACEBOOK API does not currently support some of the operations we used fake data: a file of fake friends.
    /// The code that uses the FACEBOOK API is in the comment.
    /// And the code runs on the fake data in order to display the functionality of the app.
    /// </summary>
    internal class FriendStatisticsLogic
    {
        private List<FriendItem> Friends { get; set; }

        private int AmountOfResults { get; set; }

        private IStatisticsStrategy StatisticsStrategy { get; set; }

        public FriendStatisticsLogic(List<FriendItem> i_Friends)
        {
            Friends = i_Friends;
        }

        internal static Dictionary<string, int> GetUniqueStringsAndTheirCount(Collection<object> i_Collection, int i_AmountOfResults)
        {
            List<object> distinctList = i_Collection.Distinct().ToList();
            Dictionary<string, int> countDict = new Dictionary<string, int>();

            if(i_Collection[0] != null)
            {
                foreach(var item in distinctList)
                {
                    countDict.Add(item.ToString(), 0);
                }

                foreach(var item in i_Collection)
                {
                    countDict[item.ToString()] += 1;
                }
            }

            return GetSortedTopValuesDictionary(countDict, i_AmountOfResults);
        }

        internal static Dictionary<string, int> GetSortedTopValuesDictionary(Dictionary<string, int> i_Dictionary, int i_AmountOfResults)
        {
            Dictionary<string, int> topValuesDictionary = i_Dictionary.OrderByDescending(item => item.Value)
                .Take(i_AmountOfResults).ToDictionary(item => item.Key, item => item.Value);

            return topValuesDictionary;
        }

        internal Dictionary<string, int> GetInfo(eInfoType i_TypeOfInfo, int i_AmountOfResults)
        {
            AmountOfResults = i_AmountOfResults;

            switch(i_TypeOfInfo)
            {
                case eInfoType.City:
                    StatisticsStrategy = new CityStatistics();
                    break;
                case eInfoType.Religion:
                    StatisticsStrategy = new ReligionStatistics();
                    break;
                case eInfoType.Gender:
                    StatisticsStrategy = new GenderStatistics();
                    break;
                case eInfoType.PostAmountOfLikes:
                    StatisticsStrategy = new PostLikesStatistics();
                    break;
                case eInfoType.MostVisitedPlaces:
                    StatisticsStrategy = new MostVisitedPlacesStatistics();
                    break;
                case eInfoType.FavouriteTeam:
                    StatisticsStrategy = new FavouriteTeamsStatistics();
                    break;
                case eInfoType.FriendPopularity:
                    StatisticsStrategy = new FriendPopularityStatistics();
                    break;
                case eInfoType.Languages:
                    StatisticsStrategy = new LanguagesStatistics();
                    break;
            }

            return StatisticsStrategy.DoStatisticAnalyze(Friends, AmountOfResults);
        }
    }
}
