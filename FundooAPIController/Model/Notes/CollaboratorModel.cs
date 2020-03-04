using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Notes
{
    public class CollaboratorModel
    {
        private int id;
        private int noteId;
        private string senderEmail;
        private string ReceiverEmail;
        [Key]
        public int Id { get => id; set => id = value; }
        public int NoteId { get => noteId; set => noteId = value; }
        public string SenderEmail { get => senderEmail; set => senderEmail = value; }
        public string ReceiverEmail1 { get => ReceiverEmail; set => ReceiverEmail = value; }
    }
}
