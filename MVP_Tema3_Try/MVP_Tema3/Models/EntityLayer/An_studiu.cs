using System;

namespace MVP_Tema3.Models.EntityLayer
{
    public class An_studiu : BasePropertyChanged
    {
        private int? id;
        private string an;

        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string An
        {
            get { return an; }
            set
            {
                an = value;
                NotifyPropertyChanged("An");
            }
        }
    }
}
