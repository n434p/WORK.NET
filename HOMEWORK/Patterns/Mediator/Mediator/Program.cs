using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague constructor = new ConstructionColleague(mediator);
            Colleague post = new PostColleague(mediator);
            mediator.Customer = customer;
            mediator.Constructor = constructor;
            mediator.Post = post;
            customer.Send("Customer have new order for the factory."); // Factory can construct ordered unit
            constructor.Send("Factory done his work."); // Unit construction is complete. Post service can bring unit to the customer
            post.Send("Unit was delivered"); // Customer can get unit  

            Console.Read();
        }
    }

    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }

    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("To the customer: " + message);
        }
    }

    class ConstructionColleague : Colleague
    {
        public ConstructionColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("To the factory: " + message);
        }
    }

    class PostColleague : Colleague
    {
        public PostColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("To the post service: " + message);
        }
    }

    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Constructor { get; set; }
        public Colleague Post { get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            // if sender is customer - send message to the factory
            // etc. There is some order to construct unit
            if (Customer == colleague)
                Constructor.Notify(msg);
            // if sender is factory - send message to the post service
            // etc. Unit is complete needed to deliver
            else if (Constructor == colleague)
                Post.Notify(msg);
            // at least if sender is post service - send message to the customer
            else if (Post == colleague)
                Customer.Notify(msg);
        }
    }


}
