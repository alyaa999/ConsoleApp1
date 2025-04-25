using System;
using Autofac;

namespace D02App1
{
    interface ICreditCard
    {
        void Charge();
    }

    internal class VisaCard : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using Visa Card........");
        }
    }

    internal class MasterCard : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using MasterCard........");
        }
    }

    internal class Shopper
    {
        private readonly ICreditCard _card;

        public Shopper(ICreditCard card)
        {
            _card = card;
        }

        internal void Checkout()
        {
            _card.Charge();
        }
    }

    class Program
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<VisaCard>().As<ICreditCard>();
            builder.RegisterType<Shopper>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var shopper = scope.Resolve<Shopper>();
                shopper.Checkout();
            }
        }
    }
}
