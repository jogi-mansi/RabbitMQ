using RabbitMQ.Client;
using System.Text;
var factory=new ConnectionFactory()
{
    HostName="localhost",
};
var connection = factory.CreateConnection();
var channel=connection.CreateModel();
for(int i = 1; i <= 1000000; i++)
{
    var bodyMessage = Encoding.UTF8.GetBytes("This is a Test Product Order"+i);
    /* using Direct Exchange*/
    //channel.BasicPublish(exchange: "", routingKey: "ProductTestQue", basicProperties: null, body: bodyMessage);
    //channel.BasicPublish(exchange: "Amazon Exch", routingKey: "productOrderKey", basicProperties: null, body: bodyMessage);
    /* using Fanout Exchange*/
    channel.BasicPublish(exchange: "Amazonfanout Exch", routingKey: "", basicProperties: null, body: bodyMessage);
    Console.WriteLine(Encoding.UTF8.GetString(bodyMessage));
}

Console.WriteLine("Message sent");
Console.ReadLine();