using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class ClasaVM
    {
        ClasaBLL clasaBLL = new ClasaBLL();
        public ClasaVM()
        {
            ClaseList = clasaBLL.GetAllClasa();
        }

        #region Data Members

        public ObservableCollection<Clasa> ClaseList
        {
            get => clasaBLL.ClasaList;
            set => clasaBLL.ClasaList = value;
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
                    addCommand = new RelayCommand<Clasa>(clasaBLL.AddClasa);
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
                    updateCommand = new RelayCommand<Clasa>(clasaBLL.ModifyClasa);
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
                    deleteCommand = new RelayCommand<Clasa>(clasaBLL.DeleteClasa);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
