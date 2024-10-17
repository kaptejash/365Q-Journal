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
using System.Windows.Navigation;
using System.Windows.Shapes;
using _365Q_Journal.Views;
using Wpf.Ui.Controls;

namespace _365Q_Journal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const String DASHBOARD = "Dashboard";
        private const String JOURNAL = "Journal";
        private const String PROMPTS = "Prompts";
        private const String FAVORITES = "Favorites";
        private const String SETTINGS = "Settings";

        private bool isDarkMode = false;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new DashboardPage();
        }

        private void NavigationViewItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItem menuItem in RootNavigation.MenuItems)
            {
                if (menuItem.Equals(sender))
                {
                    menuItem.IsActive = true;
                    switch(menuItem.Content)
                    {
                        case DASHBOARD:
                            MainFrame.Content = new DashboardPage();
                            break;
                        case JOURNAL:
                            MainFrame.Content = new JournalPage();
                            break;
                        case PROMPTS:
                            MainFrame.Content = new PromptListPage();
                            break;
                        case FAVORITES:
                            MainFrame.Content = new FavoritesPage();
                            break;
                        case SETTINGS:
                            MainFrame.Content = new SettingsPage();
                            break;
                        default:
                            new Exception("Invalid Menu Item");
                            break;
                    }
                }
                else
                {
                    menuItem.IsActive = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.isDarkMode = !this.isDarkMode;

            if (this.isDarkMode)
            {
                Wpf.Ui.Appearance.ApplicationThemeManager.Apply(
                  Wpf.Ui.Appearance.ApplicationTheme.Dark, // Theme type
                  Wpf.Ui.Controls.WindowBackdropType.None,  // Background type
                  false                                      // Whether to change accents automatically
                );

            } else
            {
                Wpf.Ui.Appearance.ApplicationThemeManager.Apply(
                  Wpf.Ui.Appearance.ApplicationTheme.Light, // Theme type
                  Wpf.Ui.Controls.WindowBackdropType.None,  // Background type
                  false                                      // Whether to change accents automatically
                );
            }
        }
    }
}
