using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaire
{
    public class Paire<T>
    {

        private T x;
        public T X { get => x; private set => value = x; }
        //public T X {get; private set;} //Também funciona método auto implementavel (O atributo é criado naturalmente)
        private T y;
        public T Y { get => y; private set => value = y; }
        //public T Y {get; private set;}//Também funciona método auto implementavel
        public Paire(T x, T y)
        {
            this.X = x;
            this.Y = y;

        }
        public Paire<T> Transpose1()
        {
            return new Paire<T>(this.Y,this.X);
           
        }

        public void Transpose2()
        {
            T aux = this.Y;
            this.Y = this.X;
            this.X = aux;

        }

        

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        }


    }
}
