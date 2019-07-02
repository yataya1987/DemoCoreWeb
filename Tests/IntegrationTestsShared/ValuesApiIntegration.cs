﻿using System.Linq;
using Xunit;
using System.Threading.Tasks;

namespace IntegrationTests
{
	public partial class ValuesApiIntegration 
    {
        [Fact]
        public void TestValuesGet()
        {
            //var task = authorizedClient.GetStringAsync(new Uri(baseUri, "api/Values"));
            //var text = task.Result;
            //var array = JArray.Parse(text);
            var array = api.Get().ToArray();
            Assert.Equal("value2", array[1]);
        }

		[Fact]
        public void TestValuesPost()
        {
            //var t = authorizedClient.PostAsync(new Uri(baseUri, "api/Values")
            //        , new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("", "value") }));
            //var ok = t.Result.IsSuccessStatusCode;
            //Assert.True(ok);
            //var text = t.Result.Content.ReadAsStringAsync().Result;
            //var jObject = JValue.Parse(text);
            //Assert.Equal("VALUE", jObject.ToObject<string>());
            var t = api.Post("value");
            Assert.Equal("VALUE", t);
        }

		[Fact]
		public async Task TestValuesPostAsync()
		{
			var t = await api.PostAsync("value");
			Assert.Equal("VALUE", t);
		}

		[Fact]
        public void TestValuesPut2()
        {
            //var t = authorizedClient.PutAsync(new Uri(baseUri, "api/Values?id=1"), new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("", "value") }));
            //var ok = t.Result.IsSuccessStatusCode;
            //Assert.True(ok);
            api.Put(1, "value");
        }

        [Fact]
        public void TestValuesDelete()
        {
            //var t = authorizedClient.DeleteAsync(new Uri(baseUri, "api/Values/1"));
            //var ok = t.Result.IsSuccessStatusCode;
            //Assert.True(ok);
            api.Delete(1);
        }

    }
}
