using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConceptDictionary
{
    public partial class ConceptDataManipulation : Form
    {
        int categoryID = 0;
        string filePath = string.Empty;
        ConceptDictionary newobj;
        ConceptDictionary[] conceptArray;
        Category[] categoryData;
        CategoryDataAccess categorydataaccess = new CategoryDataAccess("Data Source = ConceptDictionaryDB.db");
        ConceptDataAccess conceptdataAccess = new ConceptDataAccess("Data Source = ConceptDictionaryDB.db");
        public ConceptDataManipulation()
        {
            InitializeComponent();
            categoryData = categorydataaccess.ReadAllCategory();
            for (int i = 0; i < categoryData.Length; i++)
            {
                comboBox1.Items.Add(categoryData[i].CategoryName);

            }
        }

        //private void CheckAllValuesEntered(ConceptDictionary newObj)
        //{
        //    if (chkboxCommonCoding.Checked == true)
        //    {
        //        categoryID = 2;
        //        conceptdataAccess.InsertConceptValue(newobj, categoryID);
        //    }
        //    else if (chkboxSDLC.Checked == true)
        //    {
        //        categoryID = 1;
        //        conceptdataAccess.InsertConceptValue(newobj, categoryID);
        //    }
        //    else if (chkboxOOPs.Checked == true)
        //    {
        //        categoryID = 3;
        //        conceptdataAccess.InsertConceptValue(newobj, categoryID);
        //    }
        //    else if (chkboxTesting.Checked == true)
        //    {
        //        categoryID = 4;
        //        conceptdataAccess.InsertConceptValue(newobj, categoryID);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Category not selected");
        //    }
        //}
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if ((txtTitle.Text == string.Empty) || (txtURi.Text == String.Empty) || (richTextBox1.Text == string.Empty))
            {
                MessageBox.Show("Values are missing");
            }
            categoryID = comboBox1.SelectedIndex +1 ;
            newobj = new ConceptDictionary(txtTitle.Text, richTextBox1.Text, filePath, txtURi.Text);
            conceptdataAccess.InsertConceptValue(newobj, categoryID);

            //  CheckAllValuesEntered(newobj);


        }

        private void SelectImageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\karth\\source\\repos\\ConceptDictionary\\ConceptDictionary\\bin\\Debug\\netcoreapp3.1";
            openFileDialog1.Filter = "img files (*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
            filePath = openFileDialog1.FileName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selectedItem = comboBox1.SelectedItem.ToString();
            conceptArray = conceptdataAccess.ReadAllConcept(selectedItem);
            for (int i = 0; i < conceptArray.Length; i++)
            {
                listBox1.Items.Add(conceptArray[i].ConceptID1.ToString() +" " + conceptArray[i].Title.ToString());
            }
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string val = listBox1.SelectedItem.ToString();
                int subval = Convert.ToInt32(val.Substring(0, 1));
                string subval2 = val.Substring(1, (val.Length - 1));
                for (int i = 0; i < conceptArray.Length; i++)
                {
                    if (conceptArray[i].ConceptID1 == subval)
                    {
                        txtTitle.Text = conceptArray[i].Title;
                        txtURi.Text = conceptArray[i].ConceptLink1;
                        richTextBox1.Text = conceptArray[i].Body;
                    }
                }
            }
            catch(System.NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string val = listBox1.SelectedItem.ToString();
                int subval = Convert.ToInt32(val.Substring(0, 1));
                conceptdataAccess.DeleteConceptValue(subval);
            }
            catch(System.NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Deleted Sucessfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string val = listBox1.SelectedItem.ToString();
                int subval = Convert.ToInt32(val.Substring(0, 1));
                string subval2 = val.Substring(1, (val.Length - 1));
                for (int i = 0; i < conceptArray.Length; i++)
                {
                    if (conceptArray[i].Title == subval2)
                    {
                        txtTitle.Text = conceptArray[i].Title;
                        txtURi.Text = conceptArray[i].ConceptLink1;
                        richTextBox1.Text = conceptArray[i].Body;
                    }
                }
                if ((txtTitle.Text == string.Empty) || (txtURi.Text == String.Empty) || (richTextBox1.Text == string.Empty))
                {
                    MessageBox.Show("Values are missing");
                }
                newobj = new ConceptDictionary(subval, txtTitle.Text, richTextBox1.Text, filePath, txtURi.Text, categoryID);
                conceptdataAccess.UpdateConceptValue(newobj);
                MessageBox.Show("Updated Successfully");
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
