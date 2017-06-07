using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BookStore3
{
    public partial class frmAuthor : Form
    {
        private clsAuthor _Author;
        //private clsWorksList _WorksList;

        private static Dictionary<string, frmAuthor> _AuthorFormList = new Dictionary<string, frmAuthor>();

        private frmAuthor()
        {
            InitializeComponent();
        }

        public static void Run(string prAuthorName)
        {
            frmAuthor lcAuthorForm;
            if (string.IsNullOrEmpty(prAuthorName) ||
            !_AuthorFormList.TryGetValue(prAuthorName, out lcAuthorForm))
            {
                lcAuthorForm = new frmAuthor();
                if (string.IsNullOrEmpty(prAuthorName))
                    lcAuthorForm.SetDetails(new clsAuthor());
                else
                {
                    _AuthorFormList.Add(prAuthorName, lcAuthorForm);
                    lcAuthorForm.refreshFormFromDB(prAuthorName);
                }
            }
            else
            {
                lcAuthorForm.Show();
                lcAuthorForm.Activate();

            }

        }

        private async void refreshFormFromDB(string prAuthorName)
        {
            SetDetails(await ServiceClient.GetAuthorAsync(prAuthorName));
        }

        //async private void refreshFormFromDB(string prArtistName)
        //{
        //    //SetDetails(await ServiceClient.GetArtistAsync(prArtistName));
        //}





        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }

        private void UpdateDisplay()
        {
            //if (_WorksList.SortOrder == 0)
            // {
            //     _WorksList.SortByName();
            // rbByName.Checked = true;
            //  }
            //else
            // {
            //      _WorksList.SortByDate();
            //     rbByDate.Checked = true;
            // }

            //  lstWorks.DataSource = null;
            //  lstWorks.DataSource = _WorksList;
            //   lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public void UpdateForm()
        {
            txtName.Text = _Author.Name;
            txtCountry.Text = _Author.Country;
            //txtPhone.Text = _Artist.Phone;
            //_WorksList = _Artist.WorksList;

            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
        }

       public void SetDetails (clsAuthor prAuthor)
        {
            _Author = prAuthor;
            txtName.Enabled = string.IsNullOrEmpty(_Author.Name);
            UpdateForm();
            UpdateDisplay();
            frmMain.Instance.BookNameChanged += new frmMain.Notify(updateTitle);
            // updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        //private void pushData()
        //{
        //    _Artist.Name = txtName.Text;
        //    _Artist.Speciality = txtSpeciality.Text;
        //    _Artist.Phone = txtPhone.Text;
        //    //_WorksList.SortOrder = _SortOrder; // no longer required, updated with each rbByDate_CheckedChanged
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string lcReply = new InputBox(clsWork.FACTORY_PROMPT).Answer;
            // if (!string.IsNullOrEmpty(lcReply))
            {
                //  _WorksList.AddWork(lcReply[0]);
                UpdateDisplay();
                ///frmMain.Instance.UpdateDisplay();
            }
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //   _WorksList.EditWork(lstWorks.SelectedIndex);
                UpdateDisplay();
                //frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //int lcIndex = lstWorks.SelectedIndex;

            //if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //_WorksList.RemoveAt(lcIndex);
                UpdateDisplay();
              //  frmMain.Instance.UpdateDisplay();
            }
        }

        //private async void btnClose_Click(object sender, EventArgs e)
        //{
        //    if (isValid() == true)
        //        try
        //        {
        //            //pushData();
        //            if (txtName.Enabled)
        //            {
        //                //MessageBox.Show(await ServiceClient.InsertArtistAsync(_Artist));
        //                //frmMain.Instance.UpdateDisplay();
        //                txtName.Enabled = false;
        //            }
        //            else
        //               // MessageBox.Show(await ServiceClient.UpdateArtistAsync(_Artist));
        //            Hide();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //}

        private Boolean isValid()
        {
            // if (txtName.Enabled && txtName.Text != "")
            //if (_Artist.IsDuplicate(txtName.Text))
            // {
            //  MessageBox.Show("Artist with that name already exists!", "Error adding artist");
            //  return false;
            // }
            //else
            // return true;
            //else
            return true;
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            //  _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        private void frmArtist_Load(object sender, EventArgs e)
        {

        }
    }
}