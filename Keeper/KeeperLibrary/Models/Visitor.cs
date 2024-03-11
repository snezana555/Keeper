using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public string? Company { get; set; }
        public DateTime DateBoth { get; set; }
        public int Number { get; set; }
        public int Series { get; set; }
        public byte[]? Image { get; set; }

    }
}
