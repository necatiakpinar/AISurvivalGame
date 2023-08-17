using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAI;
using UnityEngine;

[Serializable]
public class AIResponse
{
    public AIAction action;
}

[Serializable]
public class AIAction
{
    public string type;
    
    [JsonConverter(typeof(StringEnumConverter))]
    public Direction direction;
}

public class ServerAIManager 
{ 
    private OpenAIApi openai = new OpenAIApi();
    
    private List<ChatMessage> messages = new List<ChatMessage>();

    private string test = "move";

    private string prompt = @"

            You are acting as an agent living in a simulated 2 dimensional universe. 
            Your goal is to exist as best as you see fit and meet your needs.
        
            You have a limited set of capabilities. They are listed below:
              * Move (North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest)
              * Wait
              * Navigate (to an x,y coordinate)

 # Responses  
      
      You must supply your responses in the form of valid JSON objects.  Your responses will specify which of the above actions you intend to take.  Never talk with me, just provide JSON format object. The following is an example of a valid response. For now give random directions!:
      
        {
            action: {
              type: {""move""}
              direction: ""North"" | ""NorthEast"" | ""East"" | ""SouthEast"" | ""SouthWest"" | ""West"" | ""NorthWest"" | 
            }
        }      

                            "; 
                            // $"Position: {EventManager.GetActivePlayer().transform.position}";


    public async Task<AIResponse> SendCommand()
    {
        var newMessage = new ChatMessage()
        {
            Role = "user",
            Content = "Test"
        };
        
        if (messages.Count == 0) newMessage.Content = prompt + "\n";

        messages.Add(newMessage);
        
        // Complete the instruction
        var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
        {
            Model = "gpt-3.5-turbo-0613",
            Messages = messages,
            //   MaxTokens = 128 //This is stands for word and punctuation count
        });

        if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
        {
            var message = completionResponse.Choices[0].Message;
            message.Content = message.Content.Trim();
            messages.Add(message);
            AIResponse response = JsonUtility.FromJson<AIResponse>(message.Content);
            if (response != null)
                return response;
        }
        else
        {
            Debug.LogWarning("No text was generated from this prompt.");
            return null;
        }

        return null;

    }
}
