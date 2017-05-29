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
    public class clsPublisherList : SortedDictionary<string, clsPublisher>
    {
        private const string _FileName = "inventory.dat";
        public void EditPublisher(string prKey)
        {
            clsPublisher lcPublisher;
            lcPublisher = this[prKey];
            if (lcPublisher != null)
                lcPublisher.EditDetails();
            else
                throw new Exception("Sorry no publisher by this name");
        }
        public void NewPublisher()
        {
            clsPublisher lcPublisher = new clsPublisher(this);
            if (lcPublisher.Name != "")
                Add(lcPublisher.Name, lcPublisher);
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsPublisher lcPublisher in Values)
            {
                lcTotal += lcPublisher.TotalValue;
            }
            return lcTotal;
        }

        public static clsPublisherList RetrievePublisherList()
        {
            clsPublisherList lcPublisherList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                BinaryFormatter lcFormatter = new BinaryFormatter();
                lcPublisherList = (clsPublisherList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                lcPublisherList = new clsPublisherList();
                throw new Exception("File Retrieve Error: " + ex.Message);
            }
            return lcPublisherList;
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
