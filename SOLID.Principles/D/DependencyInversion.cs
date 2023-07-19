using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Principles.D
{
    class DependencyInversion
    {
        class BrokenPrinciple
        {
            class SqlDatabase
            {
                public void SaveData()
                {

                }
            }

            class SqlLiteDatabase
            {
                public void SaveData()
                {

                }
            }

            public BrokenPrinciple()
            {
                SaveInformation();                
            }

            private void SaveInformation()
            {
                // old implementation
                var database = new SqlDatabase();
                database.SaveData();

                // new implementation (modifying code)
                var sqlLite = new SqlLiteDatabase();
                sqlLite.SaveData();
            }
        }

        class PrincipleOk
        {
            interface IDatabase
            {
                public void SaveData();
            }

            class SqlDatabase : IDatabase
            {
                public void SaveData()
                {

                }
            }

            class SqlLiteDatabase : IDatabase
            {
                public void SaveData()
                {

                }
            }

            public PrincipleOk()
            {
                IDatabase database = new SqlDatabase();
                SaveInformation(database);

                database = new SqlLiteDatabase();
                SaveInformation(database);
            }

            void SaveInformation(IDatabase database)
            {
                // works with abstraction instead of concret implementation
                database.SaveData();
            }
        }
    }
}
