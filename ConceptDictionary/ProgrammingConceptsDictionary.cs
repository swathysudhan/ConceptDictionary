using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConceptDictionary
{
    public partial class ProgrammingConceptsDictionaryForm : Form
    {
        Category[] categoryData;
        ConceptDictionaryClass[] conceptArray;
        CategoryDataAccess categorydataaccess = new CategoryDataAccess("Data Source = ConceptDictionaryDB.db");
        ConceptDataAccess conceptdataAccess = new ConceptDataAccess("Data Source = ConceptDictionaryDB.db");
        public ProgrammingConceptsDictionaryForm()
        {
            InitializeComponent();
            categoryData = categorydataaccess.ReadAllCategory();
            for (int i = 0; i < categoryData.Length; i++)
            {
                comboBox1.Items.Add(categoryData[i].CategoryName);
               
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            string selectedItem = comboBox1.SelectedItem.ToString();
            conceptArray = conceptdataAccess.ReadAllConcept(selectedItem);
            for (int i = 0; i < conceptArray.Length; i++)
            {
                listBox1.Items.Add(conceptArray[i].Title.ToString());
            }
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
           
            
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            lblConceptTitle.Text = conceptArray[index].Title.ToString();
            richTextBox1.Text = conceptArray[index].Body.ToString();
            pictureBox1.Image = Image.FromFile(conceptArray[index].ConceptImage.ToString());
            conceptLinklbl.Text = conceptArray[index].ConceptLink1.ToString();
        }

        private void conceptLinklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var processes = Process.GetProcessesByName("Chrome");
            var path = processes.FirstOrDefault()?.MainModule?.FileName;
            string val = this.conceptLinklbl.Text;
            Process.Start(path, conceptArray[0].ConceptLink1.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ConceptDataManipulation form2 = new ConceptDataManipulation();
            form2.Show();
            this.Hide();
            
        }
    }
}
