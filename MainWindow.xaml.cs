using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;



namespace EditPortfolio
{
    
    
    public partial class MainWindow : Window
    {
        Dictionary<string,Proyects> ro;
        public MainWindow()
        {
            InitializeComponent();
            
            using (StreamReader r = new StreamReader("C:\\Users\\Usuario\\RiderProjects\\EditPortfolio\\data.json"))
            {
                string json = r.ReadToEnd();
                ro = JsonConvert.DeserializeObject<Dictionary<string,Proyects>>(json);
            }

            foreach (var project in ro)
            {
                
                string projectName = project.Key;
                Proyects projectDetails = project.Value;
                Label l = new Label();
                l.MouseLeftButtonDown += sss_MouseDown;
                l.Content = projectName;
                listBoxIzq.Items.Add(l);
                
            }
        }

        private void sss_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string key = (sender as Label).Content.ToString();
            
            Console.WriteLine($"Project Description: {ro[key].Description}");
            Console.WriteLine($"Language: {ro[key].Lenguaje}");
            Console.WriteLine($"Framework: {ro[key].Framework}");
            Console.WriteLine($"Type: {ro[key].Type}");

            textboxDescription.Text = ro[key].Description;
            textboxLenguaje.Text = ro[key].Lenguaje;
            textboxFramework.Text = ro[key].Framework;
            textboxType.Text = ro[key].Type;
            // Access other properties as needed
            Console.WriteLine("Photo Routes:");
            foreach (var photoRoute in ro[key].PhotoRoute)
            {
                Console.WriteLine(photoRoute);
            }

            Console.WriteLine("Photo Texts:");
            foreach (var photoText in ro[key].PhotoText)
            {
                Console.WriteLine(photoText);
            }

            Console.WriteLine();
        }   
    }
    
    
}