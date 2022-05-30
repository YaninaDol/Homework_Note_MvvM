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
        private Note selectNote;

        public File_Model read_write = new File_Model();
        public ObservableCollection<Note> Notes { get; set; }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {

                List<Note> _search = null;
                if (value.Equals(string.Empty))
                {
                    _search = new List<Note>( read_write.notes);
                   
                }
                else
                {
                    _search = new List<Note>(Notes.Where(p => p.Title.Contains(value)).ToList());
                    

                }
                Notes.Clear();
                foreach (var item in _search)
                {
                    Notes.Add(item);
                }
                searchText = value;
                OnPropertyChanged("SearchText");
            }

        }

        public Note SelectNote
        {
            get { return selectNote; }
            set
            {
                selectNote = value;

                OnPropertyChanged("SelectNote");
            }
        }

        public ApplicationViewModel()
        {
            read_write.Read();
            Notes = new ObservableCollection<Note>(read_write.notes);

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
                   selectNote = _Note;
                   
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

                        if (selectNote != null)
                        {
                            Notes.Remove(selectNote);
                        }
                    }));


            }
            set { removeCommand = value; }
        }
       
        private RelayCommand sortDateCommand;
        public RelayCommand SortDateCommand
        {
            get
            {
                List<Note> sortDate = null;
                return sortDateCommand ??
                    (sortDateCommand = new RelayCommand(() =>
                    {
                      
                        sortDate = new List<Note>(Notes.OrderBy(p => p.Date).ToList());
                        Notes.Clear();
                        foreach (var item in sortDate)
                        {
                            Notes.Add(item);
                        }
                        
                    }));

            }
            set { sortDateCommand = value; }
        }
        private RelayCommand sortTitleCommand;
        public RelayCommand SortTitleCommand
        {
            get
            {
                List<Note> sortTitle = null;
                return sortTitleCommand ??
                    (sortTitleCommand = new RelayCommand(() =>
                    {
                        
                        sortTitle = new List<Note>(Notes.OrderBy(p => p.Title).ToList());
                        Notes.Clear();
                        foreach (var item in sortTitle)
                        {
                            Notes.Add(item);
                        }
                        
                    }));

            }
            set { sortTitleCommand = value; }
        }
    }
}
