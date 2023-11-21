using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Project.Client;
using Project.Client.Layout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Radzen;
using Radzen.Blazor;

namespace Project.Client.Pages.Chatbot
{
    public partial class Chatbot2
    {

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private bool isChatOpen = false;
        private string userInput;
        private List<ChatMessage> chatMessages = new List<ChatMessage>();
        private bool isLoading = false;
        private ElementReference conversationRef;

        private int currentStep = 0;

        private List<string> choices = new List<string>();

        private void OpenChat()
        {
            if(isChatOpen == false){
                isChatOpen = true;
                chatMessages.Add(new ChatMessage("Welkom! Hoe kan ik je helpen?", true));
                UpdateChoices();
            }
            else
            {
                CloseChat();
            }
        }

        private void CloseChat()
        {
            isChatOpen = false;
            chatMessages.Clear();
            currentStep = 0;
        }

        //private void SendMessage()
        //{
        //    if (!string.IsNullOrWhiteSpace(userInput))
        //    {
        //        chatMessages.Add(new ChatMessage("Jij: " + userInput, false));
        //        // Hier zou je normaal gesproken logica toevoegen om de bot te laten antwoorden
        //        // Voor dit eenvoudige voorbeeld antwoordt de bot altijd met "Contacteer arts"
        //        chatMessages.Add(new ChatMessage("Bot: Contacteer arts", true));
        //        userInput = string.Empty;
        //    }
        //}

        private void HandleStepOne(string option)
        {
            switch (option.ToLower())
            {
                case "op zoek naar iets in website":
                    chatMessages.Add(new ChatMessage("Naar welke informatie bent u op zoek?", true));
                    currentStep = 1;
                    UpdateChoices();
                    break;
                case "een afpraak maken":
                    chatMessages.Add(new ChatMessage("Op welke manier wenst u een afpraak te maken?", true));
                    currentStep = 2;
                    UpdateChoices();
                    break;
                case "contact opnemen met arts":
                    chatMessages.Add(new ChatMessage("Op welke manier wenst u de arts te contacteren?", true));
                    currentStep = 3; 
                    UpdateChoices();
                    break;
                default:
                    chatMessages.Add(new ChatMessage("", true));
                    break;
            }
        }

        private void HandleStepTwo(string option)
        {
            switch (option.ToLower())
            {
                case "vraag over de praktijk":
                    chatMessages.Add(new ChatMessage($"<a style='color: white; text-decoration: none;' href='/overons' onmouseover='this.style.color=\"#2dc3d6\"' onmouseout='this.style.color=\"white\"'>Hier vindt u meer info over de praktijk</a>", true));
                    break;
                case "vraag over oogaandoeningen":
                    chatMessages.Add(new ChatMessage($"<a style='color: white; text-decoration: none;' href='/oogaandoening' onmouseover='this.style.color=\"#2dc3d6\"' onmouseout='this.style.color=\"white\"'>Hier kan u meer info vinden over oogaandoeningen</a>", true));
                    break;
                case "contact en openingsuren":
                    chatMessages.Add(new ChatMessage($"<a style='color: white; text-decoration: none;' href='/contact' onmouseover='this.style.color=\"#2dc3d6\"' onmouseout='this.style.color=\"white\"'>Hier kan u meer info vinden voor contact op te nemen of voor de openingsuren</a>", true));
                    break;
                default:
                    chatMessages.Add(new ChatMessage("Bot: Antwoord op gekozen optie", true));
                    break;
            }
        }
        private void HandleStepTree(string option)
        {
            switch (option.ToLower())
            {
                case "via website":
                    chatMessages.Add(new ChatMessage("Ik stuur u door naar het afspraak scherm.", true));
                    NavigationManager.NavigateTo("/Afspraak");
                    break;
                case "telefonisch":
                    chatMessages.Add(new ChatMessage("Bel naar +32 486 21 51 32", true));
                    break;
                default:
                    chatMessages.Add(new ChatMessage("", true));
                    break;
            }
        }

        private void HandleStepFour(string option)
        {
            switch (option.ToLower())
            {
                case "email":
                    string email = "VisionOogcentrum@gmail.com";
                    string title = "Vraag via chatbot";
                    string mailtoLink = $"mailto:{email}?subject={Uri.EscapeDataString(title)}";
                    chatMessages.Add(new ChatMessage($"<a href=\"{mailtoLink}\" target=\"_blank\" style='color: white; text-decoration: none;' onmouseover='this.style.color=\"#2dc3d6\"'>Stuur een e-mail</a>", true));
                    break;
                case "bellen":
                    chatMessages.Add(new ChatMessage("U kunt bellen naar: +32 486 21 51 32", true));
                    break;
                case "adres":
                    chatMessages.Add(new ChatMessage("Ons adres is: Antwerpsesteenweg 1022 9040 Gent", true));
                    break;
                default:
                    chatMessages.Add(new ChatMessage("", true));
                    break;
            }
        }

        private async void ChooseOption(string option)
        {
            chatMessages.Add(new ChatMessage($"Jij koos: {option}", false));

            switch (currentStep)
            {
                case 0:
                    HandleStepOne(option);
                    break;
                case 1:
                    HandleStepTwo(option);
                    break;
                case 2:
                    HandleStepTree(option);
                    break;
                case 3:
                    HandleStepFour(option);
                    break;
                default:
                    chatMessages.Add(new ChatMessage("Bot: Antwoord op gekozen optie", true));
                    break;
            }
           
            UpdateChoices();
        }

        private void UpdateChoices()
        {
            choices.Clear();

            switch (currentStep)
            {
                case 0:
                    choices.Add("Op zoek naar iets in website");
                    choices.Add("Een afpraak maken");
                    choices.Add("Contact opnemen met arts");
                    break;
                case 1:
                    choices.Add("Vraag over de praktijk");
                    choices.Add("Vraag over oogaandoeningen");
                    choices.Add("Contact en openingsuren");
                    break;
                case 2:
                    choices.Add("Via website");
                    choices.Add("Telefonisch");
                    break;
                case 3:
                    choices.Add("Email");
                    choices.Add("Bellen");
                    choices.Add("Adres");
                    break;
                default:
                    choices.Add("Default Option 1");
                    choices.Add("Default Option 2");
                    choices.Add("Default Option 3");
                    break;
            }
        }

        private void RefreshChat()
        {
            currentStep = 0;
            choices.Clear();
            chatMessages.Clear();
            choices.Add("Op zoek naar iets in website");
            choices.Add("Een afpraak maken");
            choices.Add("Contact opnemen met arts");
            chatMessages.Add(new ChatMessage("Welkom terug! Hoe kan ik je helpen?", true));
            UpdateChoices();
        }

        private class ChatMessage
        {
            public ChatMessage(string text, bool isBotMessage)
            {
                Text = text;
                IsBotMessage = isBotMessage;
            }

            public string Text { get; }
            public bool IsBotMessage { get; }
        }
    }
}