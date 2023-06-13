using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class An_studiuBLL
    {
        public ObservableCollection<An_studiu> AnStudiuList { get; set; }

        An_studiuDAL anStudiuDAL = new An_studiuDAL();

        public ObservableCollection<An_studiu> GetAllAnStudiu()
        {
            return anStudiuDAL.GetAllAnStudiu();
        }

        public void AddAnStudiu(An_studiu anStudiu)
        {
            if (anStudiu.An == null)
            {
                throw new AgendaException("Anul de studiu trebuie precizat");
            }

            anStudiuDAL.AddAnStudiu(anStudiu);
            AnStudiuList.Add(anStudiu);
        }

        public void ModifyAnStudiu(An_studiu anStudiu)
        {
            if (anStudiu == null)
            {
                throw new AgendaException("Trebuie selectat un an de studiu");
            }
            if (anStudiu.An == null)
            {
                throw new AgendaException("Anul de studiu trebuie precizat");
            }
            anStudiuDAL.ModifyAnStudiu(anStudiu);
        }

        public void DeleteAnStudiu(An_studiu anStudiu)
        {
            if (anStudiu == null)
            {
                throw new AgendaException("Trebuie precizat un an de studiu!");
            }
            anStudiuDAL.DeleteAnStudiu(anStudiu);
            AnStudiuList.Remove(anStudiu);
        }

    }
}
