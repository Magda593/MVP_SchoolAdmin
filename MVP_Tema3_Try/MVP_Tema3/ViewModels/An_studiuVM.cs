using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class An_studiuVM
    {
        An_studiuBLL anStudiuBLL = new An_studiuBLL();
        public An_studiuVM()
        {
            AniStudiuList = anStudiuBLL.GetAllAnStudiu();
        }

        #region Data Members

        public ObservableCollection<An_studiu> AniStudiuList
        {
            get => anStudiuBLL.AnStudiuList;
            set => anStudiuBLL.AnStudiuList = value;
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
                    addCommand = new RelayCommand<An_studiu>(anStudiuBLL.AddAnStudiu);
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
                    updateCommand = new RelayCommand<An_studiu>(anStudiuBLL.ModifyAnStudiu);
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
                    deleteCommand = new RelayCommand<An_studiu>(anStudiuBLL.DeleteAnStudiu);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
