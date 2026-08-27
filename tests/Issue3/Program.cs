using System;
using System.Collections.Generic;
using Equin.ApplicationFramework;

namespace Issue3
{
    public class ZZZ
    {
        public string aaa { get; set; } = "zzz aaa";
        public string bbb { get; set; } = "zzz bbb";
    }

    public class YYY
    {
        public List<ZZZ> zzz;              //   field !!!
        public string aaa { get; set; } = "yyy aaa";
        public string bbb { get; set; } = "yyy bbb";
    }

    public class XXX
    {
        public List<ZZZ> zzz { set; get; }  //  property !!!
        public string aaa { get; set; } = "xxx aaa";
        public string bbb { get; set; } = "xxx bbb";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var zzList = new List<ZZZ>() { new ZZZ(), new ZZZ(), new ZZZ() };           //  some list

            var yy = new List<YYY>() {
                new YYY() { zzz = zzList },
                new YYY() { zzz = zzList }
            };

            var xx = new List<XXX>() {
                new XXX() { zzz = zzList },
                new XXX() { zzz = zzList }
            };

            var lstYY = new BindingListView<YYY>(yy);   //  ok
            Console.WriteLine(lstYY.Count);
            var lstXX = new BindingListView<XXX>(xx);   //  ok
            Console.WriteLine(lstXX.Count);

            // recreate with zzz = null
            yy = new List<YYY>() {
                new YYY(),
                new YYY()
            };

            xx = new List<XXX>() {
                new XXX(),
                new XXX()
            };

            lstYY = new BindingListView<YYY>(yy);       //  ok
            Console.WriteLine(lstYY.Count);
            lstXX = new BindingListView<XXX>(xx);       //  error
            Console.WriteLine(lstXX.Count);
        }
    }
}
