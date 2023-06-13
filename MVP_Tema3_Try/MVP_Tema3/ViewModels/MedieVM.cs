using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class MedieVM
    {
        MedieBLL medieBLL = new MedieBLL();
        public MedieVM()
        {
            MediiList = medieBLL.GetAllMedii();
        }

        #region Data Members

        public ObservableCollection<Medie> MediiList
        {
            get => medieBLL.MedieList;
            set => medieBLL.MedieList = value;
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
                    addCommand = new RelayCommand<Medie>(medieBLL.AddMedie);
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
                    updateCommand = new RelayCommand<Medie>(medieBLL.ModifyMedie);
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
                    deleteCommand = new RelayCommand<Medie>(medieBLL.DeleteMedie);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
