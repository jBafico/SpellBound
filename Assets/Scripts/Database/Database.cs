using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class Database
{
    private string _connectionPath;
    private IDbConnection _dbConnection;

    public Database()
    {
        _connectionPath = $"URI=file.{Application.dataPath}/GameDatabase.s3db";
        _dbConnection = new SqliteConnection(_connectionPath);
        
        /* Drop tables */
        
        /* Create tables */
    }

    private void ExecuteWriteQueries(string query)
    {
        try
        {
            _dbConnection.Open();
            IDbCommand cmd = _dbConnection.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            
            cmd.Dispose();
            cmd = null;
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            _dbConnection.Close();
        }
    }
}
