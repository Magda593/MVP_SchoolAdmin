namespace MVP_Tema3.Models.EntityLayer
{
    class Medie : BasePropertyChanged 
    {
        private int? id;
        private int? studentID;
        private int? materieID;
        private int valoare;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public int? StudentID
        {
            get { return studentID; }
            set
            {
                studentID = value;
                NotifyPropertyChanged("StudentID");
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

        public int Valoare
        {
            get { return valoare; }
            set
            {
                valoare = value;
                NotifyPropertyChanged("Valoare");
            }
        }

    }
}
