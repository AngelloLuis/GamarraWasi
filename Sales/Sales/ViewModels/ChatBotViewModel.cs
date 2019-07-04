﻿using Sales.Models;
using IBM.WatsonDeveloperCloud.Conversation.v1;
using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sales.ViewModels
{
    public class ChatBotViewModel : BindableObject
    {
        private ConversationService _conversation;
        private string _outGoingText;
        public ObservableCollection<ChatMessage> Messages { get; }
        private dynamic _context;
        bool _isInitial = true;


        public ChatBotViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
            OutGoingText = string.Empty;
            ConnectToWatson();
        }

        private void ConnectToWatson()
        {
            _conversation = new ConversationService("apikey", "H4xzsMTLgmvfSF9Br2Qb0avcVAGLkLTluWBfEz7dOGHt", "2019-02-28");
            _conversation.SetEndpoint("https://gateway.watsonplatform.net/assistant/api");
        }

        public string OutGoingText
        {
            get
            {
                return _outGoingText;
            }
            set
            {
                _outGoingText = value;
                OnPropertyChanged();
            }
        }



        public ICommand SendCommand => new Command(SendMessage);




        private async void SendMessage()
        {
            if (!string.IsNullOrEmpty(OutGoingText))
            {
                Messages.Add(new ChatMessage { Text = OutGoingText, IsIncoming = false, MessageDateTime = DateTime.Now });
                string temp = OutGoingText;
                OutGoingText = string.Empty;
                MessageRequest mr = new MessageRequest()
                {
                    Input = new InputData()
                    {
                        Text = temp
                    },

                    Context = _context
                };

                await Task.Run(() => {
                    var res = _conversation.Message("e7121b4c-3580-4651-b24a-69e11ccaf7d1", mr);
                    _context = res.Context;

                    OnWatsonMessagerecieved(JsonConvert.SerializeObject(res, Formatting.Indented));
                });
            }

        }






        private void OnWatsonMessagerecieved(string data)
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                WatsonMessage message = JsonConvert.DeserializeObject<WatsonMessage>(data);

                var listItem = new ChatMessage
                {

                    IsIncoming = true,
                    MessageDateTime = DateTime.Now

                };


                if (message.Output.Generic != null)
                {
                    foreach (var item in message.Output.Generic)
                    {
                        if (item.ResponseType.Equals("image"))
                        {
                            listItem.Image = item.Source.ToString();
                        }
                        if (item.ResponseType.Equals("text"))
                        {
                            listItem.Text = item.Text;
                        }
                    }

                }
                Console.WriteLine(data);
                Messages.Add(listItem);
            });




        }


    }
}
