using System;
using System.Threading;
using System.Windows.Forms;
using FacebookAppLogic;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormLogin : Form
    {
        private readonly AppSettings r_AppSettings;

        public LoginResult LoginResult { get; private set; }

        public AppSettings AppSettings => r_AppSettings;

        public FormLogin()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 200;
            r_AppSettings = AppSettings.LoadFromFile();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(AppSettings.AccessToken))
            {
                while(LoginResult == null || LoginResult.LoggedInUser == null)
                {
                    LoginResult = FacebookService.Login(
                        "327074122713018",
                        "email",
                        "public_profile",
                        "user_age_range",
                        "user_birthday",
                        "user_events",
                        "user_friends",
                        "user_gender",
                        "user_hometown",
                        "user_likes",
                        "user_link",
                        "user_location",
                        "user_photos",
                        "user_posts",
                        "user_videos");
                }

                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
            }

            new Thread(openFormTabsAndHideFormLogin).Start();
        }

        private void openFormTabsAndHideFormLogin()
        {
            this.Invoke(new Action(() =>
            {
                var formTabs = FacebookAppFormFactory.CreateFacebookAppForm(eFormTypes.FormTabs);
                FacebookFacade.FacadeInstance.User = LoginResult.LoggedInUser;

                this.Hide();
                formTabs.Show();
            }));
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Enabled = true;
            AppSettings.AccessToken = null;
            AppSettings.Remember = false;
            AppSettings.SaveToFile();
            Form formTabs = Application.OpenForms[1];

            if(formTabs != null)
            {
                formTabs.Dispose();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            checkBoxRememberMe.Checked = r_AppSettings.Remember;
            if (AppSettings.Remember)
            {
                new Thread(automaticLogin).Start();
            }
        }

        private void automaticLogin()
        {
            this.Invoke(new Action(() =>
            {
                LoginResult = FacebookService.Connect(r_AppSettings.AccessToken);
                buttonLogin.Enabled = false;
                openFormTabsAndHideFormLogin();
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            AppSettings.Remember = checkBoxRememberMe.Checked;
            if(AppSettings.Remember)
            {
                AppSettings.AccessToken = LoginResult.AccessToken;
            }

            AppSettings.SaveToFile();
        }
    }
}