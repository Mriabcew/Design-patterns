using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookCRUD_V2.NoteModel
{
    public class Note:INote
    {
        private string title;
        private string body;
        private int id;

        public Note(int id,string title,string body)
        {
            this.title = title;
            this.body = body;
            this.id = id;
        }
        public string getTitle()
        {
            return title;
        }
        public string getBody()
        {
            return body;
        }

        public int getID()
        { return id; }
    }
}
