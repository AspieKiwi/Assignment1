using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BookStoreWindows
{
    public partial class frmAuthor : Form
    {
        private clsAuthor _Author;

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
            try
            {
                SetDetails(await ServiceClient.GetAuthorAsync(prAuthorName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }




        private void updateTitle(string prBookName)
        {
            if (!string.IsNullOrEmpty(prBookName))
                Text = "Author Details - " + prBookName;
        }

        private void UpdateDisplay()
        {
            lstBooks.DataSource = null;
            lstBooks.DataSource = _Author.BooksList;
        }

        public void UpdateForm()
        {
            txtName.Text = _Author.Name;
            txtCountry.Text = _Author.Country;
        }

       public void SetDetails (clsAuthor prAuthor)
        {
            _Author = prAuthor;
            txtName.Enabled = string.IsNullOrEmpty(_Author.Name);
            UpdateForm();
            UpdateDisplay();
            frmMain.Instance.BookNameChanged += new frmMain.Notify(updateTitle);
            Show();
        }

        private void pushData()
        {
            _Author.Name = txtName.Text;
            _Author.Country = txtCountry.Text;
        }

       

       

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstBooks.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteBookAsync(lstBooks.SelectedItem as clsAllBooks));
                refreshFormFromDB(_Author.Name);
                frmMain.Instance.updateDisplay();
            }
        }

       

        private void frmArtist_Load(object sender, EventArgs e)
        {

        }

        private void lstBooks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmBook.DispatchBookFrom(lstBooks.SelectedValue as clsAllBooks);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string lcReply = new InputBox(clsAllBooks.FACTORY_PROMPT).Answer;
                if (!string.IsNullOrEmpty(lcReply))
                {
                    clsAllBooks lcBook = clsAllBooks.NewBook(lcReply[0]);
                    if(lcBook != null)
                    {
                        if (txtName.Enabled)
                        {
                            pushData();
                            await ServiceClient.InsertAuthorAsync(_Author);
                            txtName.Enabled = false;
                        }
                        lcBook.AuthorName = _Author.Name;
                        frmBook.DispatchBookFrom(lcBook);
                        if (!string.IsNullOrEmpty(lcBook.BookTitle))
                        {
                            refreshFormFromDB(_Author.Name);
                            frmMain.Instance.updateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateAuthorBooks()
        {
            try
            {
                frmBook.DispatchBookFrom(lstBooks.SelectedValue as clsAllBooks);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain.Instance.updateDisplay();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}