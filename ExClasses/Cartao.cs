using System;

namespace ExClasses
{
    abstract class Cartao
    {
        protected bool tipo;//True para nacional e False para internacional
        protected double taxaDebito;
        protected double limiteCredito;
        protected double faturaAtual;
        protected double saldoConta;
        protected bool fatura;

        public Cartao(bool tipo)
        {
            this.tipo = tipo;
            this.SetLimit();
            if (this.tipo)
            {
                this.taxaDebito = 0.003;
            } else
            {
                this.taxaDebito = 0.005;
            }
        }
        public Cartao(bool tipo, double saldoConta)
        {
            this.tipo = tipo;
            this.saldoConta = saldoConta;
            this.SetLimit();
            if (this.tipo)
            {
                this.taxaDebito = 0.003;
            }
            else
            {
                this.taxaDebito = 0.005;
            }
        }

        public bool Buy(double valorOperacao, bool tipoOperacao)
        {
            if (tipoOperacao)
            {
                if (this.saldoConta >= (valorOperacao * (1 + this.taxaDebito)))
                {
                    this.saldoConta -= valorOperacao * (1 + this.taxaDebito);
                    return true;
                }
                else
                {
                    Console.WriteLine("Você não possui saldo suficiente para realizar a operação!");
                }
            }
            else
            {
                if (this.fatura)
                {
                    if ((this.limiteCredito - faturaAtual) >= valorOperacao)
                    {
                        this.faturaAtual += valorOperacao;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Você não possui limite suficiente para realizar a operação!");
                    }
                }
                else
                {
                    Console.WriteLine("Sua fatura fechou ou ainda não foi paga, favor efetuar o pagamento para que consiga utilizar nossos cartões!");
                }
            }
            return false;
        }

        public bool Buy(double valorOperacao)
        {
            if (this.fatura)
            {
                if ((this.limiteCredito - faturaAtual) >= valorOperacao)
                {
                    this.faturaAtual += valorOperacao;
                    return true;
                }
                else
                {
                    Console.WriteLine("Você não possui limite suficiente para realizar a operação!");
                }
            }
            else
            {
                Console.WriteLine("Sua fatura fechou ou ainda não foi paga, favor efetuar o pagamento para que consiga utilizar nossos cartões!");
            }
            return false;
        }

        public void Deposit(double saldoConta)
        {
            if (saldoConta > 0)
            {
                this.saldoConta = saldoConta;
            }
        }

        public void ClosePeriod()
        {
            this.fatura = false;
            Console.WriteLine("Sua fatura ficou em R$ {0}", this.faturaAtual);
        }

        public void PayAccount()
        {
            Console.WriteLine("Sua fatura ficou em {0}, digite 1 para que realizemos o débito em sua conta corrente ou qualquer outra tecla para sair");
            string opt = Console.ReadLine();
            if(opt == "1")
            {
                if(this.saldoConta >= this.faturaAtual)
                {
                    this.faturaAtual = 0;
                    this.fatura = true;
                } else
                {
                    Console.WriteLine("Você não possui saldo suficiente para efeturar o pagamento!");
                }
            } else
            {
                Console.WriteLine("Pagamento cancelado, estamos aguardando seu retorno para normalizar seu acesso aos nossos cartões!");
            }
        }

        protected virtual void SetLimit()
        {
            Random randNum = new Random();
            double scoreSerasa = randNum.Next(1, 1000);
            if (scoreSerasa < 200)
            {
                this.limiteCredito = scoreSerasa;
            }
            else if (scoreSerasa > 200 && scoreSerasa <= 500)
            {
                this.limiteCredito = 3 * scoreSerasa;
            }
            else if (scoreSerasa > 500 && scoreSerasa <= 700)
            {
                this.limiteCredito = 4 * scoreSerasa;
            }
            else
            {
                this.limiteCredito = randNum.Next(7, 10) * scoreSerasa;
            }
        }
    }
}
