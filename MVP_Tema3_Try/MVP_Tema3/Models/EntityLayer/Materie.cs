namespace MVP_Tema3.Models.EntityLayer
{
    class Materie :BasePropertyChanged
    {
        private int? id;
        private string nume;
        private string profesorID;
        private string profesorName;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string Nume
        {
            get { return nume; }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }

        public string ProfesorID
        {
            get { return profesorID; }
            set
            {
                profesorID = value;
                NotifyPropertyChanged("ProfesorID");
            }
        }
        public string ProfesorName
        {
            get { return profesorName; }
            set
            {
                profesorName = value;
                NotifyPropertyChanged("ProfesorName");
            }
        }


    }
}
