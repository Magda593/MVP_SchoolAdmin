using System;

namespace MVP_Tema3.Models.EntityLayer
{
    public class Absenta : BasePropertyChanged
    {
        private int? id;
        private string studentID;
        private string materieID;
        private DateTime? dataAbsenta;

        public int? ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string StudentID
        {
            get
            {
                return studentID;
            }
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

        public DateTime? DataAbsenta
        {
            get { return dataAbsenta; }
            set
            {
                dataAbsenta = value;
                NotifyPropertyChanged("DataAbsenta");
            }
        }
    }
}
