using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.DAL.Model;

namespace ShopManagement.DAL.Repository
{
    interface IBaseSPRepository : IDisposable
    {

        // 1. SqlCommand approach
        int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        //ICollection ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        // 2. SqlQuery approach
        DataTable ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null);

    }


    public class BaseSPRepository : IBaseSPRepository
    {
        public ShopDBEntities db;
        public DbSet dbSet;
        private bool _disposed = false;

        public BaseSPRepository(ShopDBEntities context)
        {

            db = context;
        }

        //public ICollection ExcuteSqlQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters = null)
        //{
        //    if (commandType == CommandType.Text)
        //    {
        //        return SqlQuery(sqlQuery, parameters);
        //    }
        //    else if (commandType == CommandType.StoredProcedure)
        //    {
        //        return StoredProcedure(sqlQuery, parameters);
        //    }

        //    return null;
        //}

        public int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (db.Database.Connection.State == ConnectionState.Closed)
            {
                db.Database.Connection.Open();
            }

            var command = db.Database.Connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            int count = command.ExecuteNonQuery();
            return count;
        }


        public DataTable ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {

            if (db.Database.Connection.State == ConnectionState.Closed)
            {
                db.Database.Connection.Open();
            }

            var command = db.Database.Connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            using (var reader = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                if (db.Database.Connection.State == ConnectionState.Open)
                {
                    db.Database.Connection.Close();
                }
                return dt;
            }

            

        }

        //private ICollection SqlQuery(string sqlQuery, SqlParameter[] parameters = null)
        //{
        //    if (parameters != null && parameters.Any())
        //    {
        //        var parameterNames = new string[parameters.Length];
        //        for (int i = 0; i < parameters.Length; i++)
        //        {
        //            parameterNames[i] = parameters[i].ParameterName;
        //        }

        //        var result = context.Database.SqlQuery(string.Format("{0}", sqlQuery, string.Join(",", parameterNames), parameters));
        //        return result.ToList();
        //    }
        //    else
        //    {
        //        var result = context.Database.SqlQuery(sqlQuery);
        //        return result.ToList();
        //    }
        //}

        //private ICollection StoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        //{
        //    if (parameters != null && parameters.Any())
        //    {
        //        var parameterNames = new string[parameters.Length];
        //        for (int i = 0; i < parameters.Length; i++)
        //        {
        //            parameterNames[i] = parameters[i].ParameterName;
        //        }

        //        var result = context.Database.SqlQuery(string.Format("EXEC {0} {1}", storedProcedureName, string.Join(",", parameterNames), parameters));
        //        return result.ToList();
        //    }
        //    else
        //    {
        //        var result = context.Database.SqlQuery(string.Format("EXEC {0}", storedProcedureName));
        //        return result.ToList();
        //    }
        //}
        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                db.Dispose();
            }

            _disposed = true;
        }




    }
}
