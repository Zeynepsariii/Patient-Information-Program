using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryKatman
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var DbContext = new DataAccesLayer.Context())
            {
                dataGridView1.DataSource = DbContext.Patients.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dbContext = new DataAccesLayer.Context())
            {
                var patients = dbContext.Patients.AsQueryable();

                int patientId;
                if (int.TryParse(textBox1.Text, out patientId))
                {
                    patients = patients.Where(p => p.PatientId == patientId);
                }

                string patientName = textBox2.Text;
                if (!string.IsNullOrWhiteSpace(patientName))
                {
                    patients = patients.Where(p => p.PatientName == patientName);
                }

                int patientAge;
                if (int.TryParse(textBox3.Text, out patientAge))
                {
                    patients = patients.Where(p => p.PatientAge == patientAge);
                }
                string patientSex = textBox4.Text;
                if (!string.IsNullOrWhiteSpace(patientSex))
                {
                    patients = patients.Where(p => p.PatientSex == patientSex);
                }
                long patientTc;
                if (long.TryParse(textBox5.Text, out patientTc))
                {
                    patients = patients.Where(p => p.PatientTC == patientTc);
                }
                int patientPhone;
                if (int.TryParse(textBox6.Text, out patientPhone))
                {
                    patients = patients.Where(p => p.PatientPhone == patientPhone);
                }
                string city = textBox7.Text;
                if (!string.IsNullOrWhiteSpace(city))
                {
                    patients = patients.Where(p => p.City == city);
                }
                string patientAdress = textBox8.Text;
                if (!string.IsNullOrWhiteSpace(patientAdress))
                {
                    patients = patients.Where(p => p.PatientAdress == patientAdress);
                }

                if (!patients.Any())
                {
                    MessageBox.Show("Patient not found");
                    return;
                }



                dataGridView1.DataSource = patients.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
