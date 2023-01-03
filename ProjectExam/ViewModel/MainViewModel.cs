using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectExam.ViewModel
{
    partial class MainViewModel : ObservableObject {
        [ObservableProperty]
        StudentsVM studentsVM;
        
        public MainViewModel(StudentsVM s) {
            this.StudentsVM= s;
        }
    }
}
