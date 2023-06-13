namespace MVP_Tema3.Models.EntityLayer
{
    class Specializare : BasePropertyChanged 
    {
        private int? id;
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
