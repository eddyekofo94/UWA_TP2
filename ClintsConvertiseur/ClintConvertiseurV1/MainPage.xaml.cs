using ClintConvertiseurV1.Model;
using ClintConvertiseurV1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClintConvertiseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Variables
        private int amount_in_euros;
        private double result_devise;

        Convert c = new Convert();

        Devise devise = new Devise();
       
        public MainPage()
        {
            this.InitializeComponent();

            //...

            ActionGetData();
        }

        private void convertir_Click(object sender, RoutedEventArgs e)
        {
            this.amount_in_euros = (int) c.ToDouble(euros_input.Text);
            //Cast the combobox selected item to Devise, then select the "taux" and mulitiply it to the amount of euro inputed.
            this.result_devise = amount_in_euros * ((Devise)this.liste_devises.SelectedItem).taux;

            setOutputResult(result_devise);
        }

        public string setOutputResult(double result)
        {
            return devises_output.Text = this.result_devise.ToString();
        }

        private async void ActionGetData()
        {
            var result = await WSService.Instance.getAllDeviseAsync();
            //Returning a list of devises
            this.liste_devises.DataContext = (List<Devise>)(result);
        }

    }
}
