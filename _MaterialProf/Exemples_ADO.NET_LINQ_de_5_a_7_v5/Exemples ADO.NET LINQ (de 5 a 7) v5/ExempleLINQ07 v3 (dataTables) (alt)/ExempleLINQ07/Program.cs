using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExempleLINQ07
{
    class Program
    {
        private static DataSet dataSet;

        private static void MakeDataTables()
        {
            // Run all of the functions. 
            MakeParentTable();
            MakeChildTable();
            //MakeDataRelation();
            MakeForeignKeyConstraint();           
        }

        private static void MakeParentTable()
        {
            // Create a new DataTable.
            DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            column.AutoIncrement = true;
            //column.Caption = "ID";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ParentItem";
            column.AutoIncrement = false;
            //column.Caption = "ParentItem";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //PrimaryKeyColumns[0] = table.Columns["ID"];
            //table.PrimaryKey = PrimaryKeyColumns;
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

            // Instantiate the DataSet variable.
            dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i <= 2; i++)
            {
                row = table.NewRow();
                row["ID"] = i;
                row["ParentItem"] = "ParentItem " + i;
                table.Rows.Add(row);
            }
        }

        private static void MakeChildTable()
        {
            // Create a new DataTable.
            DataTable table = new DataTable("childTable");
            DataColumn column;
            DataRow row;

            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ChildID";
            column.AutoIncrement = true;
            //column.Caption = "ID";
            column.ReadOnly = true;
            column.Unique = true;

            // Add the column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ChildItem";
            column.AutoIncrement = false;
            column.Caption = "ChildItem";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ParentID";
            column.AutoIncrement = false;
            column.Caption = "ParentID";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            dataSet.Tables.Add(table);

            // Create three sets of DataRow objects, 
            // five rows each, and add to DataTable.
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["childID"] = i;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 0;
                table.Rows.Add(row);
            }
            for (int i = 5; i <= 9; i++)
            {
                row = table.NewRow();
                row["childID"] = i;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 1;
                table.Rows.Add(row);
            }
            for (int i = 10; i <= 14; i++)
            {
                row = table.NewRow();
                row["childID"] = i ;
                row["ChildItem"] = "Item " + i;
                row["ParentID"] = 2;
                table.Rows.Add(row);
            }
        }

        private static void MakeDataRelation()
        {
            // DataRelation requires two DataColumn 
            // (parent and child) and a name.
            DataColumn parentColumn =
                dataSet.Tables["ParentTable"].Columns["ID"];
            DataColumn childColumn =
                dataSet.Tables["ChildTable"].Columns["ParentID"];
            DataRelation relation = new
                DataRelation("parent2Child", parentColumn, childColumn);
            dataSet.Tables["ChildTable"].ParentRelations.Add(relation);
            // Attention: DataRelation will cascade on deletion and on updates.
            // To do differently use Foreign Key.
        }

        private static void MakeForeignKeyConstraint()
        {
            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
                dataSet.Tables["ParentTable"].Columns["ID"],
                dataSet.Tables["ChildTable"].Columns["ParentID"]);
            // Attention: the default for DeleteRule and UpdateRule is Rule.Cascade.
            myFK.DeleteRule = Rule.None;
            // Cannot delete a parent value that has associated existing child.  
            dataSet.Tables["ChildTable"].Constraints.Add(myFK);
        }

        static void Main(string[] args)
        {
            MakeDataTables();
            // LINQ inner join - first form - Query syntax
            var resultQ1 = from c in dataSet.Tables["ChildTable"].AsEnumerable()
                           join p in dataSet.Tables["ParentTable"].AsEnumerable()
                           on c["ParentID"] equals p["ID"]    // == is not valid here et "equals" n'est pas symmetrique
                           select new { ID=c["ChildID"],
                                        Name = c["ChildItem"],
                                        Parent= p["ParentItem"]
                                      };

            foreach (var item in resultQ1)
            {
                Console.WriteLine(item.ID + "\t | " + item.Name + "\t | " + item.Parent);
            }
            Console.WriteLine();

            // LINQ inner join - first form -  Method syntax 
            var resultM1 = dataSet.Tables["ChildTable"].AsEnumerable()
                                       .Join(dataSet.Tables["ParentTable"].AsEnumerable(), 
                                       c => c["ParentID"], p => p["ID"],
                                       (c, p) => new { ID = c["ChildID"],
                                                       Name = c["ChildItem"],
                                                       Parent = p["ParentItem"]
                                                     });

            foreach (var item in resultM1)
            {
                Console.WriteLine(item.ID + "\t | " + item.Name + "\t | " + item.Parent);
            }
            Console.WriteLine();

            // LINQ inner join - second form - Query syntax 
            var resultQ2 = from c in dataSet.Tables["ChildTable"].AsEnumerable()
                           from p in dataSet.Tables["ParentTable"].AsEnumerable()
                           where c["ParentID"] == p["ID"]
                           select new
                           {
                               ID = c["ChildID"],
                               Name = c["ChildItem"],
                               Parent = p["ParentItem"]
                           };

            foreach (var item in resultQ2)
            {
                Console.WriteLine(item.ID + "\t | " + item.Name + "\t | " + item.Parent);
            }
            Console.WriteLine();

            // LINQ inner join - second form - Method syntax 
            var resultM2 = dataSet.Tables["ChildTable"].AsEnumerable()
                          .SelectMany(_ => dataSet.Tables["ParentTable"].AsEnumerable(), (x, y) => new { x, y })    // _ c'est un paramètre anonym
                          .Where(z => z.x["ParentID"] == z.y["ID"])
                          .Select(z => new
                          {
                              ID = z.x["ChildID"],
                              Name = z.x["ChildItem"],
                              Parent = z.y["ParentItem"]
                          });

            foreach (var item in resultM2)
            {
                Console.WriteLine(item.ID + "\t | " + item.Name + "\t | " + item.Parent);
            }
            Console.WriteLine();

            Console.WriteLine("===================");
            Console.WriteLine();

            // LINQ - Method syntax 
            var resultM3 = dataSet.Tables["ChildTable"].AsEnumerable()
                                  .Select(c => new {
                                      ID = c["ChildID"],
                                      Name = c["ChildItem"]
                                  });

            foreach (var item in resultM3)
            {
                Console.WriteLine(item.ID + "\t | " + item.Name);
            }
            Console.WriteLine();

            try
            {
                DataRow row = dataSet.Tables["ParentTable"].AsEnumerable()
                                     .Where(s => (int)s["ID"] == 2).First();
                dataSet.Tables["ParentTable"].Rows.Remove(row);
            }
            catch (Exception)
            {
                Console.WriteLine("ParentTable row with ID=2 can not be deleted");
                Console.WriteLine();
            }

            // LINQ - Method syntax 
            resultM3 = dataSet.Tables["ChildTable"].AsEnumerable()
                              .Select(c => new {
                                  ID = c["ChildID"],
                                  Name = c["ChildItem"]
                              });

            foreach (var item in resultM3)
            {
                Console.WriteLine(item.ID + "\t | " + item.Name);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
