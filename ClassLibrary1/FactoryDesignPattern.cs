using System;


/// <summary>
///Author : Yuri Narang
///Date : 10 July 2020
/// </summary>
namespace DesignPattern
{
    // Product
    abstract class CreditCard
    {
        public string cardNumber;
        public DateTime expiration;
        public string name;
    }
    // Concrete product
    class VisaCC : CreditCard
    {
        public static bool isValidate(string number)
        {
            if (number.Length != 15)
                return false;
            return (number[0] == '3' && (number[1] == '4' || number[1] == '7'));
        }
    }
    // Concrete product
    class MasterCC : CreditCard
    {
        public static bool isValidate(string number)
        {
            if (number.Length != 16)
                return false;
            return (number[0] == '5'
                && number[1] >= 1 && number[1] <= 5);
        }
    }
    // Concrete product
    class AmExCC : CreditCard
    {
        public static bool isValidate(string number)
        {
            if (number.Length != 16)
                return false;
            return (number[0] == '5'
                && number[1] <= 1
                && number[1] <= 1);
        }

     
    }
    // Concrete product - 
    class Discover : CreditCard
    {
        public static bool isValidate(string number)
        {
            if (number.Length != 16)
                return false;
            return (number.Substring(0, 3) == "6011");
        }
    }
    /// <summary>
    /// Factory class
    /// </summary>
    abstract class CardFactory
    {
        public abstract CreditCard createCard(String number);
    }
    /// <summary>
    /// Concrete factory class
    /// </summary>
    class CreditCardFactory : CardFactory
    {
        public override CreditCard createCard(String number)
        {
            CreditCard cc = null;
            VisaCC vqq = new VisaCC();
            if (number.Length == 0 || number.Length > 19)
                return cc;
            else if (MasterCC.isValidate(number))
                cc = new MasterCC();
            else if (VisaCC.isValidate(number))
                cc = new VisaCC();
            else if (AmExCC.isValidate(number))
                cc = new AmExCC();
            else if (Discover.isValidate(number))
                cc = new Discover();
            return cc;
        }
    }
}
