using System;

namespace MVP_Tema3.Models.EntityLayer
{
    class Nota : BasePropertyChanged 
    {
        private int? id;
        private string studentID;
        private string materieID;
        private string dataNota;
        private string valoare;
        private string teza;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string StudentID
        {
            get { return studentID; }
            set
            {
                studentID = value;
                NotifyPropertyChanged("StudentID");
            }
        }

        public string MaterieID
        {
            get { return materieID; }
            set
            {
                materieID = value;
                NotifyPropertyChanged("MaterieID");
            }
        }

        public string DataNota
        {
            get { return dataNota; }
            set
            {
                dataNota = value;
                NotifyPropertyChanged("DataNota");
            }
        }

        public string Valoare
        {
            get { return valoare; }
            set
            {
                valoare = value;
                NotifyPropertyChanged("Valoare");
            }
        }

        public string Teza
        {
            get { return teza; }
            set
            {
                teza = value;
                NotifyPropertyChanged("Teza");
            }
        }
    }
}
