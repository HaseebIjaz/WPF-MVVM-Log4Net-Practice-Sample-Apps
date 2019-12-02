using System;
using ShapesWithMvvm.BaseClasses;
using ShapesWithMvvm.ViewModel;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;

namespace ShapesWithMvvm 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindowViewModel mvvm;




        public MainWindow()
        {
            mvvm = new MainWindowViewModel();
            InitializeComponent();
            this.DataContext = mvvm;
//            this.MouseDown += MainWindow_MouseDown;
        }


        //not being used
        //private void MainWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if(Mouse.DirectlyOver is Line)
        //    {
        //        Line selectedLine = Mouse.DirectlyOver as Line;
        //        bool isLineSelected = mvvm.Lines.Contains(selectedLine);
        //        if(isLineSelected)
        //        {
        //            selectedLine.X1 += 50;
                    
        //        }
        //    }
        //}
    }
}
