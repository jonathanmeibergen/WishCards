using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.Attributes
{
    public class FileTypeAttribute : Attribute
    {
        private string _filetype;
        public string FileType { get => _filetype; set => _filetype = value; }

        public FileTypeAttribute(string filetype)
        {
            FileType = filetype;
        }
    }
}
