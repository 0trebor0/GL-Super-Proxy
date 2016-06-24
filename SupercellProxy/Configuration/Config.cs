﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SupercellProxy
{
    class Config
    {
        private static Configuration Configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Gets a configuration value as string
        /// </summary>
        public static string Get(string key)
        {
            return Configuration.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// Sets a configuration value as string
        /// </summary>
        public static void Set(string key, string value)
        {
            Configuration.AppSettings.Settings[key].Value = value;
            Configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Returns the host
        /// </summary>
        public static string Host
        {
            get
            {
                return Get("Host").ToLower();
            }
        }

        /// <summary>
        /// Returns the game
        /// </summary>
        public static Game Game
        {
            get
            {
                if (Host == "game.clashofclans.com" || Host == "gamea.clashofclans.com")
                {
                    // Only configure the proxy to CoC if the host is valid
                    return Game.CLASH_OF_CLANS;
                }
                else if (Host == "game.clashroyaleapp.com" || Host == "gamec.clashroyaleapp.com" || Host == "stage.scroll.supercelltest.com" || Host == "integration.scroll.supercelltest.com" || Host == "integration-ext.scroll.supercelltest.com" || Host == "integration-ext-2.scroll.supercelltest.com")
                    
                {
                    // Only configure the proxy to CR if the host is valid
                    return Game.CLASH_ROYALE;
                }
                else if (Host == "game.boombeachgame.com")
                {
                    return Game.BOOM_BEACH;
                }
                else
                {
                    Console.Clear();
                    Logger.Log("You configured an invalid host (" + Host + ")!", LogType.WARNING);
                    Logger.Log("Please check your config file!", LogType.WARNING);
                    Program.WaitAndKill();
                    return Game.CLASH_ROYALE;
                 }                    
            }
        }

        /// <summary>
        /// Returns the loglevel
        /// </summary>
        public static LogLevel LogLevel
        {
            get
            {
                switch (Get("LogLevel").ToLower())
                {
                    case "silent":
                        return LogLevel.SILENT;
                    case "default":
                        return LogLevel.DEFAULT;
                    default:
                        return LogLevel.DEFAULT;
                }
            }
        }

        /// <summary>
        /// Returns the WebAPI port
        /// </summary>
        public static int WebAPI_PORT
        {
            get
            {
                int ret;
                if (!Int32.TryParse(Get("WebAPI_PORT"), out ret))
                    ret = 5050;
                return ret;
            }
        }
    }
}
