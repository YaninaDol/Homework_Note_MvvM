using GalaSoft.MvvmLight.Command;
using Homework_Note_MvvM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Note_MvvM.ViewModel
{
    public class ApplicationViewModel
    {
        public Note SelectNote;
        public File_Model read_write =new File_Model();
        public ObservableCollection<Note> Notes { get; set; }


        public Note selectNote
        {
            get { return SelectNote; }
            set
            {
              
                SelectNote = value;
                OnPropertyChanged("selectNote");
            }
        }

        public ApplicationViewModel()
        {
            Notes = new ObservableCollection<Note>();
            read_write.Read(Notes);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                 return addCommand ?? (addCommand = new RelayCommand(() =>
                {
                    Note _Note = new Note();
                    Notes.Add(_Note);
                    SelectNote = _Note;
                    read_write.Write(Notes);
                }));
            }
            set { addCommand = value; }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(() =>
                    {

                        if (SelectNote != null)
                        {
                            Notes.Remove(SelectNote);
                        }
                    }));
              

            }
            set { removeCommand = value; }
        }
      
      
    }
}
