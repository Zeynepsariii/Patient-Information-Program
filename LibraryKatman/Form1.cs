using Entitiy.Entities;
using System;
using DataAccesLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Infrastructure.Design;

namespace LibraryKatman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var DbContext = new DataAccesLayer.Context())
            {
                //dataGridView1.DataSource = DbContext.Patients.ToList();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var DbContext = new DataAccesLayer.Context())
            {

                int patientId ;
                if(!int.TryParse(textBox1.Text, out patientId)){
                    MessageBox.Show("ınvalıd patient id");
                    return;
                }

                var patient = DbContext.Patients.FirstOrDefault(p=> p.PatientId == patientId);
                if (patient == null)
                {
                    MessageBox.Show("patient not found");
                }

                MessageBox.Show("patient is delete");
                DbContext.Patients.Remove(patient);
                DbContext.SaveChanges();
                //dataGridView1.DataSource = DbContext.Patients.ToList();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dbContext = new DataAccesLayer.Context())
            {
                
                string PatientName = textBox2.Text;
                int PatientAge;
                string PatientSex = textBox4.Text;
                long PatientTC;
                int PatientPhone;
                string City = textBox7.Text;
                string PatientAdress = textBox8.Text;
                
                string PatientInformation = richTextBox1.Text;
                string Report = richTextBox2.Text;
                string TestResult = richTextBox3.Text;
                if (!int.TryParse(textBox3.Text, out PatientAge))
                {
                    MessageBox.Show("Invalid patient age");
                    return;
                }
                if (!long.TryParse(textBox5.Text, out PatientTC))
                {
                    MessageBox.Show("Invalid patient Tc");
                    return;
                }
                if (!int.TryParse(textBox6.Text, out PatientPhone))
                {
                    MessageBox.Show("Invalid patient Phone");
                    return;
                }


                if (string.IsNullOrWhiteSpace(PatientName))
                {
                    MessageBox.Show("Invalid patient name");
                    return;
                }
                if (string.IsNullOrWhiteSpace(PatientSex))
                {
                    MessageBox.Show("Invalid patient sex");
                    return;

                }
                
                if (string.IsNullOrWhiteSpace(City))
                {
                    MessageBox.Show("Invalid patient city");
                    return;
                }
                if (string.IsNullOrWhiteSpace(PatientAdress))
                {
                    MessageBox.Show("Invalid patient adress");
                    return;
                }



                var newPatient = new Entitiy.Entities.Patient
                {
                    PatientName = PatientName,
                    PatientAge = PatientAge,
                    PatientSex = PatientSex,
                    PatientTC = PatientTC,
                    PatientPhone = PatientPhone,
                    City=City,
                    PatientAdress=PatientAdress,
                    PatientInformation=PatientInformation,
                    Report=Report,
                    TestResult=TestResult,

                    
                };

                

                dbContext.Patients.Add(newPatient);
                dbContext.SaveChanges();
                MessageBox.Show("New patient added succesfuly");

                
                //dataGridView1.DataSource = dbContext.Patients.ToList();
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2=new Form2();
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible= true;
            richTextBox2.Visible= false;
            richTextBox3.Visible= false;
            string PatientInformation = richTextBox1.Text;
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Visible = true;
            richTextBox1 .Visible = false;
            richTextBox3.Visible = false;
            string Report = richTextBox2.Text;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox3.Visible = true;
            richTextBox2.Visible = false;
            richTextBox1.Visible = false;
            string TestResult = richTextBox3.Text;
            
        }
    }
}
