using System;

namespace FacebookAppLogic
{
    public interface ITitleChangedObserver
    {
        void OnTitleChanged(string i_NewTitle);
    }
}
