using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Account
{
    class NotesModel
    {
        private int NotesId;
        private string email;
        private string title;
        private string description;
        private DateTime? createdTime;
        private DateTime? modifiedTime;
        private string remainder;
        private string image;
        private bool isArchive;
        private bool isTrash;
        private bool isPin;
        private string color;
    }
}
