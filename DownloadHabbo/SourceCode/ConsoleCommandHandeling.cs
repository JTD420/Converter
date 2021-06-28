using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Xml;

namespace ConsoleApplication
{
    internal class ConsoleCommandHandeling
    {
        internal static void InvokeCommand(string inputData)
        {
            Console.WriteLine();
            try
            {
                string[] strArray1 = inputData.Split(new char[1]
                {
          ' '
                });
                switch (strArray1[0].ToLower())
                {
                    case "download":
                        Console.WriteLine("Starting Download...");
                        string str1;
                        switch (strArray1[1].ToLower())
                        {
                            case "reception":
                                if (!Directory.Exists("./temp"))
                                {
                                    Directory.CreateDirectory("./temp");
                                }
                                if (!Directory.Exists("./reception"))
                                {
                                    Directory.CreateDirectory("./reception");
                                }
                                if (!Directory.Exists("./reception/catalogue"))
                                {
                                    Directory.CreateDirectory("./reception/catalogue");
                                }
                                if (!Directory.Exists("./reception/web_promo_small"))
                                {
                                    Directory.CreateDirectory("./reception/web_promo_small");
                                }
                                Console.WriteLine("This downloads not all images. Only the ones that are defined in the external_variables");
                                Console.WriteLine("Run this once in a while to collect all images!");
                                Console.WriteLine("Catalogue Teasers used on the reception are stored in /catalogue/");
                                Console.WriteLine("web_promo_small images used on the reception are stored in /reception/web_promo_small");
                                Console.WriteLine();
                                string str2 = "./temp/external_variables.txt";
                                Console.WriteLine("Downloading external variables");
                                WebClient webClient1 = new WebClient();
                                webClient1.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient1.DownloadFile("https://www.habbo.com/gamedata/external_variables/", str2);
                                Console.WriteLine("Lets start downloading!");
                                int num1 = 0;
                                using (new StreamWriter("./temp/external_variables2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader(str2))
                                    {
                                        str1 = (string)null;
                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.Contains("reception/"))
                                            {
                                                string[] strArray2 = str3.Split(new string[1]
                                                {
                          "reception/"
                                                }, StringSplitOptions.None);
                                                try
                                                {
                                                    if (strArray2[1].Contains(".png,"))
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ","
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./reception/" + strArray3[0]))
                                                        {
                                                            webClient1.DownloadFile("http://images.habbo.com/c_images/reception/" + strArray3[0], "./reception/" + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading " + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            ++num1;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray3[0] + " already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ";"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./reception/" + strArray3[0]))
                                                        {
                                                            webClient1.DownloadFile("http://images.habbo.com/c_images/reception/" + strArray3[0], "./reception/" + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading " + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            ++num1;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray3[0] + " already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                    if (strArray2[1].Contains(".png,"))
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ","
                                                        }, StringSplitOptions.None);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error downloading " + strArray3[0]);
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                    }
                                                    else
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ";"
                                                        }, StringSplitOptions.None);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error downloading " + strArray3[0]);
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                    }
                                                }
                                            }
                                            if (str3.Contains("catalogue/"))
                                            {
                                                string[] strArray2 = str3.Split(new string[1]
                                                {
                          "catalogue/"
                                                }, StringSplitOptions.None);
                                                try
                                                {
                                                    if ((strArray2[1].Contains(".png,") ? 0 : (!strArray2[1].Contains(".gif,") ? 1 : 0)) == 0)
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ","
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./reception/catalogue/" + strArray3[0]))
                                                        {
                                                            webClient1.DownloadFile("http://habboo-a.akamaihd.net/c_images/catalogue/" + strArray3[0], "./reception/catalogue/" + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading catalogue " + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            ++num1;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray3[0] + " already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ";"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./reception/catalogue/" + strArray3[0]))
                                                        {
                                                            webClient1.DownloadFile("http://habboo-a.akamaihd.net/c_images/catalogue/" + strArray3[0], "./reception/catalogue/" + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading catalogue " + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            ++num1;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray3[0] + " already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                    if ((strArray2[1].Contains(".png,") ? 0 : (!strArray2[1].Contains(".gif,") ? 1 : 0)) == 0)
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ","
                                                        }, StringSplitOptions.None);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error downloading catalogue " + strArray3[0]);
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                    }
                                                    else
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ";"
                                                        }, StringSplitOptions.None);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error downloading catalogue " + strArray3[0]);
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                    }
                                                }
                                            }
                                            if (str3.Contains("web_promo_small/"))
                                            {
                                                string[] strArray2 = str3.Split(new string[1]
                                                {
                          "web_promo_small/"
                                                }, StringSplitOptions.None);
                                                try
                                                {
                                                    if ((strArray2[1].Contains(".png,") ? 0 : (!strArray2[1].Contains(".gif,") ? 1 : 0)) == 0)
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ","
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./reception/web_promo_small/" + strArray3[0]))
                                                        {
                                                            webClient1.DownloadFile("http://images.habbo.com/c_images/web_promo_small/" + strArray3[0], "./reception/web_promo_small/" + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading web_promo_small " + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            ++num1;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray3[0] + " already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ";"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./reception/web_promo_small/" + strArray3[0]))
                                                        {
                                                            webClient1.DownloadFile("http://images.habbo.com/c_images/web_promo_small/" + strArray3[0], "./reception/web_promo_small/" + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading web_promo_small " + strArray3[0]);
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            ++num1;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray3[0] + " already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                    if ((strArray2[1].Contains(".png,") ? 0 : (!strArray2[1].Contains(".gif,") ? 1 : 0)) == 0)
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ","
                                                        }, StringSplitOptions.None);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error downloading web_promo_small " + strArray3[0]);
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                    }
                                                    else
                                                    {
                                                        string[] strArray3 = strArray2[1].Split(new string[1]
                                                        {
                              ";"
                                                        }, StringSplitOptions.None);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error downloading web_promo_small " + strArray3[0]);
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Finished downloading images");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    goto temp;
                                }
                            case "furniture":
                                Console.WriteLine("Furniture Download Started");
                                break;

                            case "icons":
                                Console.WriteLine("Catalogue Icons Download Started");
                                if (!Directory.Exists("./icons"))
                                {
                                    Directory.CreateDirectory("./icons");
                                }
                                WebClient webClient2 = new WebClient();
                                webClient2.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                int num2 = 1;
                                int num3 = 1;
                                while (num3 <= 20)
                                {
                                    try
                                    {
                                        if (!System.IO.File.Exists("./icons/icon_" + (object)num2 + ".png"))
                                        {
                                            webClient2.DownloadFile("https://images.habbo.com/c_images/catalogue/icon_" + (object)num2 + ".png", "./icons/icon_" + (object)num2 + ".png");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Downloaded Icon " + (object)num2);
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            ++num2;
                                            num3 = 1;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            Console.WriteLine("Icon " + (object)num2 + " already exists!");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            ++num2;
                                            num3 = 1;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error downloading icon " + (object)num2);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        ++num3;
                                        ++num2;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Finished downloading icons!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto readline;

                            case "mp3":
                                Console.WriteLine("MP3 Sounds Download Started");
                                if (!Directory.Exists("./mp3"))
                                {
                                    Directory.CreateDirectory("./mp3");
                                }
                                WebClient webClient3 = new WebClient();
                                webClient3.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                int num4 = 1;
                                int num5 = 1;
                                while (num5 <= 20)
                                {
                                    try
                                    {
                                        if (!System.IO.File.Exists("./mp3/sound_machine_sample_" + (object)num4 + ".mp3"))
                                        {
                                            webClient3.DownloadFile("https://images.habbo.com/dcr/hof_furni/mp3/sound_machine_sample_" + (object)num4 + ".mp3", "./mp3/sound_machine_sample_" + (object)num4 + ".mp3");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Downloaded MP3 " + (object)num4);
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            ++num4;
                                            num5 = 1;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            Console.WriteLine("MP3 " + (object)num4 + " already exists!");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            ++num4;
                                            num5 = 1;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error downloading MP3 " + (object)num4);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        ++num5;
                                        ++num4;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Finished downloading MP3!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto readline;

                            case "furnidata":
                                if (!Directory.Exists("./files"))
                                {
                                    Directory.CreateDirectory("./files");
                                }
                                Console.WriteLine("Saving furnidata...");
                                WebClient webClient = new WebClient();
                                webClient.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient.DownloadFile("https://habbo.com/gamedata/furnidata/1", "./files/furnidata.txt");
                                webClient.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient.DownloadFile("https://www.habbo.com/gamedata/furnidata_xml/1", "./files/furnidata_xml.xml");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Furnidata Saved");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto readline;
                            case "effects":
                                string release_effect;
                                HttpClient httpClient_version_effect = new HttpClient();
                                httpClient_version_effect.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36");
                                Task.Run(async () =>
                                 {
                                     try
                                     {
                                         HttpResponseMessage res = await httpClient_version_effect.GetAsync("https://www.habbo.com/gamedata/external_variables/1");
                                         string source = (await res.Content.ReadAsStringAsync());
                                         foreach (string Line in source.Split(Environment.NewLine.ToCharArray()))
                                         {
                                             if (!Line.Contains("flash.client.url="))
                                             {
                                                 continue;
                                             }
                                             release_effect = Line.Substring(0, Line.Length - 1).Split('/')[4];
                                             if (!Directory.Exists("./files"))
                                             {
                                                 Directory.CreateDirectory("./files");
                                             }
                                             Console.ForegroundColor = ConsoleColor.Blue;
                                             Console.WriteLine("Downloading Effects version : " + release_effect);
                                             WebClient webClient_effect = new WebClient();
                                             webClient_effect.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                             webClient_effect.DownloadFile("https://images.habbo.com/gordon/" + release_effect + "/effectmap.xml", "./effect/effectmap.xml");
											 webClient_effect.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
											 webClient_effect.DownloadFile("https://images.habbo.com/gordon/" + release_effect + "/HabboAvatarActions.xml", "./effect/HabboAvatarActions.xml");
                                             Console.ForegroundColor = ConsoleColor.Green;
                                             Console.WriteLine("Downloading Effects Saved");
                                             Console.ForegroundColor = ConsoleColor.Gray;
                                         }
                                     }
                                     catch (Exception e)
                                     {
                                         Console.WriteLine(e);
                                     }
                                 });
                                goto readline;

                            case "texts":
                                if (!Directory.Exists("./files"))
                                {
                                    Directory.CreateDirectory("./files");
                                }
                                Console.WriteLine("Saving external flash texts...");
                                WebClient webClient_a = new WebClient();
                                webClient_a.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient_a.DownloadFile("https://habbo.com/gamedata/external_flash_texts/1", "./files/external_flash_texts.txt");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Furnidata Saved");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto readline;
                            case "productdata":
                                if (!Directory.Exists("./files"))
                                {
                                    Directory.CreateDirectory("./files");
                                }
                                Console.WriteLine("Saving productdata...");
                                WebClient webClient_b = new WebClient();
                                webClient_b.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient_b.DownloadFile("https://habbo.com/gamedata/productdata/1", "./files/productdata.txt");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Productdata Saved");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto readline;
                            case "variables":
                                if (!Directory.Exists("./files"))
                                {
                                    Directory.CreateDirectory("./files");
                                }
                                Console.WriteLine("Saving External Variables...");
                                WebClient webClient_c = new WebClient();
                                webClient_c.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient_c.DownloadFile("http://habbo.com/gamedata/external_variables/1", "./files/external_variables.txt");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("External Variables Saved");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto readline;
                            case "quests":
                                int num6 = 0;
                                string str4 = "./temp/external_texts.txt";
                                if (!Directory.Exists("./temp"))
                                {
                                    Directory.CreateDirectory("./temp");
                                }
                                System.IO.File.Delete(str4);
                                WebClient webClient4 = new WebClient();
                                webClient4.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient4.DownloadFile("https://www.habbo.com/gamedata/external_flash_texts/1", str4);
                                Console.WriteLine("External Flash Texts Downloaded...");
                                Console.WriteLine("Begin parsing...");
                                using (StreamReader streamReader = new StreamReader(str4))
                                {
                                    str1 = (string)null;
                                    Thread.Sleep(1000);
                                    string str3;
                                    while ((str3 = streamReader.ReadLine()) != null)
                                    {
                                        if (str3.StartsWith("quests."))
                                        {
                                            string[] strArray2 = str3.Split(new string[1]
                                            {
                        "."
                                            }, StringSplitOptions.None);
                                            try
                                            {
                                                string str5 = strArray2[1].ToLower();
                                                string str6 = strArray2[2].ToLower();
                                                if ((System.IO.File.Exists("quests/" + str5 + "_" + str6 + ".png") ? 1 : (strArray2[2].Contains("=") ? 1 : 0)) == 0)
                                                {
                                                    try
                                                    {
                                                        ++num6;
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("Downloading: " + strArray2[1] + "_" + strArray2[2] + ".png");
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        webClient4.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                        webClient4.DownloadFile("http://images.habbo.com/c_images/Quests/" + strArray2[1] + "_" + strArray2[2] + ".png", "quests/" + strArray2[1] + "_" + strArray2[2] + ".png");
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error while downloading: " + strArray2[1] + "_" + strArray2[2] + ".png");
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        --num6;
                                                        try
                                                        {
                                                            ++num6;
                                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                                            Console.WriteLine("Retry Downloading: " + str5 + "_" + str6 + ".png");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            webClient4.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient4.DownloadFile("http://images.habbo.com/c_images/Quests/" + str5 + "_" + str6 + ".png", "quests/" + str5 + "_" + str6 + ".png");
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                            Console.WriteLine("Retry Error while downloading: " + str5 + "_" + str6 + ".png");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            --num6;
                                                        }
                                                    }
                                                }
                                                else if (strArray2[2].Contains("="))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(str5 + "_" + str6 + ".png is not valid!");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                    Console.WriteLine(str5 + "_" + str6 + ".png already exists!");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                }
                                                if (!System.IO.File.Exists("quests/" + strArray2[1] + ".png"))
                                                {
                                                    try
                                                    {
                                                        ++num6;
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("Downloading: " + strArray2[1] + ".png");
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        webClient4.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                        webClient4.DownloadFile("http://images.habbo.com/c_images/Quests/" + strArray2[1] + ".png", "quests/" + strArray2[1] + ".png");
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Error while downloading: " + strArray2[1] + ".png");
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        --num6;
                                                        try
                                                        {
                                                            ++num6;
                                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                                            Console.WriteLine("Retry Downloading: " + str5 + ".png");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            webClient4.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient4.DownloadFile("http://images.habbo.com/c_images/Quests/" + str5 + ".png", "quests/" + str5 + ".png");
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                            Console.WriteLine("Retry Downloading: " + str5 + ".png failed!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            --num6;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                    Console.WriteLine(strArray2[1] + ".png already exists!");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Finished Downloading Quest images!");
                                    Console.WriteLine(" images have been downloaded!");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    goto temp;
                                }
                            case "badges":
                                if (!Directory.Exists("./badges"))
                                {
                                    Directory.CreateDirectory("./badges");
                                }
                                if (!Directory.Exists("./temp"))
                                {
                                    Directory.CreateDirectory("./temp");
                                }
                                int length = Directory.GetFiles("./badges", "*.*", SearchOption.AllDirectories).Length;
                                WebClient webClient6 = new WebClient();

                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.com/gamedata/external_flash_texts/1", "./temp/external_flash_texts_com.txt");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Start initializing badges from .com - Global");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.fr/gamedata/external_flash_texts/1", "./temp/external_flash_texts_fr.txt");
                                Console.WriteLine("Start initializing badges from .fr - France");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.fi/gamedata/external_flash_texts/1", "./temp/external_flash_texts_fi.txt");
                                Console.WriteLine("Start initializing badges from .fi - Finland");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.es/gamedata/external_flash_texts/1", "./temp/external_flash_texts_es.txt");
                                Console.WriteLine("Start initializing badges from .es - Spain");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.com/gamedata/external_flash_texts/1", "./temp/external_flash_texts_nl.txt");
                                Console.WriteLine("Start initializing badges from .nl - The Dutch");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.de/gamedata/external_flash_texts/1", "./temp/external_flash_texts_de.txt");
                                Console.WriteLine("Start initializing badges from .de - Germany");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.it/gamedata/external_flash_texts/1", "./temp/external_flash_texts_it.txt");
                                Console.WriteLine("Start initializing badges from .it - Italy");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.com.tr/gamedata/external_flash_texts/1", "./temp/external_flash_texts_tr.txt");
                                Console.WriteLine("Start initializing badges from .com.tr - Turkey");
                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                webClient6.DownloadFile("https://www.habbo.com.br/gamedata/external_flash_texts/1", "./temp/external_flash_texts_br.txt");
                                Console.WriteLine("Start initializing badges from .com.br - Brasil");

                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("External Flash Texts Downloaded...");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Begin Downloading .COM");
                                Thread.Sleep(2000);

                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_com2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_com.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }

                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif"); 
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan; 
                                                                Console.WriteLine(strArray2[0] + " already exists!"); 
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green; 
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]); 
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red; 
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue..."); 
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green; 
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif"); 
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red; 
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue..."); 
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green; 
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif"); 
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Begin Downloading .FR");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_fr2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_fr.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                Console.WriteLine("Begin Downloading .FI");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_fi2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_fi.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Begin Downloading .ES");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_es2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_es.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Begin Downloading .NL");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_nl2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_nl.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Begin Downloading .DE");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_de2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_de.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Begin Downloading .IT");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_it2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_it.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Begin Downloading .TR");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_tr2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_tr.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Begin Downloading .COM.BR");
                                Thread.Sleep(2000);
                                using (StreamWriter streamWriter = new StreamWriter("./temp/external_flash_texts_br2.txt", true))
                                {
                                    using (StreamReader streamReader = new StreamReader("./temp/external_flash_texts_br.txt"))
                                    {
                                        str1 = (string)null;

                                        string str3;
                                        while ((str3 = streamReader.ReadLine()) != null)
                                        {
                                            if (str3.StartsWith("badge_name_"))
                                            {
                                                streamWriter.WriteLine(str3);
                                                if (str3.StartsWith("badge_name_fb_"))
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    string[] strArray3 = strArray2[0].Split(new string[1]
                                                    {
                            "fb_"
                                                    }, StringSplitOptions.None);
                                                    if (strArray2[1].Contains("%roman%"))
                                                    {
                                                        int num7 = 1;
                                                        int num8 = 0;
                                                        while (num8 == 0)
                                                        {
                                                            if (!System.IO.File.Exists(string.Concat(new object[4]
                                                            {
                                (object) "./badges/",
                                (object) strArray3[1],
                                (object) num7,
                                (object) ".gif"
                                                            })))
                                                            {
                                                                try
                                                                {
                                                                    webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                    webClient6.DownloadFile(string.Concat(new object[4]
                                                                    {
                                    (object) "http://images-eussl.habbo.com/c_images/album1584/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }), string.Concat(new object[4]
                                                                    {
                                    (object) "./badges/",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(string.Concat(new object[4]
                                                                    {
                                    (object) "Downloading badge: ",
                                    (object) strArray3[1],
                                    (object) num7,
                                    (object) ".gif"
                                                                    }));
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    ++num7;
                                                                }
                                                                catch
                                                                {
                                                                    ++num8;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + (object)num7 + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                ++num7;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[1] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[1] + ".gif", "./badges/" + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[1] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[1] + ".gif already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                if (str3.StartsWith("badge_name_al_"))
                                                {
                                                    try
                                                    {
                                                        string[] strArray2 = str3.Split(new string[1]
                                                        {
                              "badge_name_"
                                                        }, StringSplitOptions.None)[1].Split(new string[1]
                                                        {
                              "="
                                                        }, StringSplitOptions.None)[0].Split(new string[1]
                                                        {
                              "al_"
                                                        }, StringSplitOptions.None);
                                                        if (!System.IO.File.Exists("./badges/" + strArray2[1] + ".gif"))
                                                        {
                                                            webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                            webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[1] + ".gif", "./badges/" + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Downloading badge: " + strArray2[1] + ".gif");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            Console.WriteLine(strArray2[1] + ".gif already exists!");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                if ((str3.StartsWith("badge_name_al") ? 1 : (str3.StartsWith("badge_name_fb") ? 1 : 0)) == 0)
                                                {
                                                    string[] strArray2 = str3.Split(new string[1]
                                                    {
                            "badge_name_"
                                                    }, StringSplitOptions.None)[1].Split(new string[1]
                                                    {
                            "="
                                                    }, StringSplitOptions.None);
                                                    if ((strArray2[0].Contains("_HHCA") ? 1 : (strArray2[0].Contains("_HHUK") ? 1 : 0)) == 0)
                                                    {
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray2[0] + ".gif", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray2[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray2[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }

                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray2[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray2[0] + ".png", "./badges/" + strArray2[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge PNG: " + strArray2[0] + ".png and converting to gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray2[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string str5 = "";
                                                        if (strArray2[0].Contains("_HHCA"))
                                                        {
                                                            str5 = "_HHCA";
                                                        }
                                                        else if (strArray2[0].Contains("_HHUK"))
                                                        {
                                                            str5 = "_HHUK";
                                                        }
                                                        string[] strArray3 = strArray2[0].Split(new string[1]
                                                        {
                              str5
                                                        }, StringSplitOptions.None);
                                                        try
                                                        {
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("http://images-eussl.habbo.com/c_images/album1584/" + strArray3[0] + ".gif", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0] + ".gif");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                                Console.WriteLine(strArray3[0] + " already exists!");
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                            if (!System.IO.File.Exists("./badges/" + strArray3[0] + ".gif"))
                                                            {
                                                                webClient6.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                                                                webClient6.DownloadFile("https://images.habbogroup.com/c_images/album1584/" + strArray3[0] + ".png", "./badges/" + strArray3[0] + ".gif");

                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Downloading badge: " + strArray3[0]);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Error while downloading badge " + strArray3[0] + " Lets continue...");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine();
                                Console.WriteLine("Downloading done!");
                                Console.WriteLine("We downloaded " + (object)(Directory.GetFiles("./badges", "*.*", SearchOption.AllDirectories).Length - length) + " badges!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                goto temp;

                            default:
                                ConsoleCommandHandeling.unknownCommand(inputData);

                                goto readline;
                        }
                        if (!Directory.Exists("./hof_furni"))
                        {
                            Directory.CreateDirectory("./hof_furni");
                        }
                        if (!Directory.Exists("./hof_furni/icons"))
                        {
                            Directory.CreateDirectory("./hof_furni/icons");
                        }
                        if (!Directory.Exists("./temp"))
                        {
                            Directory.CreateDirectory("./temp");
                        }
                        string str7 = "./temp/furnidata.txt";
                        WebClient webClient7 = new WebClient();
                        webClient7.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");
                        webClient7.DownloadFile("https://habbo.com/gamedata/furnidata/1/", str7);
                        Console.WriteLine("Furnidata Downloaded...");
                        int num9 = 0;
                        System.IO.File.WriteAllLines(str7, Enumerable.ToArray<string>(Enumerable.Select<string, string>((IEnumerable<string>)System.IO.File.ReadAllLines(str7), (Func<string, string>)(line => string.Join("\n", line.Split(new string[1]
                      {
              "],"
                      }, StringSplitOptions.RemoveEmptyEntries))))));
                        System.IO.File.WriteAllLines(str7, Enumerable.ToArray<string>(Enumerable.Select<string, string>((IEnumerable<string>)System.IO.File.ReadAllLines(str7), (Func<string, string>)(line => string.Join("\n", line.Split(new string[1]
                      {
              "["
                      }, StringSplitOptions.RemoveEmptyEntries))))));
                        System.IO.File.WriteAllLines(str7, Enumerable.ToArray<string>(Enumerable.Select<string, string>((IEnumerable<string>)System.IO.File.ReadAllLines(str7), (Func<string, string>)(line => string.Join("", line.Split(new string[1]
                      {
              "\""
                      }, StringSplitOptions.RemoveEmptyEntries))))));
                        using (StreamReader streamReader = new StreamReader(str7))
                        {
                            Console.WriteLine("Begin downloading...");
                            Thread.Sleep(3000);
                            string str3;
                            while ((str3 = streamReader.ReadLine()) != null)
                            {
                                string[] strArray2 = str3.Split(new string[1]
                                {
                  ","
                                }, StringSplitOptions.None);
                                string[] strArray3 = strArray2[2].Split(new string[1]
                                {
                  "*"
                                }, StringSplitOptions.None);
                                if (!System.IO.File.Exists("./hof_furni/" + strArray3[0] + ".swf"))
                                {
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Downloading: /" + strArray2[3] + "/" + strArray3[0] + ".swf");
                                        Console.WriteLine("Downloading: /" + strArray2[3] + "/" + strArray3[0] + ".png");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        webClient7.DownloadFile("http://images.habbo.com/dcr/hof_furni/" + strArray2[3] + "/" + strArray3[0] + ".swf", "hof_furni/" + strArray3[0] + ".swf");
                                        webClient7.DownloadFile("http://images.habbo.com/dcr/hof_furni/" + strArray2[3] + "/" + strArray3[0] + "_icon.png", "hof_furni/icons/" + strArray3[0] + "_icon.png");
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error while downloading: " + strArray3[0]);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        --num9;
                                    }
                                    ++num9;
                                }
                                // else
                                // {
                                // Console.ForegroundColor = ConsoleColor.DarkCyan;
                                // Console.WriteLine(strArray2[2] + ".swf already exists!");
                                // Console.ForegroundColor = ConsoleColor.Gray;
                                // }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Downloading Furniture Done!");
                            Console.WriteLine("We've downloaded " + (object)num9 + " new furniture!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    temp:
                        foreach (string path in Directory.GetFiles("./temp"))
                        {
                            System.IO.File.Delete(path);
                        }
                        Directory.Delete("./temp");
                        break;


                    case "help":
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("                       Tool Commands:                             ");
                        Console.WriteLine("                                                                  ");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("-> Help     - This Command List                                   ");
                        Console.WriteLine("-> Version  - Show current SWF version on Habbo.com               ");
                        Console.WriteLine("-> About    - Show info about this tool                           ");
                        Console.WriteLine("-> clothes  - Download all clothes and XML                        ");
                        Console.WriteLine("-> Exit     - Exit the application                                ");
                        Console.WriteLine("                                                                  ");
                        Console.WriteLine("-> Download - all download commands:                              ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("- effects - Downloads All effects.                                ");
                        Console.WriteLine("- furniture - Downloads All Habbo Furniture.                      ");
                        Console.WriteLine("- furnidata - Saves a local copy of the furnidata.                ");
                        Console.WriteLine("- productdata - Saves a local copy of the productdata             ");
                        Console.WriteLine("- texts - Saves all external_flash_texts.                         ");
                        Console.WriteLine("- variables - Saves all external_variables.                       ");
                        Console.WriteLine("- icons - Saves all catalogue icons.                              ");
                        Console.WriteLine("- mp3 - Saves all mp3 sounds.                                     ");
                        Console.WriteLine("- quests - Saves all quest images.                                ");
                        Console.WriteLine("- badges - Saves all badges.                                      ");
                        Console.WriteLine("- reception - Saves client background images                      ");
                        Console.WriteLine("                                                                  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case "exit":
                        System.Environment.Exit(1);
                        break;

                    case "about":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("All developers from RagZone but special credits to : Quackster and ofcourse all the rest. So stop wanking about credits!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case "news":


                    case "version":
                        string release_ver;
                        HttpClient httpClient_version_ver = new HttpClient();
                        httpClient_version_ver.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36");

                        Task.Run(async () =>
                        {
                            try
                            {
                                HttpResponseMessage res = await httpClient_version_ver.GetAsync("https://www.habbo.com/gamedata/external_variables/1");
                                string source = (await res.Content.ReadAsStringAsync());

                                foreach (string Line in source.Split(Environment.NewLine.ToCharArray()))
                                {
                                    if (!Line.Contains("flash.client.url="))
                                    {
                                        continue;
                                    }
                                    release_ver = Line.Substring(0, Line.Length - 1).Split('/')[4];
                                    Console.WriteLine("Current habbo release: " + release_ver);

                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        });
                        break;

                    case "clothes":

                        string release;
                        HttpClient httpClient_version = new HttpClient();
                        httpClient_version.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36");

                        Program program = new Program();
                        Task.Run(async () =>
                        {
                            try
                            {
                                HttpResponseMessage res = await httpClient_version.GetAsync("https://www.habbo.com/gamedata/external_variables/1");
                                string source = (await res.Content.ReadAsStringAsync());

                                foreach (string Line in source.Split(Environment.NewLine.ToCharArray()))
                                {
                                    if (!Line.Contains("flash.client.url="))
                                    {
                                        continue;
                                    }
                                    release = Line.Substring(0, Line.Length - 1).Split('/')[4];
                                    Console.WriteLine("We are going to download from release: " + release);


                                    string CurrentDirectory;
                                    string HotelVersion;
                                    string Hotel;
                                    string GordonDirectory;
                                    string figuremap;
                                    string figuremapfile;
                                    string figuredata;
                                    string DownloadDirectory;

                                    CurrentDirectory = Environment.CurrentDirectory;

                                    Hotel = "com";
                                    HotelVersion = release;
                                    GordonDirectory = "https://images.habbo.com/gordon/";
                                    DownloadDirectory = CurrentDirectory + @"\clothes\";

                                    figuremap = "https://images.habbo.com/gordon/" + HotelVersion + "/figuremap.xml";
                                    figuredata = "http://habbo.com/gamedata/figuredata/1";

                                    WebClient WebClient = new WebClient();
                                    WebClient.Headers.Add("user-agent", "Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/70.0.3538.102+Safari/537.36+Edge/18.18362;)");


                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        WebClient.DownloadFile(figuredata, DownloadDirectory + @"\figuredata.xml");
                                        Console.WriteLine("Downloaded figuredata.xml\n");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error! Cant download file");
                                        Console.WriteLine();
                                        Console.WriteLine("figuredata.xml \ndownload url: " + figuredata);
                                        Console.WriteLine();
                                        Console.WriteLine("Trying download figuremap.xml");
                                        Console.WriteLine();
                                    }

                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        WebClient.DownloadFile(figuremap, DownloadDirectory + @"\figuremap.xml");
                                        Console.WriteLine("Downloaded figuremap.xml\n");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error! Cant download file! Please check your config.ini is OK! (Check you have correct 'HotelVersion' value)");
                                        Console.WriteLine();
                                        Console.WriteLine("figuremap.xml download url: " + figuremap);
                                        Console.WriteLine();
                                    }

                                    figuremapfile = DownloadDirectory + @"\figuremap.xml";

                                    try
                                    {
                                        string file = File.ReadAllText(figuremapfile);
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error! Cant read file: " + figuremapfile);
                                        Console.WriteLine();
                                    }

                                    StringBuilder sb = new StringBuilder();
                                    using (StreamReader sr = new StreamReader(figuremapfile))
                                    {
                                        String line;
                                        while ((line = sr.ReadLine()) != null)
                                        {
                                            sb.AppendLine(line);
                                        }
                                    }
                                    string allines = sb.ToString();

                                    StringBuilder output = new StringBuilder();
                                    int DownloadCount = 0;
                                    using (XmlReader reader = XmlReader.Create(new StringReader(allines)))
                                    {
                                        while (reader.Read())
                                        {
                                            if (reader.IsStartElement())
                                            {
                                                switch (reader.Name)
                                                {
                                                    case "map":
                                                        break;
                                                    case "lib":
                                                        string id = reader["id"];
                                                        if (id != null)
                                                        {
                                                            try
                                                            {
                                                                if (!File.Exists(DownloadDirectory + id + ".swf"))
                                                                {
                                                                    WebClient.DownloadFile(GordonDirectory + HotelVersion + "/" + id + ".swf", DownloadDirectory + id + ".swf");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine("Downloaded: " + id);
                                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                                    DownloadCount++;
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Error when downloading file: " + id);
                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                            }
                                                        }
                                                        break;
                                                }
                                            }
                                        }
                                    }

                                    if (DownloadCount > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine();
                                        Console.WriteLine("Downloaded " + DownloadCount + " new clothes!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("You have the latest clothes!");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("Al has been done!");
                                    Console.WriteLine();
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        });
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in command [" + inputData + "]: " + ((object)ex).ToString());
            }

        readline:
            Console.WriteLine();
            ConsoleCommandHandeling.InvokeCommand(Console.ReadLine());
        }

        private static void unknownCommand(string command)
        {
            Console.WriteLine(command + " is an unknown or unsupported command. Type help for more information");
        }
    }
}