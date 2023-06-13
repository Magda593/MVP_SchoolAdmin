namespace MVP_Tema3.Models.EntityLayer
{
    class Profesor : BasePropertyChanged 
    {
        private int? id;
        private string cnp;
        private string sex;
        private string nume;
        private string prenume;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string CNP
        {
            get { return cnp; }
            set
            {
                cnp = value;
                NotifyPropertyChanged("CNP");
            }
        }

        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                NotifyPropertyChanged("Sex");
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

        public string Prenume
        {
            get { return prenume; }
            set
            {
                prenume = value;
                NotifyPropertyChanged("Prenume");
            }
        }
    }
}
