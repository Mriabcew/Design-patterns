using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookCRUD_V2.NoteModel
{
    public interface INote
    {
        string getTitle();
        string getBody();

        int getID();
    }
}
