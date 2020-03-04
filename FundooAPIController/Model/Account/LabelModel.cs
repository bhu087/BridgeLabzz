using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Account
{
    public class LabelModel
    {
        private int id;
        private int labelId;
        private string labelName;
        [Key]
        public int Id { get => id; set => id = value; }
        public int LabelId { get => labelId; set => labelId = value; }
        public string LabelName { get => labelName; set => labelName = value; }
    }
}
