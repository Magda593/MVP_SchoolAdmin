using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class SpecializareVM
    {
        SpecializareBLL specializareBLL = new SpecializareBLL();
        public SpecializareVM()
        {
            SpecializariList = specializareBLL.GetAllSpecializari();
        }

        #region Data Members

        public ObservableCollection<Specializare> SpecializariList
        {
            get => specializareBLL.SpecializariList;
            set => specializareBLL.SpecializariList = value;
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
                    addCommand = new RelayCommand<Specializare>(specializareBLL.AddSpecializare);
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
                    updateCommand = new RelayCommand<Specializare>(specializareBLL.ModifySpecializare);
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
                    deleteCommand = new RelayCommand<Specializare>(specializareBLL.DeleteSpecializare);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
