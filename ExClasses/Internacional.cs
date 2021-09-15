using System;

namespace ExClasses
{
    class Internacional : Cartao
    {
        public Internacional() : base(false) { }
        public Internacional(double saldoConta) : base(false, saldoConta) { }

        protected override void SetLimit()
        {
            Random randNum = new Random();
            double scoreSerasa = randNum.Next(1, 1000);
            if (scoreSerasa < 200)
            {
                this.limiteCredito = scoreSerasa * 5;
            }
            else if (scoreSerasa > 200 && scoreSerasa <= 500)
            {
                this.limiteCredito = (3 * scoreSerasa) * 5;
            }
            else if (scoreSerasa > 500 && scoreSerasa <= 700)
            {
                this.limiteCredito = (4 * scoreSerasa) * 5;
            }
            else
            {
                this.limiteCredito = (randNum.Next(7, 10) * scoreSerasa) * 5;
            }
        }
    }
}
