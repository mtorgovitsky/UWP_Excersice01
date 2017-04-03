using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Excersice01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<string> items = new List<string>
                { "first", "second", "third", "fourth", "fifth",
                "sixth", "seventh", "eighth", "nineth", "tenth" };

        public MainPage()
        {
            this.InitializeComponent();

            asbSearch.TextChanged += (sender, args) =>
            {
                asbSearch.ItemsSource = items.Where(s => s.StartsWith(asbSearch.Text));
            };
        }

        private async void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgDialog = new MessageDialog("Want to Buy?", "Buy");

            msgDialog.Commands.Add(new UICommand("Buy Now", buy, 1));
            msgDialog.Commands.Add(new UICommand("Maybe Later", buy, 2));
            msgDialog.Commands.Add(new UICommand("Leave Me Alone!", buy, 3));

            var res = await msgDialog.ShowAsync();

            int tmpRes = (int)res.Id;

            switch (tmpRes)
            {
                case 1:
                    items.Remove(asbSearch.Text);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void buy(IUICommand command)
        {
            //throw new NotImplementedException();
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
