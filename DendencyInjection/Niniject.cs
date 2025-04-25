using System;
using Ninject;

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

    class Niniject
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ICreditCard>().To<VisaCard>(); // or .To<MasterCard>();
            var shopper = kernel.Get<Shopper>();
            shopper.Checkout();
        }
    }
}
