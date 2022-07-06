using System.Collections.Generic;

namespace FacebookAppLogic.Strategy
{
    internal interface IStatisticsStrategy
    {
        Dictionary<string, int> DoStatisticAnalyze(List<FriendItem> i_Friends, int i_AmountOfResults);
    }
}
