using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace laba2
{
    /*
    *  interface Trigger
       {
            string name;//тип триггера
            int input1;//вход1
            int input2;//вход2
            bool output;//выход
       }
    * 
    * */
    public abstract class Trigger
    {
        protected string name;//тип триггера
        protected int input1;//вход1
        protected int input2;//вход2
        protected bool output;//выход

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public string GetName//возвращает тип триггера1
        {
            get { return name; }
        }
    }
    public class TriggerRS : Trigger
    {
        private bool forbidden;//запрещенное состояние триггера
        public TriggerRS()//конструктор
        {
            name = "RS trigger";
            input1 = 0;
            input2 = 0;
            output = false;
            forbidden = false;
        }
        public void GiveSignaltoSinput()//подать сигнал на S вход
        {
            if (!Convert.ToBoolean(input1))
            {
                if (!Convert.ToBoolean(input2))
                {
                    input1 = 1;
                    output = true;
                }
                else
                {
                    input1 = 1;
                    forbidden = true;
                }
            }

        }
        public void RemoveSignalfromSinput()//прекратить подачу сигнала на S вход
        {
            input1 = 0;
            if (forbidden)
            {
                forbidden = false;
                output = false;
            }
        }
        public void GiveSignaltoRinput()//подать сигнал на R вход
        {
            if (!Convert.ToBoolean(input2))
            {
                if (!Convert.ToBoolean(input1))
                {
                    input2 = 1;
                    output = false;
                }
                else
                {
                    input2 = 1;
                    forbidden = true;
                }
            }
        }
        public void RemoveSignalfromRinput()//прекратить подачу сигнала на R вход
        {
            input2 = 0;
            if (forbidden)
            {
                forbidden = false;
                output = true;
            }
        }
        public void GetTriggerState()//вывести на экран состояние триггера
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()//переопределение
        {
            string result = null;
            result += string.Format("Trigger type: {0}\n", this.GetName);
            if (forbidden)
                result += string.Format("Trigger state:\nR input:{0}\nS input:{1}\n Output:this is forbidden trigger state . .",
                    Convert.ToByte(input2), Convert.ToByte(input1));
            else
                result += string.Format("Trigger state:\nR input:{0}\nS input:{1}\n Output:{2}",
                    Convert.ToByte(input2), Convert.ToByte(input1), Convert.ToByte(output));
            return result;
        }

        public TriggerRS(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        private double a
        {
            get;
            set;
        }

        private double b
        {
            get;
            set;
        }

        private double c
        {
            get;
            set;
        }

        public static TriggerRS operator +(TriggerRS x, TriggerRS y)
        {
            TriggerRS ans = new TriggerRS();
            ans.a = x.a + y.a;
            ans.b = x.b + y.b;
            ans.c = x.c + y.c;
            return ans;
        }

        public static TriggerRS operator -(TriggerRS x, TriggerRS y)
        {
            TriggerRS ans = new TriggerRS();
            ans.a = x.a - y.a;
            ans.b = x.b - y.b;
            ans.c = x.c - y.c;
            return ans;
        }

        public static TriggerRS operator *(TriggerRS x, double y)
        {
            TriggerRS ans = new TriggerRS();
            ans.a = x.a * y;
            ans.b = x.b * y;
            ans.c = x.c * y;
            return ans;
        }

        public static TriggerRS operator /(TriggerRS x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();
            TriggerRS ans = new TriggerRS();
            ans.a = x.a / y;
            ans.b = x.b / y;
            ans.c = x.c / y;
            return ans;
        }
        public static bool operator ==(TriggerRS x, TriggerRS y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(TriggerRS x, TriggerRS y)
        {
            return !Equals(x, y);
        }
        public override bool Equals(object x)
        {
            TriggerRS obj = (TriggerRS)x;
            if (a == obj.a && b == obj.b && c == obj.c) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return a.GetHashCode() + 17 * b.GetHashCode() + 289 * c.GetHashCode();
        }

    }
    public class TriggerJK : Trigger
    {
        public TriggerJK(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
        }
        private double a
        {
            get;
            set;
        }

        private double b
        {
            get;
            set;
        }
        public static TriggerJK operator +(TriggerJK x, TriggerJK y)
        {
            TriggerJK ans = new TriggerJK();
            ans.a = x.a + y.a;
            ans.b = x.b + y.b;
            return ans;
        }

        public static TriggerJK operator -(TriggerJK x, TriggerJK y)
        {
            TriggerJK ans = new TriggerJK();
            ans.a = x.a - y.a;
            ans.b = x.b - y.b;
            return ans;
        }

        public static TriggerJK operator *(TriggerJK x, double y)
        {
            TriggerJK ans = new TriggerJK();
            ans.a = x.a * y;
            ans.b = x.b * y;
            return ans;
        }

        public static TriggerJK operator /(TriggerJK x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();
            TriggerJK ans = new TriggerJK();
            ans.a = x.a / y;
            ans.b = x.b / y;
            return ans;
        }

        public override bool Equals(object x)
        {
            TriggerJK obj = (TriggerJK)x;
            if (a == obj.a && b == obj.b) return true;
            else return false;
        }

        public static bool operator ==(TriggerJK x, TriggerJK y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(TriggerJK x, TriggerJK y)
        {
            return !Equals(x, y);
        }
        public override int GetHashCode()
        {
            return b.GetHashCode() + 17 * a.GetHashCode();
        }

        public TriggerJK()//конструктор
        {
            name = "JK trigger";
            input1 = 0;
            input2 = 0;
            output = false;
        }
        public void GiveSignaltoJinput()//подать сигнал на J вход
        {
            if (!Convert.ToBoolean(input1))
            {
                if (!Convert.ToBoolean(input2))
                {
                    input1 = 1;
                    output = true;
                }
                else
                {
                    input1 = 1;
                    output = !output;
                }
            }
        }
        public void RemoveSignalfromJinput()//прекратить подачу сигнала на J вход
        {
            if (Convert.ToBoolean(input1))
            {
                input1 = 0;
                if (Convert.ToBoolean(input2))
                    output = false;
            }
        }
        public void GiveSignaltoKinput()//подать сигнал на K вход
        {
            if (!Convert.ToBoolean(input2))
            {
                if (!Convert.ToBoolean(input1))
                {
                    input2 = 1;
                    output = false;
                }
                else
                {
                    input2 = 1;
                    output = !output;
                }
            }
        }
        public void RemoveSignalfromKinput()//прекратить подачу сигнала на K вход
        {
            if (Convert.ToBoolean(input2))
            {
                input2 = 0;
                if (Convert.ToBoolean(input1))
                    output = true;
            }
        }
        public void GetTriggerState()//вывести на экран состояние триггера
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()//переопределение
        {
            string result = null;
            result += string.Format("Trigger type: {0}\n", this.GetName);
            result += string.Format("Trigger state:\nJ input:{0}\nK input:{1}\n Output:{2}",
                    Convert.ToByte(input1), Convert.ToByte(input2), Convert.ToByte(output));
            return result;
        }
    }

    public enum ChangeType { AddTrigger, GetTriggersState, DeleteTrigger, GetTrigger }
    public delegate void ChangeHandler(ChangeType change);
    class Register
    {
        public event ChangeHandler Changed;
        private string name;//назва регістра
        private List<Trigger> reg;//колекція тригерів
        public Register(string n)//конструктор
        {
            name = n;
            reg = new List<Trigger>();
        }
        public void AddTrigger(Trigger t)//добавити тригер в регістр
        {
            reg.Add(t);
            if (Changed != null) Changed(ChangeType.AddTrigger);
        }
        public Trigger GetTrigger(int index)//отримати конкретний тригер з регістру
        {
            if (index < reg.Count && index >= 0)
                return reg[index];
            else
                throw new IndexOutOfRangeException();
            if (Changed != null) Changed(ChangeType.GetTrigger);
        }
        public void DeleteTrigger(int index)//видалити тригер з регістру
        {
            if (index < reg.Count && index >= 0)
                reg.Remove(reg[index]);
            else
                throw new IndexOutOfRangeException();
            if (Changed != null) Changed(ChangeType.DeleteTrigger);
        }
        public void GetTriggersState()//вивести на екран стан всіх тригерів регістру
        {
            Console.WriteLine("Register {0}:", name);
            foreach (Trigger t in reg)
                Console.WriteLine(t.ToString());
            if (Changed != null) Changed(ChangeType.GetTriggersState);
        }
        public IEnumerator GetEnumerator()//реализуємо для можливості використання foreach з класом
        {
            foreach (Trigger t in reg)
            {
                yield return t;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Starting test . .\n");//тестуєм . .
                Register register = new Register("Test register");
                register.AddTrigger(new TriggerRS());
                register.AddTrigger(new TriggerJK());
                register.AddTrigger(new TriggerRS());
                register.GetTriggersState();
                
                foreach (Trigger t in register)
                {
                    if (t is TriggerRS)
                    {
                        TriggerRS temp = (TriggerRS)t;
                        temp.GiveSignaltoSinput();
                    }
                    if (t is TriggerJK)
                    {
                        TriggerJK temp = (TriggerJK)t;
                        temp.GiveSignaltoJinput();
                    }
                }
                register.GetTriggersState();
                register.DeleteTrigger(2);//витерли останній тригер
                try
                {
                    register.DeleteTrigger(10);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("IndexOutOfRangeException");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Test has been succesfully finished . .");
            Console.ReadLine();
        }
    }

    public class MyExeption : Exception
    {
        MyExeption(String str) : base("It's MyExeption: " + str) { }
    }
}