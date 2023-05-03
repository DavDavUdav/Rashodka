using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rashodka
{
    public partial class AddRegion : Form
    {
        public Rashodka.DataStore _dataStore = new DataStore();

        public AddRegion()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите корректное наименование региона");
                return;
            }
            if(Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Введите корректное наименование региона");
                return;
            }

            var region = new Region()
            {
                RegionName = textBox1.Text
            };

            _dataStore.Region.Add(region);
            await _dataStore.SaveChangesAsync();

            MessageBox.Show("Регион был успешно добавлен");
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
