using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for DoctorManagament.xaml
    /// </summary>
    public partial class DoctorManagament : Window
    {
        public DoctorManagament()
        {
            InitializeComponent();

            //Link to db
            Database1Entities db = new Database1Entities();

            //Query all doctors
            var docs = from d in db.Doctors
                       select d;

            this.gridDoctors.ItemsSource= docs.ToList();
        }

        private void BtnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            Database1Entities db = new Database1Entities();

            int id = int.Parse(this.tbId.Text);
            string name = this.tbName.Text;
            string spec = this.tbSpec.Text;

            Doctor newDoctor = new Doctor()
            {
                Id = id,
                Name = name,
                Age = 25,
                Speciality = spec
            };

            try
            {
                db.Doctors.Add(newDoctor);
                db.SaveChanges();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            this.gridDoctors.ItemsSource = db.Doctors.ToList();

            Console.WriteLine("New Doctor Added !");
        }
    }
}
