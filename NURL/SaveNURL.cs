/*
 * Crée par SharpDevelop.
 * Utilisateur: Aroune
 * Date: 29/05/2014
 * Heure: 10:31
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NURL
{
	/// <summary>
	/// Description of SaveNURL.
	/// </summary>
	public class SaveNURL
	{
		NURL n;
		ArrayList ts=new ArrayList();
		
		private TimeSpan time;
		
		private TimeSpan timeAverage;
		public SaveNURL(NURL _n)
		{
			this.n=_n;
		}
		public TimeSpan Time
		{
			get;
			set;
		}
		public TimeSpan TimeAverage
		{
			get;
			set;
		}
		public TimeSpan TestAverageLoadingUrl(string _url, int nb)
		{
			int index=nb;
			TimeSpan timeFull=TimeSpan.Zero;
			
			for (int i = 0; i < nb; i++) 
			{
				ExistURLWithTimer(_url);
				timeFull.Add(Time);			
			}
			
			double day,hour, minute, second, millisecond;
			
			day=timeFull.TotalDays;
			hour=timeFull.TotalHours;
			minute=timeFull.TotalMinutes;
			second=timeFull.TotalSeconds;
			millisecond=timeFull.TotalMilliseconds;
			
			if(day!=0)		
			{
				day=day/nb;	
				timeAverage=TimeSpan.FromDays(day);
			}
			else if(hour!=0)
			{
				hour=hour/nb;
				timeAverage=TimeSpan.FromHours(hour);
			}
			else if(minute!=0)
			{
				minute=minute/nb;
				timeAverage=TimeSpan.FromMinutes(minute);
			}
			else if(second!=0)
			{
				second=second/nb;
				timeAverage=TimeSpan.FromSeconds(second);
			}
			else
			{
				millisecond=millisecond/nb;
				timeAverage=TimeSpan.FromMilliseconds(millisecond);
			}
			
			TimeAverage=timeAverage;
			return TimeAverage;
		}
		
		public void TestLoadingUrl(string _url, int nb)
		{
			int index=nb;
			TimeSpan timeFull=TimeSpan.Zero;
			
			for (int i = 0; i < nb; i++) 
			{
				ExistURLWithTimer(_url);
				timeFull.Add(Time);				
				Console.WriteLine("Chargement de la page " +_url+ " : " + Time);
			}
		}
		
		public ArrayList getTimeSpans(string _url, int nb, ArrayList _ts)
		{			
			int index=nb;
			TimeSpan timeFull=TimeSpan.Zero;
			for (int i = 0; i < nb; i++) 
			{
				ExistURLWithTimer(_url);
				timeFull.Add(Time);	
				_ts.Add(Time);
			}
			return _ts;
		}
		
		
		
		
		public bool ExistURLWithTimer(string _url)
		{			
			HttpWebRequest oRequest = null;
			HttpWebResponse oResponse = null;
			string newUrl=n.AddHttp(_url);
			
			try
			{	
				DateTime timeStart = DateTime.Now;
				oRequest = (HttpWebRequest) WebRequest.Create(newUrl);
				oResponse = (HttpWebResponse)oRequest.GetResponse();
				oResponse.Close();
				Time=DateTime.Now.TimeOfDay.Subtract(timeStart.TimeOfDay);
				
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		
		}
	}
}
