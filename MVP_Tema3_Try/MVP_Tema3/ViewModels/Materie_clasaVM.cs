using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class Materie_clasaVM
    {
        Materie_clasaBLL materieClasaBLL = new Materie_clasaBLL();
        public Materie_clasaVM()
        {
            MateriiClasaList = materieClasaBLL.GetAllMaterieClasa();
        }

        #region Data Members

        public ObservableCollection<Materie_clasa> MateriiClasaList
        {
            get => materieClasaBLL.MaterieClasaList;
            set => materieClasaBLL.MaterieClasaList = value;
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
                    addCommand = new RelayCommand<Materie_clasa>(materieClasaBLL.AddMaterieClasa);
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
                    updateCommand = new RelayCommand<Materie_clasa>(materieClasaBLL.ModifyMaterieClasa);
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
                    deleteCommand = new RelayCommand<Materie_clasa>(materieClasaBLL.DeleteMaterieClasa);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
