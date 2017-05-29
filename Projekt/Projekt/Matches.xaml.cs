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
    /// Interaction logic for Matches.xaml
    /// </summary>
    public partial class Matches : Window
    {
        //listy dla drużyn i meczy
        public List<Team> teams = new List<Team>();
        public List<Match> matchesList = fillMatches();

        //połączenie z bazą ; pobranie meczy z tabeli Matches
        private static List<Match> fillMatches()
        {
            //polaczenie z baza i pobranie meczy
            SQLiteDataAdapter m_oDataAdapter = null;
            DataSet m_oDataSet = null;
            DataTable m_oDataTable = null;
            SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=ProjektZPO.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Matches";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];

           //Utworzenie listy meczy i dodanie ich z bazy do listy (do uzycia w widoku)
            List<Match> tmp = new List<Match>();
            foreach (DataRow row in m_oDataTable.Rows)
            {
                Match tmpMatch = new Match(row[1].ToString(), row[3].ToString(), Int32.Parse(row[2].ToString()), Int32.Parse(row[4].ToString()));
                tmp.Add(tmpMatch);
            }

            return tmp;
        }

        public Matches()
        {
            InitializeComponent();

            MatchesList.ItemsSource = matchesList;

            //połączenie z bazą ; pobranie drużyn z tabeli Teams
            SQLiteDataAdapter m_oDataAdapter = null;
            DataSet m_oDataSet = null;
            DataTable m_oDataTable = null;
            SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=ProjektZPO.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Teams";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            homeTeamDropdown.ItemsSource = m_oDataTable.DefaultView;
            awayTeamDropdown.ItemsSource = m_oDataTable.DefaultView;
        }

        //dodawanie meczu do listy meczy
        public bool addMatch(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            if (homeTeam == null || awayTeam == null)
                return false;

            Match match = new Match(homeTeam, awayTeam, homeTeamScore, awayTeamScore);

            matchesList.Insert(0, match);

            return true;
        }

        public List<Team> fillTeams()
        {
            List<Team> teams = new List<Team>();
            return teams;
        }

        //dodawanie meczy do bazy danych
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string homeTeam = "";
            string awayTeam = "";
            DataRowView oDataRowView = homeTeamDropdown.SelectedItem as DataRowView;
            //pobranie wartosci z widoku
            if (oDataRowView != null)
            {
                homeTeam = oDataRowView.Row["Name"] as string;
            }

            oDataRowView = awayTeamDropdown.SelectedItem as DataRowView;

            if (oDataRowView != null)
            {
                awayTeam = oDataRowView.Row["Name"] as string;
            }

            int homeTeamScore = Int32.Parse(homeTeamScoreBox.Text);
            int awayTeamScore = Int32.Parse(awayTeamScoreBox.Text);

            //jezeli mecz zostal poprawnie dodany do listy
            if (addMatch(homeTeam, awayTeam, homeTeamScore, awayTeamScore))
            {
                //czyszczenie okienek widoku
                MatchesList.Items.Refresh();
                homeTeamDropdown.SelectedIndex = -1;
                awayTeamDropdown.SelectedIndex = -1;
                homeTeamScoreBox.Text = "";
                awayTeamScoreBox.Text = "";

                //pobranie meczy z bazy
                SQLiteDataAdapter m_oDataAdapter = null;
                DataSet m_oDataSet = null;
                DataTable m_oDataTable = null;
                SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=ProjektZPO.s3db");
                SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
                oCommand.CommandText = "SELECT * FROM Matches";
                m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                    oSQLiteConnection);
                SQLiteCommandBuilder oCommandBuilder =
                    new SQLiteCommandBuilder(m_oDataAdapter);
                m_oDataSet = new DataSet();
                m_oDataAdapter.Fill(m_oDataSet);
                m_oDataTable = m_oDataSet.Tables[0];

                //dodanie nowego rekordu z nowym meczem
                DataRow oDataRow = m_oDataTable.NewRow();
                oDataRow[0] = m_oDataTable.Rows.Count+1;
                oDataRow[1] = homeTeam;
                oDataRow[2] = homeTeamScore;
                oDataRow[3] = awayTeam;
                oDataRow[4] = awayTeamScore;
                oDataRow[5] = DateTime.Now;
                m_oDataTable.Rows.Add(oDataRow);
                m_oDataAdapter.Update(m_oDataSet);


            }


        }

        private void MatchesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
