﻿using System;
using Xunit;


namespace IntegrationTests
{
	public class SpecialTypesFixture : IDisposable
	{
		public SpecialTypesFixture()
		{
			var baseUri = new Uri("http://localhost:5000/");

			httpClient = new System.Net.Http.HttpClient();

			Api = new DemoCoreWeb.Controllers.Client.SpecialTypes(httpClient, baseUri);
		}

		public DemoCoreWeb.Controllers.Client.SpecialTypes Api { get; private set; }

		System.Net.Http.HttpClient httpClient;

		#region IDisposable pattern
		bool disposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					httpClient.Dispose();
				}

				disposed = true;
			}
		}
		#endregion
	}


	public partial class SpecialTypesApiIntegration : IClassFixture<SpecialTypesFixture>
	{
		public SpecialTypesApiIntegration(SpecialTypesFixture fixture)
		{
			api = fixture.Api;
		}

        DemoCoreWeb.Controllers.Client.SpecialTypes api;

        [Fact]
        public void TestGetAnonymousDynamic()
        {
            var d = api.GetAnonymousDynamic();
            Assert.Equal("12345", d["id"].ToString());
            Assert.Equal("Something", d["name"].ToString());
        }

        [Fact]
        public void TestGetAnonymousObject()
        {
            var d = api.GetAnonymousObject();
            Assert.Equal("12345", d["id"].ToString());
            Assert.Equal("Something", d["name"].ToString());
        }

        [Fact]
        public void TestPostAnonymousObject()
        {
            var d = new Newtonsoft.Json.Linq.JObject();
            d["Id"] = "12345";
            d["Name"] = "Something";
            var r = api.PostAnonymousObject(d);
            Assert.Equal("123451", r["Id"].ToString());
            Assert.Equal("Something1", r["Name"].ToString());

        }

    }
}
