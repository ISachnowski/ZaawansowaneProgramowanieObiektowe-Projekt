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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Diagnostics;

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
        public TeamInfo(int id, FacebookPost fb)
        {
            
            InitializeComponent();
            InitBinding(id);
            //przekazanie tresci postu z fb do grida
            FacebookPostGrid.DataContext = fb;
        }
        //funkcja inicjalizujaca bindingi dla druzyny pobierajaca je z bazy danych
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 14, XFontStyle.Regular);
            XFont headerFont = new XFont("Oblique", 25, XFontStyle.Italic);

            // Draw the text
            gfx.DrawString(TeamNameTextblock.Text, headerFont, XBrushes.Black,
             new XRect(0, 0, page.Width, 100),
             XStringFormats.Center);

            gfx.DrawString("Rok założenia: "+TeamFoundedTextblock.Text, font, XBrushes.Black,
              new XRect(0, 0, page.Width, 520),
              XStringFormats.Center);

            gfx.DrawString("Prezes: " + TeamPresidentTextblock.Text, font, XBrushes.Black,
              new XRect(0, 0, page.Width, 565),
              XStringFormats.Center);

            gfx.DrawString("Stadion: " + TeamStadiumTextblock.Text, font, XBrushes.Black,
              new XRect(0, 0, page.Width, 610),
              XStringFormats.Center);

            gfx.DrawString("Pojemność stadionu: " + TeamCapacityTextblock.Text, font, XBrushes.Black,
              new XRect(0, 0, page.Width, 655),
              XStringFormats.Center);

            gfx.DrawString("Trener: " + TeamCoachTextblock.Text, font, XBrushes.Black,
              new XRect(0, 0, page.Width, 700),
              XStringFormats.Center);

            XImage image = XImage.FromFile(TeamLogoSource.Text);

         
            gfx.DrawImage(image, 230, 80);



            // Save the document...
            const string filename = "TeamInfo.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}
