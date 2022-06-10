using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArrayList arrayList1 = new CustomArrayList();
            CustomArrayList arrayList2 = new CustomArrayList();
            object[] arr = new object[10];
            arrayList1.Add(2);
            arrayList1.Add("mmmmm");
            arrayList1.Add(10);
            arrayList1.Add(false);    
            arrayList1.Insert(2, 44);
            arrayList2.Add(2);
            arrayList2.Add("mmmmm");
            arrayList2.Add(10);
            arrayList2.Add(true);
            arrayList1.Insert(2, 30);           
            arrayList1.Remove(2);           
            arrayList1.Add(arrayList2);
            arrayList1.Contains(2);
            arrayList1.CopyTo(arr);          
            Console.WriteLine(arrayList1.IndexOf(10));
            Console.WriteLine(arrayList1.LastIndexOf("kkk"));
            arrayList1.Reverse();                  

        }
    }
}
