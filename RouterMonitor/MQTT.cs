using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;

namespace RouterMonitor
{
    public class MQTT
    {
        String BaseTopic;
        String Host;

        public MQTT(String BaseTopic, String Host)
        {
            this.BaseTopic = BaseTopic;
            this.Host = Host;
        }


        public void Publish_Application_Message(String Topic, int Payload)
        {
            Publish_Application_Message(Topic, Payload.ToString());
        }

        public void Publish_Application_Message(String Topic, decimal Payload)
        {
            Publish_Application_Message(Topic, Payload.ToString());
        }

        public async Task Publish_Application_Message(String Topic, String Payload)
        {
            /*
             * This sample pushes a simple application message including a topic and a payload.
             *
             * Always use builders where they exist. Builders (in this project) are designed to be
             * backward compatible. Creating an _MqttApplicationMessage_ via its constructor is also
             * supported but the class might change often in future releases where the builder does not
             * or at least provides backward compatibility where possible.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(Host)
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(BaseTopic + "/" + Topic)
                    .WithPayload(Payload)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                //Console.WriteLine("MQTT application message is published.");
            }
        }
    }
}

