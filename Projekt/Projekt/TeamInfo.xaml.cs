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
    /// Interaction logic for TeamInfo.xaml
    /// </summary>
    public partial class TeamInfo : Window
    {
        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;
        public TeamInfo(int id)
        {
            
            InitializeComponent();
            InitBinding(id);
        }
        private void InitBinding(int id)
        {
            SQLiteConnection oSQLiteConnection =
                new SQLiteConnection("Data Source=ProjektZPO.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Teams WHERE ID = " + id;
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            maingrid.DataContext = m_oDataTable.DefaultView;
        }
    }
}
