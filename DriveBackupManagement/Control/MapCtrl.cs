using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveBackupManagement
{
    public class MapCtrl
    {
        public DataTable Table { get; private set; }
        public Task task_search;

        public MapCtrl(string aPath)
        {
            Table = new DataTable();
            Table.Columns.Add(new DataColumn("Selected", typeof(bool)));
            Table.Columns.Add(new DataColumn("Index", typeof(int)));
            Table.Columns.Add(new DataColumn("Info", typeof(DirectoryInfo)));
            Table.Columns.Add(new DataColumn("DirName", typeof(string)));
            Table.Columns.Add(new DataColumn("DirPath", typeof(string)));
            Table.Columns.Add(new DataColumn("Completed", typeof(bool)));

            task_search = Task.Run(() => ScanFolder(aPath));
        }

        public bool IsSearchComplete { get { return task_search.IsCompleted; } }

        public bool ScanFolder(string aPath)
        {
            try
            {
                int Count = 0;
                foreach (var dir in Directory.GetDirectories(aPath))
                {
                    var _dr = Table.NewRow();
                    var _di = new DirectoryInfo(dir);

                    _dr["Selected"]  = true;
                    _dr["Index"]     = Count;
                    _dr["Info"]      = _di;
                    _dr["DirName"]   = _di.Name;
                    _dr["DirPath"]   = _di.FullName;
                    _dr["Completed"] = false;

                    Table.Rows.Add(_dr);

                    Count++;
                }
            }
            catch { return false; }

            return true;
        }
    }
}
