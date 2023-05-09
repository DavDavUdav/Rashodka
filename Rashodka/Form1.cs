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
            if (string.IsNullOrWhiteSpace(cb_region?.SelectedItem.ToString()))
            {
                MessageBox.Show("�� �� ������� �����");
                return;
            }
            if (string.IsNullOrWhiteSpace(cb_consumables.SelectedItem.ToString()))
            {
                MessageBox.Show("�� �� ������� ��������");
                return;
            }
            if (Decimal.ToInt32(numericUpDown1.Value)<=0)
            {
                MessageBox.Show("������� ����� ������ 0");
                return;
            }

            //todo �������� ���������� ��������� �������� � �� � ��������� ���������� ���������

            var getcons1 = await _dataStore.Consumables
                .Where(x => x.ConsumablesName == cb_consumables.SelectedItem.ToString())
                .Select(x => new LoadConsumables
                {
                    ConsumablesId= x.ConsumablesId,
                    ConsumablesName= x.ConsumablesName,
                    ConsumablesCount= x.ConsumablesCount
                })
                .ToListAsync();



            var getcons = await _dataStore.Consumables
                .FirstAsync(x => x.ConsumablesName == cb_consumables.SelectedItem.ToString());



            if (getcons.ConsumablesCount < numericUpDown1.Value)
            {
                MessageBox.Show($"�������� ����������. �� ������ ������ �� ����� {getcons.ConsumablesCount}");
            }

            var sum = getcons.ConsumablesCount -= Convert.ToInt32(numericUpDown1.Value);

            getcons.ConsumablesCount = sum;
            _dataStore.Consumables.Update(getcons);
            await _dataStore.SaveChangesAsync();


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
                Date= DateTime.Now.Date
            };

            
            _dataStore.Extradition.Add(extr);
            await _dataStore.SaveChangesAsync();
            UpdateDGVExtradition();
        }

        /// <summary>
        /// ���������� ���������� ������ �� �����
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
        /// ���������� ����� ��������� ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �����������������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddConsumablesForm addConsumablesForm = new AddConsumablesForm();
            addConsumablesForm.StartPosition= FormStartPosition.CenterScreen;
            addConsumablesForm.Show();

            UpdateCbConsumables();
        }

        private void ������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // todo �������� ���������� ��������

            AddRegion addRegion = new AddRegion();
            addRegion.StartPosition= FormStartPosition.CenterScreen;
            addRegion.ShowDialog();

            UpdateCbRegion();
        }

        #endregion menustrip

        #region update

        /// <summary>
        /// ���������� ������
        /// </summary>
        public void AllUpdate()
        {
            UpdateDGVExtradition();
            UpdateCbConsumables();
            UpdateCbRegion();
        }

        /// <summary>
        /// ���������� ������ � ������ � DataGridView 
        /// </summary>
        public async void UpdateDGVExtradition()
        {
            
            var ext = await _dataStore.Extradition
                .Select(x => new LoadExtradition1()
                {
                    ExtraditionId = x.ExtraditionId,
                    ConsumablesName = _dataStore.Consumables
                        .First(y => y.ConsumablesId == x.ConsumablesId).ConsumablesName,
                    ConsumablesCount = x.ConsumablesCount,
                    RegionName = _dataStore.Region
                        .First(y => y.RegionId == x.RegionId).RegionName,
                    Date = x.Date
                }).ToListAsync();

            dgv1.DataSource = ext;
        }

        public async void UpdateDGVConsumables()
        {
            var cons = await _dataStore.Consumables
                .Select(x => new LoadConsumables()
                {
                    ConsumablesId = x.ConsumablesId,
                    ConsumablesName = x.ConsumablesName,
                    ConsumablesCount = x.ConsumablesCount
                }).ToListAsync();
            dgv_warehouse.DataSource = cons;
        }

        /// <summary>
        /// ���������� ������ ���������� � ComboBox
        /// </summary>
        public async void UpdateCbConsumables()
        {
            cb_consumables.Items.Clear();
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
        /// �������� ������ �������� � ComboBox
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
                MessageBox.Show("�� �� ����� �������� ��� ����������");
                return false;
            }

            if (double.TryParse(s2, out double num))
            { }
            else
            { MessageBox.Show("���������� ��������� ������� �����������"); return false; }
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
        /// ����������� �������� � combobox
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
                if (Decimal.ToInt32(search_region.Count) > 0)
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
        /// ����������� �������� � combobox
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
                cb_consumables.SelectionStart = cb_consumables.SelectionLength;

                if (Decimal.ToInt32(search_consumables.Count)>0)
                {
                    foreach (var cons in search_consumables)
                    {
                        cb_region.Items.Add(cons.ConsumablesName);
                    }

                    this.cb_consumables.Text = st;
                    this.cb_consumables.DroppedDown = true;
                }
            }
        }

        

        private void btn_update_warehouse_Click(object sender, EventArgs e)
        {
            UpdateDGVConsumables();
        }
    }

    /// <summary>
    /// ������� �������.
    /// </summary>
    public class LoadRegions
    {
        [DisplayName("ID")]
        public int RegionId { get; set; }
        [Required, DisplayName("������")]
        public string RegionName { get; set; }
    }

    /// <summary>
    /// ������� ��������� ���������
    /// </summary>
    public class LoadConsumables //��������� ���������
    {
        [DisplayName("ID")]
        public int ConsumablesId { get; set; }
        [Required, DisplayName("������������")]
        public string ConsumablesName { get; set; }
        [Required, DisplayName("����������")]
        public int ConsumablesCount { get; set; }
    }

    public class LoadExtradition // ������ ��������
    {
        [DisplayName("ID")]
        public int ExtraditionId { get; set; }
        [DisplayName("Id ���������")]
        public int ConsumablesId { get; set; }
        [DisplayName("Id �������")]
        public int RegionId { get; set; }
        [DisplayName("���-�� ���������")]
        public int ConsumablesCount { get; set; }
        [Required, DisplayName("����")] 
        public DateTime Date { get; set; }
    }

    public class LoadExtradition1 // ������ ��������
    {
        [DisplayName("ID")]
        public int ExtraditionId { get; set; }
        [Required, DisplayName("��������")]
        public string ConsumablesName { get; set; }
        [Required, DisplayName("������")]
        public string RegionName { get; set; }
        [Required, DisplayName("���-�� ���������")]
        public int ConsumablesCount { get; set; }
        [Required, DisplayName("����")]
        public DateTime Date { get; set; }
    }
}