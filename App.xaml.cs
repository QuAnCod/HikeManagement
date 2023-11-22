using System.Collections.ObjectModel;

namespace HikeManagement
{
    public partial class App : Application
    {
        public ObservableCollection<Hike> HikeList { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
