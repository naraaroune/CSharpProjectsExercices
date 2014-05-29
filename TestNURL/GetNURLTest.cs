/*
 * Crée par SharpDevelop.
 * Utilisateur: Aroune
 * Date: 29/05/2014
 * Heure: 10:44
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using NUnit.Framework;

namespace NURL.Test
{
	[TestFixture]
	public class GetNURLTest
	{
		[Test]
		public void Should_Display_Content()
		{
			string[] args = new string[]{"get","-url","http://gaara-fr.com"};
				//SaveContent
			
			string theUrl=args[2];
			var n=new NURL(theUrl);
			var gn=new GetNURL(n); 
			string content=gn.GetDisplayHtml(theUrl);
			
			Assert.AreEqual(content,gn.GetDisplayHtml(theUrl));	
			
		}
		
		
		
		[Test]
		public void Should_Create_File_And_Fill()
		{
			string[] args = new string[]{"get","-url","http://gaara-fr.com","-save",@"C:\Users\Aroune\gaara.txt"};
				//SaveContent
			
			string theUrl=args[2];
			string path=args[4];
			var n=new NURL(theUrl);
			var gn=new GetNURL(n); 
			
			gn.SaveContent(theUrl,path);
			
			Assert.IsTrue(File.Exists(args[4]));
			
			string content;
			
			using(FileStream fs = new FileStream(args[4],FileMode.Open)){
				using(StreamReader sr = new StreamReader(fs)){
					content = sr.ReadToEnd();
				}
			}
			
			Assert.IsNotNullOrEmpty(content);
		}
	}
}
