using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataGrid.Enums;

namespace DataGrid
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private bool _wasReelected;

        public bool WasReelected
        {
            get
            {
                return _wasReelected;
            }
            set
            {
                _wasReelected = value;
                RaisePropertyChanged();
            }
        }

        private Party _affiliation;

        public Party Affiliation
        {
            get { return _affiliation; }
            set { _affiliation = value; }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { Name = "Washington", Title= "President 1",WasReelected=true,Affiliation=Party.PTI});
            employees.Add(new Employee() { Name = "Nawaz", Title = "President 2", WasReelected = true, Affiliation = Party.PMLN});
            employees.Add(new Employee() { Name = "Benazir", Title = "President 3", WasReelected = true, Affiliation = Party.PPP });
            employees.Add(new Employee() { Name = "Zardari", Title = "President 4", WasReelected = false, Affiliation = Party.PPP });
            employees.Add(new Employee() { Name = "Imran", Title = "President 5", WasReelected = true, Affiliation = Party.PTI });
            return employees;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(
            [CallerMemberName] string caller = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }

}
