using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookCRUD_V2.UserModel
{
    public interface IUser
    {
        bool Login(string pass);
        void Register();

        int getID();
    }
}
