using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookAppLogic;
using FacebookAppLogic.Enums;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    /// <summary>
    /// Button Proxy implementation
    /// </summary>
    public partial class CustomListItem : Button
    {
        private bool m_IsInEditMode;
        private bool m_IsitleChanged;

        public bool IsTitleIsCchanged
        {
            get
            {
                return m_IsitleChanged;
            }

            set
            {
                m_IsitleChanged = value;

                if (m_IsitleChanged)
                {
                    notifyTitleChangedObservers();
                }
            }
        }

        private List<ITitleChangedObserver> m_TitelChangedObservers = new List<ITitleChangedObserver>();

        // holds the original color of the item;
        public Color OriginalColor { get; }

        /*internal delegate void CurrentEditItem(CustomList i_Item);*/

        /// <summary>
        /// Event for indicate that this item is now in edit status
        /// </summary>
        /*internal event CurrentEditItem InEditMode;*/

        /// <summary>
        /// Event for indicate then this item done with modification
        /// </summary>
        public event Action EditFinished;

        public event Action<CustomListCollection.CustomFriendsList> EditStart;

        public event Action<CustomListCollection.CustomFriendsList> ReportListWasClicked;

        public void AttachObserver(ITitleChangedObserver i_TitleChangedObserver)
        {
            m_TitelChangedObservers.Add(i_TitleChangedObserver);
        }

        public void DetachObserver(ITitleChangedObserver i_TitleChangedObserver)
        {
            m_TitelChangedObservers.Remove(i_TitleChangedObserver);
        }

        private void notifyTitleChangedObservers()
        {
            foreach (ITitleChangedObserver observer in m_TitelChangedObservers)
            {
                observer.OnTitleChanged(this.CustomListOfFriends.ListName);
            }
        }

        public CustomListCollection.CustomFriendsList CustomListOfFriends { get; set; }
        /*public CustomList CustomListOfFriends { get; set; }*/

        public FacebookObjectCollection<User> CustomListOfFriendsAPI { get; set; }

        /// <summary>
        /// $ API $
        /// </summary>
        /// <param name="i_CustomList"></param>
        /*      public CustomListItem(FacebookObjectCollection<User> i_CustomList)
              {
                  InitializeComponent();
                  CustomListOfFriendsAPI = i_CustomList;
                  m_IsInEditMode = false;
                  r_OriginalColor = BackColor;
                  initItem();
              }*/
        public CustomListItem(CustomListCollection.CustomFriendsList i_CustomList)
        {
            InitializeComponent();
            CustomListOfFriends = i_CustomList;
            m_IsInEditMode = false;
            m_IsitleChanged = false;
            OriginalColor = BackColor;
            initItem();
        }

        /*  public CustomListItem(CustomList i_CustomList)
          {
              InitializeComponent();
              CustomListOfFriends = i_CustomList;
              m_IsInEditMode = false;
              OriginalColor = BackColor;
              initItem();
          }*/

        protected override void OnClick(EventArgs e)
        {
            doWhenListClicked();
        }

        private void doWhenListClicked()
        {
            /*m_IsInEditMode = true;*/
            if (ReportListWasClicked != null)
            {
                notify(eNotifyRequest.ReportClick);
            }
        }

        private void notify(eNotifyRequest eNotifyRequest)
        {
            switch (eNotifyRequest)
            {
                case eNotifyRequest.InEdit:
                    EditStart.Invoke(CustomListOfFriends);
                    break;
                case eNotifyRequest.EditFinished:
                    EditFinished.Invoke();
                    break;
                case eNotifyRequest.ReportClick:
                    ReportListWasClicked.Invoke(CustomListOfFriends);
                    break;
                default:
                    break;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
            textBoxListName.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
            textBoxListName.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
        }

        /// <summary>
        /// Change Background Color when this property changes
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            BackColor = !Enabled ? Color.Beige : OriginalColor;
            base.OnEnabledChanged(e);
        }

        private void initItem()
        {
            textBoxListName.TextChanged += TextBoxListName_TextChanged;
            buttonEdit.Click += buttonEdit_Click;
            if (!string.IsNullOrEmpty(CustomListOfFriends.ListName))
            {
                textBoxListName.Text = CustomListOfFriends.ListName;
                labelCounter.Text = $"Amount: {CustomListOfFriends.FriendsInList.Count}";
                labelCounter.Left = 10;
            }
        }

        private void TextBoxListName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxListName.Text != CustomListOfFriends.ListName)
            {
                buttonEdit.BackgroundImage = Properties.Resources.save;
            }
            else
            {
                buttonEdit.BackgroundImage = Properties.Resources.edit;
            }
        }

        /// <summary>
        /// Button for edit the list name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
/*            doWhenEditModeChanged();
*/
            m_IsInEditMode = !m_IsInEditMode;

            if (m_IsInEditMode)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to Edit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    if (EditStart != null)
                    {
                        textBoxListName.Enabled = true;
                        textBoxListName.ReadOnly = false;
                        textBoxListName.Focus();
                        notify(eNotifyRequest.InEdit);
                    }
                }
                else
                {
                    m_IsInEditMode = !m_IsInEditMode;
                }
            }
            else
            {
                MessageBox.Show("changes Saved", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxListName.Enabled = !textBoxListName.Enabled;
                textBoxListName.ReadOnly = !textBoxListName.ReadOnly;
                buttonEdit.BackgroundImage = Properties.Resources.edit;
                if (EditFinished != null)
                {
                    UpdateTitleOrNot();
                    notify(eNotifyRequest.EditFinished); // notify that this item already not in modify status
                }
            }
        }

        private void UpdateTitleOrNot()
        {
            if (this.CustomListOfFriends.ListName != textBoxListName.Text)
            {
                CustomListOfFriends.ListName = textBoxListName.Text; // update title 
                IsTitleIsCchanged = true;
            }
        }
    }
}
