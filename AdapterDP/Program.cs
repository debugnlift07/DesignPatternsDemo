//Convert an existing interface (legacy or third-party) into another interface your application expects — without changing the original code.

//or
//Adapter is a stuctural desgin pattern that
//allow objects with incompatiable interfaces to 
//collaborate.


//Step 4- client (using adapter without knowing paypal internals)


IPaymentProcesser payment = new PayPalAdapter(new PayPalService());
payment.ProcessPayment("NAVEEN.BISHT@GMAIL.COM", 576.9m);


//Step 1- Target (our app)
public interface IPaymentProcesser
{
    void ProcessPayment(string email, decimal amount);
}

//Step2- Existing service,(third party or legasy code)
public class PayPalService
{
    public void SendPayment(string account, double amount)
    {
        Console.WriteLine($"Paypal payment {amount} process for account : ");
    }
}

//Step 3- Adapter(bridge bw target & service)
public class PayPalAdapter : IPaymentProcesser
{
    private readonly PayPalService _payPalService;
    public PayPalAdapter(PayPalService payPalService)
    {
        _payPalService = payPalService;
    }
    public void ProcessPayment(string account, decimal amount)
    {
        _payPalService.SendPayment(account, (double)amount);
    }
}