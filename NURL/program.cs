/*
 * Created by SharpDevelop.
 * User: Eric NARA
 * Date: 21/05/2014
 * Time: 09:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Net;

namespace NURL
{
	class Program
	{
		public static void Main(string[] args)
		{
			string path;
			string extension;
			
			NURL n=new NURL(args[2]);
			GetNURL gn=new GetNURL(n);
			SaveNURL sn=new SaveNURL(n);
			
			
			if(args[0] =="get")
			{
				if(args[1]=="-url")
				{
					n.Url=args[2];
					n.Url=n.AddHttp(n.Url);
					n.ExistURL(n.Url);
					
					if(args.Length<4)
					{
						gn.DisplayHtml(n.Url);
					}
					else
					{
						if(args[3]=="-save")
						{
							path=args[4];
							extension=args[4].Substring(args[4].LastIndexOf(".")+1);
							gn.SaveContent(n.Url,path);
						}
					}
						
				}
				
			}
			else
			{
				if(args[0]=="test")
				{
					if(args[1]=="-url")
					{
						n.Url=args[2];
						n.Url=n.AddHttp(n.Url);
						if(args.Length<6)
						{							
							sn.TestLoadingUrl(n.Url,Convert.ToInt32(args[4]));
						}
						else
						{
							sn.TestAverageLoadingUrl(n.Url,Convert.ToInt32(args[4]));
						}
					}
				}
				else
				{
					Console.WriteLine("Cette option n'existe pas.");
				}
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	
	
	
}

