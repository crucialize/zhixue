using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestSharp.Human
{

	static class RestSharpHuman
	{

		public static IRestResponse Human(this IRestClient client,IRestRequest req)
		{
			//parse
			var url = new Uri(req.Resource);
			client.BaseUrl = new Uri(url.Scheme + "://" + url.Host);
			req.Resource = url.PathAndQuery;

			var res = client.Execute(req);
			return res;
		}

		public static IRestResponse Human<T> (this IRestClient client, IRestRequest req) where T:new()
		{
			//parse
			var url = new Uri(req.Resource);
			client.BaseUrl = new Uri(url.Scheme + "://" + url.Host);
			req.Resource = url.PathAndQuery;

			var res = client.Execute<T>(req);
			return res;
		}

		public delegate void RequestCallback(IRestResponse res);

		public static void Human(this IRestClient client, IRestRequest req,RequestCallback callback)
		{
			//parse
			var url = new Uri(req.Resource);
			client.BaseUrl = new Uri(url.Scheme + ":\\" + url.Host);
			req.Resource = url.PathAndQuery;

			var res = client.Execute(req);
			callback(res);
		}

		public static void Human<T>(this IRestClient client, IRestRequest req,RequestCallback callback) where T : new()
		{
			//parse
			var url = new Uri(req.Resource);
			client.BaseUrl = new Uri(url.Scheme + ":\\" + url.Host);
			req.Resource = url.PathAndQuery;

			var res = client.Execute<T>(req);
			callback(res);
		}


	}
}
