using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;


namespace MediAssist_Desktop_App.Sealed_Class
{
    public sealed class SaveToTxt
    {
        public SaveToTxt() { }

        public void SaveNote(Note note)
        {
            while (note.Text.Trim().Length > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                {
                    sfd.FileName = note.ID+"."+note.Subject+" ("+note.Owner_obj.Username+")";
                    sfd.Filter = "Text file (*.txt)|*.txt";
                    sfd.DefaultExt = "txt";
                    sfd.FilterIndex = 0;
                    sfd.RestoreDirectory = true;
                    sfd.Title = "Save File";
                    sfd.CheckFileExists = false;
                    sfd.CheckPathExists = false;
                    sfd.OverwritePrompt = true;
                    sfd.ValidateNames = true;
                };

                while (sfd.ShowDialog() == true)
                {
                    File.WriteAllText(sfd.FileName, note.Text);
                    break;
                }
                break;
            }
        }
    }
}
