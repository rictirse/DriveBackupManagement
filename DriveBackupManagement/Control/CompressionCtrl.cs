using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriveBackupManagement
{

    public class CompressionCtrl
    {
        const int TASKLIMIT = 8; //最多開幾個執行緒

        public CompressionCtrl(DataTable aDt)
        {
            Schedule(aDt);
        }

        private void Schedule(DataTable aDt)
        {
            var ls_taskPool = new List<Task>();

            foreach (DataRow _dr in aDt.Rows)
            {
                ls_taskPool.Add(new Task(() => Compression(_dr)));
            }

            foreach (var t in ls_taskPool)
            {
                while (true)
                {
                    int _IsRunning = 1;
                    for (int i = 0; i < ls_taskPool.Count; i++)
                    {
                        if (ls_taskPool[i].Status == TaskStatus.Running)
                        {
                            _IsRunning++;
                        }
                    }
                    Thread.Sleep(50);
                    if (TASKLIMIT > _IsRunning) break;
                }
                t.Start();
            }
        }

        private void Compression(DataRow _dr)
        {
            RarCtrl.Compression((string)_dr["DirPath"], (string)_dr["DirName"]);

            _dr["Completed"] = true;
        }
    }
}
