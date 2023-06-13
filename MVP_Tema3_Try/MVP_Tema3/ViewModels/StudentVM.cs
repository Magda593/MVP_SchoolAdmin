using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class StudentVM
    {
        StudentBLL studentBLL = new StudentBLL();
        public StudentVM()
        {
            StudentsList = studentBLL.GetAllStudents();
        }

        #region Data Members

        public ObservableCollection<Student> StudentsList
        {
            get => studentBLL.StudentsList;
            set => studentBLL.StudentsList = value;
        }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Student>(studentBLL.AddStudent);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Student>(studentBLL.ModifyStudent);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Student>(studentBLL.DeleteStudent);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
