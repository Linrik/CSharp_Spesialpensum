using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectExam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ProjectExam.ViewModel
{
    partial class StudentsVM : ObservableObject
    {
        [ObservableProperty]
        private string? _view;

        [ObservableProperty]
        private ObservableCollection<Student>? _students;

        [ObservableProperty]
        private List<Student> _list;

        [ObservableProperty]
        private string? _searchStudent = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteStudentCommand))]
        private Student? _selectedStudent;

        public StudentsVM()
        {
            Students = Student.GetListXML();
            List = Students.ToList();
        }

        partial void OnSearchStudentChanged(string? value)
        {
            List = Students.Where(Student => Student.FirstName.ToLower().Contains(SearchStudent.ToLower())
            || Student.LastName.Contains(SearchStudent)).ToList();
        }

        private bool IsSelected => SelectedStudent != null;
        [RelayCommand(CanExecute = nameof(IsSelected))]
        public async void DeleteStudent()
        {
            MSG = $"Student {SelectedStudent.FirstName} slettet";
            Students.Remove(SelectedStudent);
            Student.SaveList(Students);
            Student.SaveListXML(Students);
            Number--;
            List = Students.ToList();
            await Task.Delay(3000);
            MSG = "";
        }

        [RelayCommand]
        public void OrderByStudentId() => List = List?.OrderBy(Student => Student.StudentId).ToList();
        [RelayCommand]
        public void OrderByFirstName() => List = List?.OrderBy(Student => Student.FirstName).ThenBy(Student => Student.LastName).ToList();
        [RelayCommand]
        public void OrderByLastName() => List = List?.OrderBy(Student=> Student.LastName).ToList();
        [RelayCommand]
        public void OrderByPhone() => List = List?.OrderBy(Student => Student.PhoneNumber).ToList();


        [ObservableProperty]
        private int? _number = Student.GetList().Count;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddNewStudentCommand))]
        private string? _firstName;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddNewStudentCommand))]
        private string? _lastName;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddNewStudentCommand))]
        private string? _phone;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddNewStudentCommand))]
        private string? _studentId;
        [ObservableProperty]
        private string? _mSG;


        private bool CanClick() => IsFilled();

        [RelayCommand(CanExecute = nameof(CanClick))]
        public async void AddNewStudent()
        {
            if (FirstName == null || LastName == null || Phone == null || Students == null) return;
            if(!List.Exists(s => s.StudentId == Convert.ToInt32(StudentId)))
            {
                Student newStudent = new Student(Convert.ToInt32(StudentId),
                FirstName,
                LastName,
                Convert.ToInt32(Phone));
                Students.Add(newStudent);
                Number++;
                List = Students.ToList();
                MSG = "Student lagt til";
                SaveStudent();
                ClearForm();
                await Task.Delay(3000);
                MSG = "";
            }
        }

        public void ClearForm()
        {
            StudentId = null;
            FirstName = null;
            LastName = null;
            Phone = null;
        }
        public void SaveStudent()
        {
            Student.SaveList(Students);
            Student.SaveListXML(Students);
        }

        public bool IsFilled()
        {
            return FirstName?.CompareTo("") > 0
                && LastName?.CompareTo("") > 0
                && int.TryParse(Phone, out _)
                && int.TryParse(StudentId, out int n)
                && !Students.Any(Student => Student.StudentId == n);
        }
    }
}
