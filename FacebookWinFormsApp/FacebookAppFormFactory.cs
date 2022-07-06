using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    internal static class FacebookAppFormFactory
    {
        public static Form CreateFacebookAppForm(eFormTypes i_TargetFormType)
        {
            Form newForm = null;

            switch (i_TargetFormType)
            {
                case eFormTypes.FormLogin:
                    newForm = new FormLogin();
                    break;
                case eFormTypes.FormTabs:
                    newForm = new FormTabs();
                    break;
                case eFormTypes.FormFriendStatistics:
                    newForm = new FormFriendStatistics();
                    break;
                case eFormTypes.FormCustomListBuilder:
                    newForm = new FormCustomListBuilder();
                    break;
                }

            return newForm;
        }
    }
}
