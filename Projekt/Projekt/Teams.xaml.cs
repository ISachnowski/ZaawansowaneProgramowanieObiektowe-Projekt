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
using System.Data.SQLite;
using System.Data;

namespace Projekt
{
    


    /// <summary>
    /// Interaction logic for Teams.xaml
    /// </summary>
    public partial class Teams : Window
    {
        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;

        private void InitBinding()
        {
            SQLiteConnection oSQLiteConnection =
                new SQLiteConnection("Data Source=ProjektZPO.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Teams";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            //lstItems.DataContext = m_oDataTable.DefaultView;
        }

        public Teams()
        {
            InitializeComponent();
            InitBinding();
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TeamInfo ti = new TeamInfo(2);
            ti.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TeamInfo ti = new TeamInfo(1);
            ti.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TeamInfo ti = new TeamInfo(3);
            ti.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TeamInfo ti = new TeamInfo(4);
            ti.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TeamInfo ti = new TeamInfo(5);
            ti.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TeamInfo ti = new TeamInfo(6);
            ti.Show();
        }
    }
}
