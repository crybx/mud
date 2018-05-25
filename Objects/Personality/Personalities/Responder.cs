﻿using Objects.Language;
using Objects.Mob.Interface;
using Objects.Personality.Interface;
using Objects.Personality.Personalities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static Objects.Personality.Personalities.Responder.Response;
using static Shared.TagWrapper.TagWrapper;

namespace Objects.Personality.Personalities
{
    public class Responder : IResponder
    {
        public List<Response> Responses { get; set; } = new List<Response>();
        public INonPlayerCharacter NonPlayerCharacter { get; set; }

        private static string CommunicationHeader { get; } = "<" + TagType.Communication.ToString() + ">";
        private static string CommunicationTrailer { get; } = "</" + TagType.Communication.ToString() + ">";

        public string Process(INonPlayerCharacter npc, string command)
        {
            if (command == null)
            {
                string lastCommunincation = null;
                string lastMessage = null;
                while ((lastMessage = npc.DequeueMessage()) != null)
                {
                    if (lastMessage.StartsWith(CommunicationHeader))
                    {
                        lastCommunincation = lastMessage;
                    }
                }

                if (lastCommunincation != null)
                {
                    lastCommunincation = lastCommunincation.Replace(CommunicationHeader, "");
                    lastCommunincation = lastCommunincation.Replace(CommunicationTrailer, "");

                    string[] words = lastCommunincation.Split(' ');


                    foreach (Response response in Responses)
                    {
                        bool match = true;
                        foreach (OptionalWords optionalWords in response.RequiredWords)
                        {
                            bool localMatch = false;
                            foreach (string optionalWord in optionalWords.TriggerWords)
                            {
                                if (localMatch == false)
                                {
                                    foreach (string word in words)
                                    {
                                        if (word.Equals(optionalWord, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            localMatch = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (localMatch == false)
                            {
                                match = false;
                                break;
                            }
                        }
                    }
                }
            }

            return command;
        }

        public class Response
        {
            public List<OptionalWords> RequiredWords { get; set; } = new List<OptionalWords>();
            public TranslationMessage Message { get; set; }

            public class OptionalWords
            {
                public List<string> TriggerWords { get; set; } = new List<string>();
            }
        }
    }
}
