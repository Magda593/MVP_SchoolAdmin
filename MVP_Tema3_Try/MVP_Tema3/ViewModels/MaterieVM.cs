using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class MaterieVM
    {
        MaterieBLL materieBLL = new MaterieBLL();
        public MaterieVM()
        {
            MateriiList = materieBLL.GetAllMaterii();
        }

        #region Data Members

        public ObservableCollection<Materie> MateriiList
        {
            get => materieBLL.MaterieList;
            set => materieBLL.MaterieList = value;
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
                    addCommand = new RelayCommand<Materie>(materieBLL.AddMaterie);
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
                    updateCommand = new RelayCommand<Materie>(materieBLL.ModifyMaterie);
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
                    deleteCommand = new RelayCommand<Materie>(materieBLL.DeleteMaterie);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
