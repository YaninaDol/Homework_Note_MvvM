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


namespace Homework_Note_MvvM.Model
{
    public class File_Model
    {
        public ObservableCollection<Note> notes { get; set; }
        public string Path;
        
        public File_Model()
        {
            notes = new ObservableCollection<Note>();
            Path = "MyNotes.txt";
        }
        public void Write(ObservableCollection<Note> _notes)
        {
            File.Delete(Path);
            foreach (var item in _notes)
            {
                File.AppendAllText(Path, item.ToString());
            }
        }
        public void Read()
        {
            if (File.Exists(Path))
            {
                string str = File.ReadAllText(Path);
                string[] splStr = str.Split('\n');
                for (int i = 0; i < splStr.Length - 1; i++)
                {
                    string rez = splStr[i];
                    string[] value = rez.Split('\t');

                    this.notes.Add(new Note(value[0], value[1], value[2]));
                }
            }
          
        }
    }
}
