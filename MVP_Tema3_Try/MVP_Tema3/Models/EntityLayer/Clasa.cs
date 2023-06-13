namespace MVP_Tema3.Models.EntityLayer
{
    class Clasa : BasePropertyChanged
    {
        private int? id;
        private string diriginteID;
        private string diriginteNume;
        private string anStudiuID;
        private string anStudiu;
        private string specializareID;
        private string specializareNume;
        private string nume;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string DiriginteID
        {
            get { return diriginteID; }
            set
            {
                diriginteID = value;
                NotifyPropertyChanged("DiriginteID");
            }
        } 
        public string DiriginteNume
        {
            get { return diriginteNume; }
            set
            {
                diriginteNume = value;
                NotifyPropertyChanged("DiriginteNume");
            }
        }

        public string AnStudiuID
        {
            get { return anStudiuID; }
            set
            {
                anStudiuID = value;
                NotifyPropertyChanged("AnStudiuID");
            }
        }
        public string AnStudiu
        {
            get { return anStudiu; }
            set
            {
                anStudiu = value;
                NotifyPropertyChanged("AnStudiu");
            }
        }

        public string SpecializareID
        {
            get { return specializareID; }
            set
            {
                specializareID = value;
                NotifyPropertyChanged("SpecializareID");
            }
        } 
        public string SpecializareNume
        {
            get { return specializareNume; }
            set
            {
                specializareNume = value;
                NotifyPropertyChanged("SpecializareNume");
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
    }
}
