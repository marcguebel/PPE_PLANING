using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DAO
{
    private MySqlConnection connect;
    public DAO()
    {
        string myConnectionString = "server=172.17.0.6;uid=anthony;pwd=btssio;database=ppe3;";
        connect = new MySql.Data.MySqlClient.MySqlConnection();
        connect.ConnectionString = myConnectionString;
        connect.Open();
    }



    public void TesterCreaneau(string Creneaux)
    {
        String myInsertQuery = "SELECT COUNT(Id_Evenement) FROM evenement where "+ Creneaux +" between Heure_Debut AND Heure_Fin";
        MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
        myCommand.Connection = connect;
        myCommand.ExecuteNonQuery();
        if (myInsertQuery = "0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
