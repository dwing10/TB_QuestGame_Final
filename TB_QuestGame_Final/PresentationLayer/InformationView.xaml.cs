using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame_S1.Models;

namespace TBQuestGame_S1.PresentationLayer
{
    /// <summary>
    /// Interaction logic for InformationView.xaml
    /// </summary>
    public partial class InformationView : Window
    {
        public InformationView()
        {

            InitializeComponent();
            travelText.Text = "Click on a location name to travel to that location. " +
                "Some locations are inaccessible until certain objectives have been completed. " + Environment.NewLine + 
                "*Note: Bloodskull raider are known to roam the northern continent.";

            battlingText.Text = "Click on an enemy name and then click the attack button to battle them. " +
                "If your power is greater than the enemy's power, then you will defeat them. " +
                "Victory in battle will increase your wealth, but even victory comes at a cost. " +
                "Whether you win or lose, your legion will be sure to suffer casualties.";

            recruitText.Text = "Purchasing troops increases your legion's power. You will also need to recruit certain troops to gain access to locked locations and defeate your enemies. " +
                "To purchase troops click on the recruit button on the main window." + Environment.NewLine + "" + Environment.NewLine + 
                "Note: Some troops increase your tactical advantage, which reduces your enemies power. Be cautious as enemies also have " +
                "tactical advantage. The higher the enemy's rank, the higher the advantage.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
