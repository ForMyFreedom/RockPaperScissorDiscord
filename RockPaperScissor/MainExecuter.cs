using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    class MainExecuter
    {
        static private String[] DiscordPrefixes = new[] { "!rps " };
        static private DiscordClient discord;
        static private CommandsNextExtension commands;

        static void Main(String[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            StartAsyncBot().GetAwaiter().GetResult();
        }



        static private async Task StartAsyncBot()
        {
            CreateDiscordClient(GetDiscordConfiguration());
            RegisterInterativity();
            StartTheBaseOfDiscordCommands();
            RegisterPreWarCommands();
            TryGetAllGameData();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }




        private static void CreateDiscordClient(DiscordConfiguration cdc)
        {
            discord = new DiscordClient(cdc);
        }


        private static DiscordConfiguration GetDiscordConfiguration()
        {
            return new DiscordConfiguration
            {
                Token = System.IO.File.ReadAllLines("../../../token.secret")[0],
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                ReconnectIndefinitely = true,
                GatewayCompressionLevel = GatewayCompressionLevel.None,
                AutoReconnect = true,
            };
        }


        private static void RegisterInterativity()
        {
            discord.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromMinutes(1)
            });
        }


        private static void StartTheBaseOfDiscordCommands()
        {
            commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = DiscordPrefixes
            });
        }

        public static void RegisterPreWarCommands()
        {
            commands.RegisterCommands<Commands.StartUpCommand>();
            commands.SetHelpFormatter<CustomHelpFormatter>();
        }


        public static void RegisterDefaultCommands()
        {
            commands.RegisterCommands<Commands.DeckManagementCommands>();
            commands.RegisterCommands<Commands.CardClaimCommand>();
            commands.RegisterCommands<Commands.GameMarketCommands>();
            commands.RegisterCommands<Commands.DuelDeckCommands>();
        }



        private static void TryGetAllGameData()
        {
            try
            {
                AllGameData.StartNewData();
                String[] allDataText = File.ReadAllLines("AllData.txt");

                bool operationSucesseful = MyDeserializable.GetDataFromText(allDataText.ToList<String>());
                if (!operationSucesseful)
                {
                    AllGameData.StartNewData();
                    return;
                }

                RegisterDefaultCommands();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                AllGameData.StartNewData();
            }
        }


        static void OnProcessExit(object sender, EventArgs e)
        {
            MySerializable.SetDataInText("AllData.txt");
        }

    }
}




//https://discord.com/developers/applications/837022276079583312/oauth2

//https://www.youtube.com/watch?v=7-tyLCAO4mY&list=PLS6sInD7ThM0Zb8F_KBl4T_jGF1e3apsc&index=1

//?????????????
//https://dsharpplus.github.io/articles/beyond_basics/messagebuilder.html
//https://dsharpplus.github.io/articles/commands/help_formatter.html
//https://dsharpplus.github.io/articles/commands/argument_converters.html
//https://dsharpplus.github.io/articles/commands/command_handler.html




//                                  Básico
//https://dsharpplus.github.io/articles/basics/first_bot.html
//https://dsharpplus.github.io/articles/commands/intro.html
//https://dsharpplus.github.io/articles/interactivity.html


//                                  Avançado
//Atributos de Comando
//  https://dsharpplus.github.io/articles/commands/command_attributes.html
//Eventos
//  https://dsharpplus.github.io/articles/beyond_basics/events.html
//Dependency Injection
//  https://dsharpplus.github.io/articles/commands/dependency_injection.html



//                                  Talvez útil
//Deixa o server mais leve
//  https://dsharpplus.github.io/articles/beyond_basics/messagebuilder.html
