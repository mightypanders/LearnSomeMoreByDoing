using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<int> a = new MyClass<int>();
            a.MyProperty = 4;
            Console.WriteLine(a.MyProperty);
            Console.ReadLine();
        }
    }

    public class MyClass<T> where T : struct
    {
        public MyClass()
        {
            MyProperty = new T();
        }

        public T MyProperty { get; set; }
    }

    struct Nullable<T> where T : struct
    {
        private bool _hasValue;
        private T _val;
        public Nullable(T pVal)
        {

            this._hasValue = true;
            this._val = pVal;
        }
        public bool HasVal { get => this._hasValue; }
        public T Value
        {
            get
            {
                if (!this.HasVal) throw new ArgumentException();
                return this._val;
            }
        }
        public T GetValueOrDefault()
        {
            return this._val;
        }
    }
}
