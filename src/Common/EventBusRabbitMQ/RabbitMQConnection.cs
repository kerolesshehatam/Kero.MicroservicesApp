using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;

namespace EventBusRabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            if (!IsConnected)
            {
                TryConnect();
            }
        }

        public bool IsConnected
        {
            get { return _connection != null && _connection.IsOpen && !_disposed; }
        }

        public bool TryConnect()
        {
            try
            {
                _connection = _connectionFactory.CreateConnection();
                return false;
            }
            catch (BrokerUnreachableException)
            {
                _connection = _connectionFactory.CreateConnection();
            }
            return IsConnected;
        }

        public IModel CreateModel
        {
            get
            {
                return IsConnected ? _connection.CreateModel() : throw new InvalidOperationException("No Rabbit MQ connection");
            }
        }


        public void Dispose()
        {
            if (!_disposed)
                _connection.Dispose();
        }
    }
}
