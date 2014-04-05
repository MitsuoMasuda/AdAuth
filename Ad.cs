using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace Ad
{
	public class Ad
	{
		// 定数
		public const string DefaultConnDestination = "TEST-WK";
		public const string DefaultDomain = "@test.co.jp";

		// 変数
		public string _connDestination = "";
		public string _domain = "";

		// プロパティ
		public string ConnDestination { set { this._connDestination = value; } }
		public string Domain { set { this._domain = value; } }

		public Ad()
		{
			this._connDestination = DefaultConnDestination;
			this._domain = DefaultDomain;
		}

		/// <summary>
		/// AD認証を行う。
		/// </summary>
		/// <param name="id">ADに登録されているID</param>
		/// <param name="password">パスワード</param>
		/// <returns>true：認証OK　false：認証NG</returns>
		public bool Auth(string id, string password)
		{
			try
			{
				string path = "LDAP://" + this._connDestination;
				string user = id + this._domain;

				DirectoryEntry directoryEntry = new DirectoryEntry(path, user, password);
				DirectorySearcher directorySearch = new DirectorySearcher(directoryEntry);
				directorySearch.PropertiesToLoad.Add("cn");

				// 指定したユーザー＆パスワードで認証できない場合、例外を発生させる
				SearchResultCollection searchResultCollection = directorySearch.FindAll();
				directoryEntry.Close();

				return true;
			}
			catch
			{
				return false;
			}

		}
	}
}
