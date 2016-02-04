using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            this.dataGridView1.Scroll += dataGridView1_Scroll;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation != ScrollOrientation.HorizontalScroll)
            {
                return;
            }

            var changed = e.NewValue - e.OldValue;

            foreach (var ckbox in this.panel1.Controls)
            {
                if (!(ckbox is CheckBox))
                {
                    continue;
                }

                (ckbox as CheckBox).Left -= changed;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    CheckBox ckBox = new CheckBox();
            //    ckBox.Name = string.Format("ckbox_{0}", i);
            //    ckBox.Text = ckBox.Name;
            //    ckBox.Size = new System.Drawing.Size(100, 25);
            //    ckBox.Top = 10;
            //    ckBox.Left = ckBox.Size.Width * i;

            //    this.panel1.Controls.Add(ckBox);
            //}

            System.Data.DataTable dt = new DataTable();
            for (int i = 0; i < 10; i++)
            {
                dt.Columns.Add(string.Format("name{0}", i), typeof(String));
            }

            for (int i = 0; i < 10; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = "bigken";
                }
                dt.Rows.Add(dr);
            }

            this.dataGridView1.DataSource = dt;

            //这里干掉，否则对不齐
            this.dataGridView1.RowHeadersVisible = false;

            int left = 0;

            foreach (System.Windows.Forms.DataGridViewColumn col in this.dataGridView1.Columns)
            {
                //添加列里生成ckbox
                var colName = col.Name;
                var ckbox = new CheckBox();
                ckbox.Name = "ckbox_" + colName;
                ckbox.Width = col.Width;
                ckbox.Height = 25;
                ckbox.Text = colName;
                ckbox.CheckedChanged += ckbox_CheckedChanged;

                ckbox.Left = left;

                this.panel1.Controls.Add(ckbox);

                left += ckbox.Width;
            }
        }

        void ckbox_CheckedChanged(object sender, EventArgs e)
        {
            var ckbox = (sender as CheckBox);

            var status = ckbox.Checked;

            if (ckbox.Text == "name0"/*表名*/)
            {
                ckbox_name0_CheckedChanged();
            }

            if (ckbox.Text == "name1"/*表名*/)
            {
                ckbox_name1_CheckedChanged();
            }

            //todo
            //或者这里使用反射来动态执行
        }

        void ckbox_name0_CheckedChanged()
        {
            MessageBox.Show("bigken is good");
        }

        void ckbox_name1_CheckedChanged()
        {
            MessageBox.Show("qingqing is good");
        }

        static int CLICK_COUNT = 0;

        private void monthCalendar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CLICK_COUNT += 1;
            }

            if (CLICK_COUNT == 2)
            {
                CLICK_COUNT = 0;
                MessageBox.Show("12");

            }
        }
    }
}