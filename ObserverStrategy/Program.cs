using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverState
{

    //-----------------------------------------------Observer--------------------------------------------------


    //public interface IObserver
    //{
    //    void Update(ISubject subject);
    //}

    //public interface ISubject
    //{
    //    void Attach(IObserver observer);

    //    void Detach(IObserver observer);

    //    void Notify();
    //}

    //// Сайт со скидками, который отправляет уведомление подписчикам
    //public class SalesWebsite : ISubject
    //{
    //    // Лист подписчиков
    //    private List<IObserver> _subscribers = new List<IObserver>();

    //    // Добавить подписчика
    //    public void Attach(IObserver observer)
    //    {
    //        Console.WriteLine("Подписка на уведомления");
    //        this._subscribers.Add(observer);
    //    }

    //    // Удалить подписчика
    //    public void Detach(IObserver observer)
    //    {
    //        this._subscribers.Remove(observer);
    //        Console.WriteLine("Отписка от уведомлений");
    //    }

    //    // Оповещение подписчиков
    //    public void Notify()
    //    {
    //        Console.WriteLine("Уведомляю о скидках...\n");

    //        foreach (var observer in _subscribers)
    //        {
    //            observer.Update(this);
    //        }
    //    }
    //    // Запустить оповещение
    //    public void Push()
    //    {
    //        this.Notify();
    //    }
    //}

    //// Подписчик
    //class Subscriber : IObserver
    //{
    //    public void Update(ISubject subject)
    //    {
    //        Console.WriteLine("Получил информацию о скидках");
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var salesWebsite = new SalesWebsite();

    //        var subscriber = new Subscriber();

    //        salesWebsite.Attach(subscriber);
    //        salesWebsite.Attach(subscriber);

    //        salesWebsite.Push();

    //        Console.ReadLine();
    //    }
    //}




    //--------------------------------------------------Strategy--------------------------------------------------


    // Боец
    class Fighter
    {
        private IStrategy _strategy;

        public Fighter()
        { }

        public Fighter(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Задать комбо
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }
    
        // Сделать комбо
        public void MakeCombo()
        {
            var result = this._strategy.DoAlgorithm(new List<string> { "punch", "kick", "hit", "crit", "shot" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    // Комбо из двух ударов и выстрела
    class DoublePunchShotStrategy : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;

            list[1] = list[0];
            list[2] = list[4];

            list.RemoveAt(3);
            list.RemoveAt(3);

            return list;
        }
    }

    // Комбо из 2х серий всех ударов
    class UltraMegaComboStrategy : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;

            list.AddRange(list);

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fighter = new Fighter();

            Console.WriteLine("Double punch and shot");
            fighter.SetStrategy(new DoublePunchShotStrategy());
            fighter.MakeCombo();

            Console.WriteLine();

            Console.WriteLine("Ultra mega combo");
            fighter.SetStrategy(new UltraMegaComboStrategy());
            fighter.MakeCombo();
        }
    }
}