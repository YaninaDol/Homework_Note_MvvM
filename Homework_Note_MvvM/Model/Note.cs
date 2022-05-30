using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Note_MvvM.Model
{
    public class Note : INotifyPropertyChanged
    {
        public string Date;
        public string Title;
        public string TextNote;

        public Note(string date, string title, string textNote)
        {
            this.Date = date;
            this.Title = title;
            this.TextNote = textNote;
          
        }
        public Note()
        {
            this.Date = DateTime.Now.ToShortDateString();
        }



        public string title
        {
            get { return Title; }
            set
            {
                Title = value;

                OnPropertyChanged("Title");
                
            }
        }
        public string textNote
        {
            get { return TextNote; }
            set
            {
                TextNote = value;
                OnPropertyChanged("TextNote");
            }
        }
        public string date
        {
            get { return Date; }
            set
            {
                Date = value;
                OnPropertyChanged("Date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return $"{Date}\t{Title}\t{TextNote}\n";
        }
    }
}
