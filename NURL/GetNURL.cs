/*
 * Crée par SharpDevelop.
 * Utilisateur: Aroune
 * Date: 29/05/2014
 * Heure: 10:31
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using System.Net;

namespace NURL
{
	/// <summary>
	/// Description of GetNURL.
	/// </summary>
	public class GetNURL
	{
		NURL n;
		public GetNURL(NURL _n)
		{
			this.n=_n;
		}
		
		public void SaveContent(string _url, string path)
		{
			WebClient client = new WebClient();
			try
			{
				var content = client.DownloadString(_url);
	            using(var file = File.CreateText(path))
	            {
	                file.Write(content);
	            }
				
			}
			catch(UnauthorizedAccessException e)
			{
				return;
			}
		}
		
		public string GetDisplayHtml(string _url)
		{
			_url=n.AddHttp(_url);
			WebClient client = new WebClient();
			
    		string codeHtml = client.DownloadString(_url);
			return codeHtml;
		}
		
		public void DisplayHtml(string _url)
		{
			_url=n.AddHttp(_url);
			WebClient client = new WebClient();
			
    		string codeHtml = client.DownloadString(_url);
    		Console.WriteLine(codeHtml);
		}
	}
}
