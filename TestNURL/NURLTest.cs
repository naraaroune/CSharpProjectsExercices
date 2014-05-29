/*
 * Crée par SharpDevelop.
 * Utilisateur: Aroune
 * Date: 29/05/2014
 * Heure: 10:52
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using NUnit.Framework;

namespace NURL.Test
{
	[TestFixture]
	public class NURLTest
	{
		
		[Test]
		public void Should_Show_Inexistant_Url()
		{		
			string[] args = new string[]{"get","-url","http://google.fr"};		
			string theUrl=args[2];		
			var n=new NURL(theUrl);
			
			theUrl=n.AddHttp(theUrl);
			bool isExist=n.ExistURL(theUrl);
			Assert.IsTrue(isExist,"<h1>You're entered a fake url</h1>");
		}
	}
}
