using System;
using System.Collections.Generic;

namespace FacebookAppLogic.Strategy
{
    internal class PostLikesStatistics : IStatisticsStrategy
    {
        public Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults)
        {
            Dictionary<string, int> friendsAndTheirAmountOfLikesDictionary = new Dictionary<string, int>();

            // Using fake data (XML File with fake friends)
            foreach (FriendItem friend in i_Friends)
            {
                int likesCounter = 0;

                foreach (var post in friend.Posts)
                {
                    likesCounter += post.NumLikes;
                }

                friendsAndTheirAmountOfLikesDictionary.Add(friend.Name, likesCounter);
            }

            // Using the real data (Real facebook friends which you can get when facebook API supports it)
            // foreach (var friend in LoggedUser.Friends)
            // {
            //     int likesCounter = 0;
            //     foreach (var post in friend.Posts)
            //     {
            //         likesCounter += post.LikedBy.Count;
            //     }
            //     friendsAndTheirAmountOfLikesDictionary.Add(friend.Name, likesCounter);
            // }
            return FriendStatisticsLogic.GetSortedTopValuesDictionary(friendsAndTheirAmountOfLikesDictionary, i_AmountOfResults);
        }
    }
}
