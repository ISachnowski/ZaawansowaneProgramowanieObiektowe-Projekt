using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Projekt
{
    public class Team
    {
        private int id;
        private string name;
        private int founded;
        private string stadium;
        private int capacity;
        private string coach;
        private string president;

        

        public void editCoach(string newCoach)
        {
            this.coach = newCoach;
            SQLiteDataAdapter m_oDataAdapter = null;
            DataSet m_oDataSet = null;
            DataTable m_oDataTable = null;
            SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=ProjektZPO.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Teams WHERE ID = "+this.id;
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];

            DataRow oDataRow = m_oDataTable.Rows[0];
            oDataRow.BeginEdit();
            oDataRow[5] = newCoach;
            oDataRow.EndEdit();
            m_oDataAdapter.Update(m_oDataSet);
        }

        public void editPresident (string newPresident)
        {
            this.president = newPresident;

            SQLiteDataAdapter m_oDataAdapter = null;
            DataSet m_oDataSet = null;
            DataTable m_oDataTable = null;
            SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=ProjektZPO.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Teams WHERE ID = " + this.id;
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];

            DataRow oDataRow = m_oDataTable.Rows[0];
            oDataRow.BeginEdit();
            oDataRow[6] = newPresident;
            oDataRow.EndEdit();
            m_oDataAdapter.Update(m_oDataSet);
        }

        public string getName()
        {
            return this.name;
        }

        public int getFounded()
        {
            return this.founded;
        }

        public string getStadium()
        {
            return this.stadium;
        }

        public int getCapacity()
        {
            return this.capacity;
        }

        public string getCoach()
        {
            return this.coach;
        }

        public string getPresident()
        {
            return this.president;
        }

    }
}
