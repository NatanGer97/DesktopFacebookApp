using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookAppLogic;
using FacebookAppLogic.Enums;

namespace BasicFacebookFeatures
{
    public partial class FormFriendStatistics : Form
    {
        private int AmountOfResults { get;  set; }

        public FormFriendStatistics()
        {
            InitializeComponent();
            initializeListBox();
            initializeControllersExtraProperties();
        }

        private void initializeListBox()
        {
            foreach(var optionName in Enum.GetValues(typeof(eInfoType)))
            {
                listBoxOptions.Items.Add(optionName);
            }

            listBoxOptions.SelectedIndex = 0;
            pictureBox.Image = Properties.Resources.popular;
        }

        private void fillChart(Dictionary<string, int> i_Dictionary)
        {
            if(i_Dictionary.Count != 0)
            {
                foreach (var item in i_Dictionary)
                {
                    chartColumn.Series["Series1"].Points.AddXY(item.Key, item.Value);
                    chartPie.Series["Series1"].Points.AddXY(item.Key, item.Value);
                }
            }
            else
            {
                MessageBox.Show(@"Error", @"Not enough data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetStats_Click(object sender, EventArgs e)
        {
            chartPie.Series["Series1"].Points.Clear();
            chartColumn.Series["Series1"].Points.Clear();

            if(int.TryParse(textBoxAmount.Text, out int parseResult))
            {
                AmountOfResults = int.Parse(textBoxAmount.Text);
                fillChart(FacebookFacade.FacadeInstance.GetStatisticsData((eInfoType)listBoxOptions.SelectedItem, AmountOfResults));
                setChartIcon();
            }
            else
            {
                MessageBox.Show(@"No Amount of results entered!");
            }
        }

        private void setChartIcon()
        {
            switch ((eInfoType)listBoxOptions.SelectedItem)
            {
                case eInfoType.City:
                    pictureBox.Image = Properties.Resources.city;
                    break;
                case eInfoType.Religion:
                    pictureBox.Image = Properties.Resources.religion;
                    break;
                case eInfoType.Gender:
                    pictureBox.Image = Properties.Resources.gender;
                    break;
                case eInfoType.PostAmountOfLikes:
                    pictureBox.Image = Properties.Resources.like;
                    break;
                case eInfoType.MostVisitedPlaces:
                    pictureBox.Image = Properties.Resources.location;
                    break;
                case eInfoType.FavouriteTeam:
                    pictureBox.Image = Properties.Resources.soccer;
                    break;
                case eInfoType.FriendPopularity:
                    pictureBox.Image = Properties.Resources.popular;
                    break;
                case eInfoType.Languages:
                    pictureBox.Image = Properties.Resources.language;
                    break;
                default:
                    pictureBox.Image = Properties.Resources.popular;
                    break;
            }
        }

        private void textBoxAmount_Click(object sender, EventArgs e)
        {
            textBoxAmount.SelectAll();
        }

        private void initializeControllersExtraProperties()
        {
            chartPie.Series[0]["PieLabelStyle"] = "Outside";
            chartPie.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartPie.ChartAreas[0].Area3DStyle.Inclination = 10;
            chartColumn.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        }
    }
}
