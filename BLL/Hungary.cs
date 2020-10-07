using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Hungary
    {
        /****************************************************
        二分图匹配（匈牙利算法的DFS实现）,
        优点：适于稠密图，DFS找增广路快，实现简洁易于理解
        时间复杂度:O(VE);
        ****************************************************/
        private static int uN,vN;   //u,v数目;
        private static int[][] g;   //编号是0~n-1的 
        public static int[] linker; //匹配集,索引代表v点
        public static int[] restU;  //没匹配到的u点集
        public static int[] restV;  //没匹配到的v点集
        private static bool[] used;

        //深度搜索
        private static bool dfs(int u)
        {
            int v;
            for (v = 0; v < vN; v++)
                //如果u到v有一条连接，且v在“这一次匹配”中没有被决定使用的话
                if (g[u][v]==1 && !used[v])
                {
                    used[v] = true;
                    //判定vN点集的v1是否被其它点连接
                    //如果没有，就把v1送给u1；
                    //如果有，还是把v1送给u1，而本来连接了v1的点u2，对其进行DFS遍历，找到另一个点v2送给u2好了
                    if (linker[v] == -1 || dfs(linker[v]))
                    {
                        linker[v] = u;
                        return true;
                    }
                }
            return false;
        }

        //返回匹配数
        public static void hungary(int[][] graph)
        {
            uN = graph.Length;
            vN = graph[0].Length;//索引直接用0，因为graph的每个子数组长度一样
            g = graph;
            used = new bool[vN];
            linker = Enumerable.Repeat(-1, vN).ToArray();
            int res = 0;
            //循环u次匹配
            for (int u = 0; u < uN; u++)
            {
                Array.Clear(used, 0, used.Length);
                if (dfs(u)) res++;
            }
            //没有匹配的u点集
            restU = new int[uN];
            for (int i = 0; i < uN; i++)
                restU[i] = i;
            restU = restU.Except(linker).ToArray();
            //没有匹配的v点集
            restV = new int[vN-res];
            int n = 0;
            for (int v = 0; v < vN; v++)
            {
                if (linker[v] == -1)
                {
                    restV[n] = v;
                    n++;
                }
            }
        }
    }
}
