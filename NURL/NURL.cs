/*
 * Crée par SharpDevelop.
 * Utilisateur: Aroune
 * Date: 29/05/2014
 * Heure: 10:32
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Net;

namespace NURL
{
	/// <summary>
	/// Description of NURL.
	/// </summary>
	public class NURL
	{
		private string url;
		
		public NURL(string _url)
		{
			this.url=_url;
		}
		
				
		public string Url
		{
			get;
	        set;			
		}
		
		
		
		public string AddHttp(string _url)
		{
			if(_url.StartsWith("http://"))
				return _url;
			else
				return "http://"+_url;
		}
		
		public bool ExistURL(string _url)
		{			
			HttpWebRequest oRequest = null;
			HttpWebResponse oResponse = null;
			string newUrl=AddHttp(_url);
			
			try
			{	
				oRequest = (HttpWebRequest) WebRequest.Create(newUrl);
				oResponse = (HttpWebResponse)oRequest.GetResponse();
				oResponse.Close();
				
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		
		}
		
	}
}
