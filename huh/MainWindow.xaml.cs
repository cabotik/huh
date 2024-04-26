
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Text;
using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;






namespace huh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string inte;
        Graph graph = new Graph();
        public string integ;

        List<GraphField> graphs = new List<GraphField>();


        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            FirstSP.Visibility = Visibility.Collapsed;
            spSettingLabel.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnPChart_Click(object sender, RoutedEventArgs e)
        {
            spExport.Visibility = Visibility.Visible;
            graph.graphType = "PieChart";
           
        }

        private void btnHGrahp_Click(object sender, RoutedEventArgs e)
        {
            spExport.Visibility = Visibility.Visible;
            graph.graphType = "HGraph";
        }

        private void btnVGraph_Click(object sender, RoutedEventArgs e)
        {
            spExport.Visibility = Visibility.Visible;
            graph.graphType = "VGraph";

        }

        private void btnTyping_Click(object sender, RoutedEventArgs e)
        {
            spManualInput.Visibility = Visibility.Visible;
            spTypyOfDiagram.Visibility = Visibility.Collapsed;
            spExport.Visibility = Visibility.Collapsed;
            
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnJsonf_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            JsonImport jsonImport = new JsonImport();
            openFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            bool? success = openFileDialog.ShowDialog();
            if (success == true)
            {
                jsonImport.path = openFileDialog.FileName;
                jsonImport.JI(out Graph graphj);
            }
            else { MessageBox.Show("File didnt choose", "MESSAGE", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var stack in spValue.Children)
            {

                StackPanel stackPanel = stack as StackPanel;

                foreach (var tbn in stackPanel.Children)
                {
                    GraphField graphField = new GraphField();
                    if (tbn != null)
                    {
                        TextBox textBox = tbn as TextBox;
                        if (textBox != null && textBox.Name == "tbGraphName")
                        {
                            graphField.graphName = textBox.Text;
                        }


                        if (textBox != null && textBox.Name == "tbGraphValue")
                        {
                            try
                            {
                                graphField.graphValue = Convert.ToInt32(textBox.Text);
                            }
                            catch (Exception)
                            {
                                graphField.graphValue = 0;
                            }

                        }


                    }
                    graphs.Add(graphField);
                }

            }

            //---------МАГИЧЕСКАЯ КНОПКА КРАФТИТ ДИАГРАММУ
            ViewGraph vgraph = new ViewGraph(graphs);
            switch (graph.graphType)
            {
                case "PieChart":
                    spPieChart.Visibility = Visibility.Visible;
                    this.DataContext = vgraph;
                break;

                case "VGraph":
                    spVChart.Visibility = Visibility.Visible;
                    this.DataContext = vgraph;
                break;

                case "HGraph":
                    spHChart.Visibility = Visibility.Visible;
                    this.DataContext = vgraph;
                break;
            }
                

           



        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            spValue.Visibility = Visibility.Visible;
            integ = tbFields.Text;
            Graph graphField = new Graph();
            if (String.IsNullOrEmpty(integ))
            {
                MessageBox.Show("Enter something.", "MESSAGE", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                try
                {

                    graphField.fieldQuantity = int.Parse(integ);

                    for (int i = 0; i < graphField.fieldQuantity; i++)
                    {
                        createField();
                    }

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.ToString(), "MESSAGE", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
            spBtnCreate.Visibility = Visibility.Visible;
        }

        private void createField()
        {
            //это стек нейм
            StackPanel spPanelN = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Name = "spForTwoFields"
            };

            spPanelN.Children.Add(getLabelN());
            spPanelN.Children.Add(getBoxN());
            //это стек нейм


            //это стек вэлью
            StackPanel spPanelV = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Name = "spForTwoFields"
            };

            spPanelV.Children.Add(getLabelV());
            spPanelV.Children.Add(getBoxV());
            //это стек вэлью

            spValue.Children.Add(spPanelN);
            spValue.Children.Add(spPanelV);
        }
        

        private Label getLabelN()
        {
            return new Label() { Content = "Enter name of graph:" };
        }
        private TextBox getBoxN()
        {
            return new TextBox() { Name = "tbGraphName" };
        
        }
        private Label getLabelV()
        {
            return new Label() { Content = "Enter value of graph:" };
        }
        private TextBox getBoxV()
        {
            return new TextBox() { Name = "tbGraphValue" };

        }
    }
}