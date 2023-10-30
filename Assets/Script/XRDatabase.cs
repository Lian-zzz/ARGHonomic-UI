using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine;

public class XRDatabase : MonoBehaviour
{

    public int playerID; 

    // Start is called before the first frame update
    void Start()
    {
        // Read values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase(); // 14

        IDbCommand dbCommandCount = dbConnection.CreateCommand(); // 15
        dbCommandCount.CommandText = "SELECT COUNT(*) FROM PlayerTable"; // 16
 
        int count = Convert.ToInt32(dbCommandCount.ExecuteScalar()); 

        playerID = count + 1; 
        
        string playerName = "Player" + playerID.ToString(); 

        IDbCommand dbCommandAdd = dbConnection.CreateCommand(); // 15
        dbCommandAdd.CommandText = "INSERT INTO PlayerTable (id, name) VALUES ('"+playerID+"', '"+playerName+"')"; // 16
        dbCommandAdd.ExecuteReader(); 
    }




    private IDbConnection CreateAndOpenDatabase() 
    {
        // Open a connection to the database.
        string dbUri = "URI=file:MyDatabase.sqlite"; // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open(); // 6

        // Create a table in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS PlayerTable (id INTEGER PRIMARY KEY, name TEXT )"; // 7
        dbCommandCreateTable.ExecuteReader(); // 8

        return dbConnection;
    }
}
