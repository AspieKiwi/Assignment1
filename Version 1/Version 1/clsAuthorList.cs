using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace Version_1
{
    [Serializable()]
    public class clsAuthorList : SortedDictionary<string, clsAuthor>
    {
        private const string _FileName = "inventory.dat";
        private string _BookName;


        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsAuthor lcAuthor in Values)
            {
                lcTotal += lcAuthor.TotalValue;
            }
            return lcTotal;
        }

        public string BookName
        {
            get { return _BookName; }
            set { _BookName = value; }
        }

        public static clsAuthorList RetrieveAuthorList()
        {
            clsAuthorList lcAuthorList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                BinaryFormatter lcFormatter = new BinaryFormatter();
                lcAuthorList = (clsAuthorList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                lcAuthorList = new clsAuthorList();
                throw new Exception("File Retrieve Error: " + ex.Message);
            }
            return lcAuthorList;
        }

        public void Save()
        {
            System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
            BinaryFormatter lcFormatter = new BinaryFormatter();
            lcFormatter.Serialize(lcFileStream, this);
            lcFileStream.Close();
        }
    }
}
