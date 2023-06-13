using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class ProfesorVM
    {
        ProfesorBLL profesorBLL = new ProfesorBLL();
        public ProfesorVM()
        {
            ProfesoriList = profesorBLL.GetAllProfesori();
        }

        #region Data Members

        public ObservableCollection<Profesor> ProfesoriList
        {
            get => profesorBLL.ProfesoriList;
            set => profesorBLL.ProfesoriList = value;
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
                    addCommand = new RelayCommand<Profesor>(profesorBLL.AddProfesor);
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
                    updateCommand = new RelayCommand<Profesor>(profesorBLL.ModifyProfesor);
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
                    deleteCommand = new RelayCommand<Profesor>(profesorBLL.DeleteProfesor);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
