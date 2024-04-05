using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace RadialMenu 
{
    public partial class MainPage : ContentPage 
    {
        public MainPage() 
        {
            InitializeComponent();
            this.BindingContext = new EmployeeViewModel();

        }
    }

    public class EmployeeModel : INotifyPropertyChanged {
        public string Icon { get; set; }
        public string EmployeeName { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class EmployeeViewModel {
        public ICommand RadialMenuCommand { get; private set; }
        private ObservableCollection<EmployeeModel> employeeCollection = new ObservableCollection<EmployeeModel>();
        public ObservableCollection<EmployeeModel> EmployeeCollection {
            get { return employeeCollection; }
            set { employeeCollection = value; }
        }
        public EmployeeViewModel() {
            RadialMenuCommand = new Command(RadialItemTapped);

            EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE700", EmployeeName = "Alex" });
            EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE715", EmployeeName = "Lee" });
            EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE70A", EmployeeName = "Ben" });
            EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE716", EmployeeName = "Carl" });
            EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE77E", EmployeeName = "Yang" });
        }

        void RadialItemTapped(object obj) {
            var alertResult = Application.Current.MainPage.DisplayAlert("Message", (obj as EmployeeModel)?.EmployeeName, null, "OK");
        }
    }
}






