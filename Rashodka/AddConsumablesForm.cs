using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rashodka
{
    public partial class AddConsumablesForm : Form
    {
        public Rashodka.DataStore _dataStore = new DataStore();

        public AddConsumablesForm()
        {
            
            InitializeComponent();
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            #region validate
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите корректное наименование");
                return;
            }
            if (Regex.IsMatch(textBox1.Text, @"^[\w\\\/]+$"))
            {
                MessageBox.Show("ДЛя ввода допускаются только буквы и цифры");
                return;
            }
            if (NumUD_count.Value<=0)
            {
                MessageBox.Show("Количество должно быть больше 0");
                return;
            }

            #endregion validate

            var cons = new Consumables()
            {
                ConsumablesName = textBox1.Text,
                ConsumablesCount = Convert.ToInt32(NumUD_count.Value)
            };
            _dataStore.Consumables.Add(cons);
            await _dataStore.SaveChangesAsync();

            MessageBox.Show("Регион был успешно добавлен");
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

   
}
