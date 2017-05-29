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
using System.Net;
using System.IO;
using Microsoft.CSharp;
using Newtonsoft.Json;

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
            //SQLiteConnection oSQLiteConnection =
            //    new SQLiteConnection("Data Source=ProjektZPO.s3db");
            //SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            //oCommand.CommandText = "SELECT * FROM Teams";
            //m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
            //    oSQLiteConnection);
            //SQLiteCommandBuilder oCommandBuilder =
            //    new SQLiteCommandBuilder(m_oDataAdapter);
            //m_oDataSet = new DataSet();
            //m_oDataAdapter.Fill(m_oDataSet);
            //m_oDataTable = m_oDataSet.Tables[0];
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

        //utworzenie okna z informacjami o druzynie
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //pobranie tokena
            string token = getToken();
            //wyslanie zapytanie do api fb o posty na danej stronie
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/BVB/feed?access_token=" + token);
            //odebranie wyniku
            var response = (HttpWebResponse)request.GetResponse();
            //przetworzenie odpowiedzi serwera fb na obiekt klasy FacebookPost
            FacebookPost fbPost = getFacebookPost(response);

            TeamInfo ti = new TeamInfo(2, fbPost);
            ti.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string token = getToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/fcbayern.en/feed?access_token="+token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = getFacebookPost(response);

            TeamInfo ti = new TeamInfo(1, fbPost);
            ti.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string token = getToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/FCKoeln/feed?access_token=" + token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = getFacebookPost(response);

            TeamInfo ti = new TeamInfo(3, fbPost);
            ti.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string token = getToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/herthabsc/feed?access_token=" + token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = getFacebookPost(response);

            TeamInfo ti = new TeamInfo(4, fbPost);
            ti.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string token = getToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/werderbremenEN/feed?access_token=" + token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = getFacebookPost(response);

            TeamInfo ti = new TeamInfo(5, fbPost);
            ti.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string token = getToken();
            var request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/vflwolfsburg.int/feed?access_token=" + token);
            var response = (HttpWebResponse)request.GetResponse();
            FacebookPost fbPost = getFacebookPost(response);

            TeamInfo ti = new TeamInfo(6, fbPost);
            ti.Show();
        }
        // //////////////////////////////////////////////////////
        
        //pobieranie tokena do API
        private string getToken()
        {
            //zapytanie o token
            var tokenRequest = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/oauth/access_token?client_id=1066391300160675&client_secret=529c6b46acc37b676b6bc438c7691291&grant_type=client_credentials");
            //odpowiedz serwera
            var tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
            //przetowrzenie odpowiedzi na string
            var responseTokenString = new StreamReader(tokenResponse.GetResponseStream()).ReadToEnd();
            //parsowanie jsona
            dynamic y = JsonConvert.DeserializeObject(responseTokenString);

            return y.access_token;
        }

        //przetworzenie odpowiedzi serwera fb na obiekt FacebookPost  
        private FacebookPost getFacebookPost(HttpWebResponse response)
        {
            //przetworzenie odpowiedzi na string
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //parsowanie jsona
            dynamic x = JsonConvert.DeserializeObject(responseString);
            var data = x.data;
            //przypisanie atrybutow najnowszego postu do poszczegolnych atrybutow
            string message = data[0].message;
            string created_time = data[0].created_time;
            string id = data[0].id;
            //utworzenie obiektu FacebookPost z pobranym postem
            FacebookPost fbPost = new FacebookPost(created_time, message, id);
            return fbPost;
        }
    }
}
