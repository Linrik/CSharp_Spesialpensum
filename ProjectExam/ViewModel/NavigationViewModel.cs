using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectExam.Model;

namespace ProjectExam.ViewModel
{
    
    partial class NavigationViewModel : ObservableObject
    {

        public NavigationViewModel() {
            CurrentView = studentVM;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(GoHomeCommand))]
        private MainViewModel mainVM = new MainViewModel(studentVM);

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(GoToCommand), "GoToNewCommand")]
        private static StudentsVM studentVM = new StudentsVM();


        [RelayCommand]
        public void GoHome()
        {
            CurrentView = mainVM;
        }

        [RelayCommand]
        public void GoTo()
        {
            studentVM.View = "ShowStudents";
            CurrentView = studentVM;
        }

        [RelayCommand]
        public void GoToNew()
        {
            studentVM.View = "AddNewStudent";
            CurrentView = studentVM;
        }

        [ObservableProperty]
        private object currentView;



    }

}
