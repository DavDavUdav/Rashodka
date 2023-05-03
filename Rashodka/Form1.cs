using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Rashodka
{
    public partial class Form1 : Form
    {
        public DataStore _dataStore = new DataStore();

        public Form1()
        {
            StartPosition= FormStartPosition.CenterScreen;
            InitializeComponent();
            MainLoad();
        }

        public void MainLoad()
        {
            _dataStore = new Rashodka.DataStore();
            _dataStore.Database.EnsureCreated();
            AllUpdate();
        }

        #region buttons
        
        public async void btn_Extradition_Click(object sender, EventArgs e)
        {
            if (cb_region.SelectedItem=="")
            {
                MessageBox.Show("Вы не выбрали район");
                return;
            }
            if (cb_consumables.SelectedItem=="")
            {
                MessageBox.Show("Вы не выбрали материал");
                return;
            }
            if (numericUpDown1.Value<=0)
            {
                MessageBox.Show("Введите число больше 0");
                return;
            }
            //.Where(x => x.Consumables.ConsumablesName == cb_consumables.Text)
             //   .Where(x => x.Region.RegionName == cb_region.Text)

            var extr = new Extradition()
            {
                ConsumablesId = _dataStore.Consumables
                    .Where(x => x.ConsumablesName == cb_consumables.Text)
                    .Select(x => x.ConsumablesId)
                    .FirstOrDefault(),
                RegionId = _dataStore.Region
                    .Where(x => x.RegionName == cb_region.Text)
                    .Select(x => x.RegionId)
                    .FirstOrDefault(),
                ConsumablesCount = Convert.ToInt32(numericUpDown1.Value),
                Date= DateTime.Now.Date,
            };


            //todo дописать функционал добавления записи в бд
            _dataStore.Extradition.Add(extr);



            var editCons = _dataStore.Consumables
                .Where(x => x.ConsumablesId == Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value))
                .FirstOrDefault();

            editCons.ConsumablesCount -= Convert.ToInt32(numericUpDown1.Value);

            dgv1.SelectedRows[0].Cells[2].Value = Convert.ToInt32(dgv1.SelectedRows[0].Cells[2].Value) - numericUpDown1.Value;
        }

        /// <summary>
        /// Обновление обновление данных на фроме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            AllUpdate();
        }
        
        #endregion buttons

        #region menustrip

        /// <summary>
        /// Добавление новых расходных материалов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void расходныйМатериалToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddConsumablesForm addConsumablesForm = new AddConsumablesForm();
            addConsumablesForm.StartPosition= FormStartPosition.CenterScreen;
            addConsumablesForm.Show();

            UpdateCbConsumables();
        }

        private void регионToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // todo дописать добавление регионов

            AddRegion addRegion = new AddRegion();
            addRegion.StartPosition= FormStartPosition.CenterScreen;
            addRegion.ShowDialog();

            UpdateCbRegion();
        }

        #endregion menustrip

        #region update

        /// <summary>
        /// Обновление данных
        /// </summary>
        public void AllUpdate()
        {
            UpdateDGVExtradition();
            UpdateCbConsumables();
            UpdateCbRegion();
        }

        /// <summary>
        /// Обновление данных о выдаче в DataGridView 
        /// </summary>
        public async void UpdateDGVExtradition()
        {
            var ext = await _dataStore.Extradition
                .Select(x => new Extradition()
                {
                    ExtraditionId= x.ExtraditionId,
                    ConsumablesId= x.ConsumablesId,
                    RegionId= x.RegionId,
                    Date= x.Date
                }).ToListAsync();
            dgv1.DataSource= ext;
        }

        /// <summary>
        /// обновление списка материалов в ComboBox
        /// </summary>
        public async void UpdateCbConsumables()
        {
            var _Conumables = await _dataStore.Consumables
                .Select(x => new Consumables()
                {
                    ConsumablesId = x.ConsumablesId,
                    ConsumablesName = x.ConsumablesName,
                    ConsumablesCount= x.ConsumablesCount
                }).ToListAsync();

            foreach (var cons in _Conumables)
            {
                cb_consumables.Items.Add(cons.ConsumablesName);
            }
        }

        /// <summary>
        /// Обновить список регионов в ComboBox
        /// </summary>
        public async void UpdateCbRegion()
        {
            cb_region.Items.Clear();

            var regions = await _dataStore.Region
                .Select(x => new LoadRegions()
                {
                    RegionId = x.RegionId,
                    RegionName = x.RegionName
                }).ToArrayAsync();

            foreach(var region in regions)
            {
                cb_region.Items.Add(region.RegionName);
            }
        }

        #endregion update

        #region validate
        
        public bool CheckInputConsumables(string s1, string s2)
        {
            if (s1 == "" || s2 == "")
            {
                MessageBox.Show("Вы не ввели название или количество");
                return false;
            }

            if (double.TryParse(s2, out double num))
            { }
            else
            { MessageBox.Show("Количество материала введено некорректно"); return false; }
            return true;
        }

        #endregion validate

        public async Task<bool> AddConsumables(string s1, string s2)
        {
            var cons = new Consumables()
            {
                //ConsumablesName = textBox1.Text,
                //ConsumablesCount = int.Parse(textBox2.Text)
            };

            _dataStore.Consumables.Add(cons);

            await _dataStore.SaveChangesAsync();
            UpdateCbConsumables();
            return true;
        }

        #region other
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        #endregion other

        /// <summary>
        /// Подстановка значений в combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cb_Region_TextUpdate(object sender, EventArgs e)
        {

            if (this.cb_region.Text!="")
            {
                string st = this.cb_region.Text;
                
                cb_region.Items.Clear();
                
                var search_region = await _dataStore.Region
                    .Where(x => EF.Functions.Like(x.RegionName, $"%{st}%"))
                    .Select(x => new LoadRegions()
                    {
                        RegionId = x.RegionId,
                        RegionName = x.RegionName
                    }).ToListAsync();

                cb_region.SelectionStart = cb_region.Text.Length;
                if (search_region.Count > 0)
                {
                    foreach (var region in search_region)
                    {
                        cb_region.Items.Add(region.RegionName);
                        
                    }

                    this.cb_region.Text = st;
                    this.cb_region.DroppedDown = true;

                }
                else
                {
                    this.cb_region.Text = st;
                    cb_region.SelectionStart = cb_region.Text.Length;
                    this.cb_region.Items.Clear();
                    UpdateCbRegion();
                    

                }

                cb_region.SelectionStart = cb_region.Text.Length;
            }
        }

        /// <summary>
        /// Подстановка значений в combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cb_consumables_TextUpdate(object sender, EventArgs e)
        {
            if (this.cb_consumables.Text != "")
            {
                string st = this.cb_consumables.Text;

                cb_consumables.Items.Clear();

                var search_consumables = await _dataStore.Consumables
                    .Where(x => EF.Functions.Like(x.ConsumablesName, $"%{st}%"))
                    .Select(x => new LoadConsumables()
                    {
                        ConsumablesId=x.ConsumablesId,
                        ConsumablesName= x.ConsumablesName
                    }).ToListAsync();
            }
        }

    }

    /// <summary>
    /// Таблица районов.
    /// </summary>
    public class LoadRegions
    {
        [DisplayName("ID")]
        public int RegionId { get; set; }
        [DisplayName("Регион")]
        public string RegionName { get; set; }
    }

    /// <summary>
    /// Таблица расходные материалы
    /// </summary>
    public class LoadConsumables //расходные материалы
    {
        [DisplayName("ID")]
        public int ConsumablesId { get; set; }
        [Required, DisplayName("Наименование")]
        public string ConsumablesName { get; set; }
        [Required, DisplayName("Количество")]
        public int ConsumablesCount { get; set; }
    }

    public class LoadExtradition // выдача расходки
    {
        [DisplayName("ID")]
        public int ExtraditionId { get; set; }
        [DisplayName("Id материала")]
        public int ConsumablesId { get; set; }
        [DisplayName("Id региона")]
        public int RegionId { get; set; }
        [DisplayName("Кол-во материала")]
        public int ConsumablesCount { get; set; }
        public DateTime Date { get; set; }
    }
}