using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    public class AbsentaVM : BasePropertyChanged
    {
        AbsentaBLL absentaBLL = new AbsentaBLL();
        public AbsentaVM()
        {
            AbsenteList = absentaBLL.GetAllAbsente();
        }

        #region Data Members

        public ObservableCollection<Absenta> AbsenteList
        {
            get => absentaBLL.AbsentaList;
            set => absentaBLL.AbsentaList = value;
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
                    addCommand = new RelayCommand<Absenta>(absentaBLL.AddAbsenta);
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
                    updateCommand = new RelayCommand<Absenta>(absentaBLL.ModifyAbsenta);
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
                    deleteCommand = new RelayCommand<Absenta>(absentaBLL.DeleteAbsenta);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
