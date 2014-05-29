/*
 * Crée par SharpDevelop.
 * Utilisateur: Aroune
 * Date: 29/05/2014
 * Heure: 10:43
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using NURL;
using NUnit.Framework;

namespace NURL.Test
{
	[TestFixture]
	public class SaveNURLTest
	{
		[Test]
		public void Should_Show_Times(){
			string[] args = new string[]{"test","-url","http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric","-times","4"};
			string theUrl=args[2];
			int nb=Convert.ToInt32(args[4]);
			var n=new NURL(theUrl);
			var sn=new SaveNURL(n); 
			ArrayList ts=new ArrayList();
			
		
			StringBuilder sb = new StringBuilder();
			sn.getTimeSpans(theUrl,nb,ts);
			
			
			
			for (int i = 0; i < ts.Count; i++) 
			{
				sb.Append(ts[i]+"\n");
			}
			
			Assert.AreEqual(sb.ToString(),sb.ToString());
		}
		
		[Test]
		public void Should_Show_Average_Times()
		{
			string[] args = new string[]{"test","-url","google.Fr","-times","4"};
			string theUrl=args[2];
			int nb=Convert.ToInt32(args[4]);
			var n=new NURL(theUrl);
			var sn=new SaveNURL(n); 
			sn.TestAverageLoadingUrl(theUrl,nb);
			TimeSpan ts=sn.TimeAverage;
			
		
			Assert.AreEqual(ts,sn.TimeAverage);
		}
	}
}
