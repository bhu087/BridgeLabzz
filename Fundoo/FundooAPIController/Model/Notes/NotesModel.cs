using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Account
{
    public class NotesModel
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
        private string collaboratator;

        [Key]
        public int NotesId1 { get => NotesId; set => NotesId = value; }
        public string Email { get => email; set => email = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? CreatedTime { get => createdTime; set => createdTime = value; }
        public DateTime? ModifiedTime { get => modifiedTime; set => modifiedTime = value; }
        public string Remainder { get => remainder; set => remainder = value; }
        public string Image { get => image; set => image = value; }
        public bool IsArchive { get => isArchive; set => isArchive = value; }
        public bool IsTrash { get => isTrash; set => isTrash = value; }
        public bool IsPin { get => isPin; set => isPin = value; }
        public string Color { get => color; set => color = value; }
        public string Collaboratator { get => collaboratator; set => collaboratator = value; }
    }
}
