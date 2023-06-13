using System.Collections.ObjectModel;
using System.Windows.Input;
using MVP_Tema3.Models.BusinessLogicLayer;
using MVP_Tema3.Models.EntityLayer;
using MVP_Tema3.ViewModels.Commands;

namespace MVP_Tema3.ViewModels
{
    class NotaVM
    {
        NotaBLL notaBLL = new NotaBLL();
        public NotaVM()
        {
            NoteList = notaBLL.GetAllNote();
        }

        #region Data Members

        public ObservableCollection<Nota> NoteList
        {
            get => notaBLL.NotaList;
            set => notaBLL.NotaList = value;
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
                    addCommand = new RelayCommand<Nota>(notaBLL.AddNota);
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
                    updateCommand = new RelayCommand<Nota>(notaBLL.ModifyNota);
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
                    deleteCommand = new RelayCommand<Nota>(notaBLL.DeleteNota);
                }
                return deleteCommand;
            }
        }

        #endregion

    }
}
