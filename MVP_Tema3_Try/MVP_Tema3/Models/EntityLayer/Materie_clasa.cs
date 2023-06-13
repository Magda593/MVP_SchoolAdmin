namespace MVP_Tema3.Models.EntityLayer
{
    class Materie_clasa : BasePropertyChanged
    {
        private int? id;
        private int? materieID;
        private int? clasaID;
        private bool areTeza;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public int? MaterieID
        {
            get { return materieID; }
            set
            {
                materieID = value;
                NotifyPropertyChanged("MaterieID");
            }
        }

        public int? ClasaID
        {
            get { return clasaID; }
            set
            {
                clasaID = value;
                NotifyPropertyChanged("ClasaID");
            }
        }

        public bool AreTeza
        {
            get { return areTeza; }
            set
            {
                areTeza = value;
                NotifyPropertyChanged("AreTeza");
            }
        }
    }
}
