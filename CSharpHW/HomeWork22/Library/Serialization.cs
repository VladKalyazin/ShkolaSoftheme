using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace Library
{
    public partial class BookLibrary : ISerializable
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Books", Books, typeof(List<Book>));
            info.AddValue("Users", Users, typeof(List<User>));
        }

        public BookLibrary(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Books = (List<Book>)info.GetValue("Books", typeof(List<Book>));
            Users = (List<User>)info.GetValue("Users", typeof(List<User>));
        }

        public void Serialize(IFormatter formatter)
        {
            using (FileStream s = new FileStream(DataFileName, FileMode.Create))
            {
                formatter.Serialize(s, this);
            }
        }

        public void Deserialize(IFormatter formatter)
        {
            try
            {
                using (FileStream s = new FileStream(DataFileName, FileMode.Open))
                {
                    BookLibrary lib = formatter.Deserialize(s) as BookLibrary;
                    if (lib != null)
                    {
                        this.Books = lib.Books;
                        this.Users = lib.Users;
                    }
                }
            }
            catch
            { }
        }
    }

}