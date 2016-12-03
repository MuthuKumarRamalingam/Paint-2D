using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Windows.Forms;

namespace CommonTools
{
    public class UnderDevelopment
    {
        public static void CheckLoops()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < 1000; i++)
            {
                dic.Add(i, i);
            }
            int core = Environment.ProcessorCount;
            Dictionary<int, int> dic1 = new Dictionary<int, int>();
            Parallel.ForEach(dic, obj =>
            {
                dic1.Add(obj.Key, obj.Value);
            });
            ConcurrentDictionary<int, int> conc = new ConcurrentDictionary<int, int>();
            Parallel.For(1001, 2000, i =>
            {

                dic.Add(i, i);
            });
        }

        public static void CheckTransactionSpeed()
        {
            UnderDevelopment.CheckLoops();

            Stopwatch st = new Stopwatch();
            st.Restart();

            using (SQLiteHelper liteHelper = new SQLiteHelper(SQLiteHelper.ExecutablePathDB))
            {
                liteHelper.BeginTransaction();

                for (int i = 0; i < 50; i++)
                {
                    string qry = "insert into numcheck values(@1)";
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("@1", i);

                    liteHelper.ExecuteNonQuery(qry, SQLiteHelper.GenerateParameter(param), false);
                }

                liteHelper.Commit();
            }
            st.Stop();

            long timespan = st.ElapsedMilliseconds;
            MessageBox.Show("elapsed time " + timespan);
        }
    }

}
