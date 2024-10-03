namespace HW_03_10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank1 = new Bank();
            ATM atm1 = new ATM(bank1);
            ATM atm2 = new ATM(bank1);

            new Thread(()=>atm1.WitdrawMoney(500)).Start();
            new Thread(()=>atm2.WitdrawMoney(800)).Start();

            bank1.GetBalance();

            Console.ReadLine();
        }
    }


    public class ATM
    {
        private Bank Bank { get; set; }

        public ATM(Bank bank)
        {
            this.Bank = bank;
        }

        public void WitdrawMoney(int amount)
        {
            Bank.WitdrawMoney(amount);
        }
    }

    public class Bank
    {
        private int BankBalance = 1000;

        public void WitdrawMoney(int amount) {
            lock (this) 
            { 
                if(amount > BankBalance)
                {
                    Console.WriteLine("На балансе недостаточно денег");
                }
                else
                {
                    Thread.Sleep(10000);
                    BankBalance -= amount;
                    Console.WriteLine($"Успешно сняли {amount} \n Текущий баланс: {BankBalance} ");
                }
            }
        }

        public int GetBalance()
        {
            return BankBalance;
        }
    }
}
