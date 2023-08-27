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
using Zenject;

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
    public Direction direction { get; set; }

}

public class ServerAIManager : IInitializable
{ 
    private OpenAIApi openai = new OpenAIApi();
    
    private List<ChatMessage> messages = new List<ChatMessage>();

    private string test = "move";
    private string prompt = @"

            You are acting as an agent living in a simulated 2 dimensional universe. 
            Your goal is to exist as best as you see fit and meet your needs.
        
            You have a limited set of capabilities. They are listed below:
              * Move (direction of the walkable TileType in neighbour tile information)
       
 # Responses  
      
      You must supply your responses in the form of valid JSON objects. And do not give different directions other than Walkable tile in neighbour tile information.
      
        {
            action: {
              type: {""move""}
              direction: (ActorDirectionEnvironmentData direction which has tiles exist Walkable tile info) 
            }
        }      

       ";


    private string perceptions;
    
    
    public async Task<AIResponse> SendCommand(Vector3 actorPosition, string directionTileInfos)
    {
        var newMessage = new ChatMessage()
        {
            Role = "user",
            Content = "Test"
        };
        
        perceptions = $@"

        # Perceptions
            You will have access to data to help you make your decisions on what to do next
            For now, this is the information you have access to:
                * Actor Position: {actorPosition}
                * Neighbour Tile Information: {directionTileInfos}  
                * ActorDirectionEnvironmentData has direction and tiles which is located in that direction. If list of tiles is not null and they has Walkable tile type and direction is not None, simply return that direction in move action. Never return empty tiles direction ever.  
        ";

        //Send final prompt always!
        string finalPrompt = prompt;
        finalPrompt += perceptions; 
        
        Debug.LogError(finalPrompt);
        if (messages.Count == 0) newMessage.Content = finalPrompt + "\n";

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
            AIResponse response = JsonConvert.DeserializeObject<AIResponse>(message.Content);
            Debug.LogError(message.Content);
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

    public void Initialize()
    {
        Debug.LogError("AI Manager initialised");
    }
}