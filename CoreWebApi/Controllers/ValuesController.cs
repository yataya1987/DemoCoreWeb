﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
//	[ApiExplorerSettings(IgnoreApi = false)]
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		/// <summary>
		/// Get a list of value
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		[HttpGet("{id}")]
		public string Get(int id)
		{
			return id.ToString();
		}

		// POST api/values
		[HttpPost]
		public string Post([FromBody]string value)
		{
			System.Diagnostics.Debug.WriteLine("received POST value: " + value);
			return value.ToUpper();
		}

		/// <summary>
		/// Update with valjue
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}


	}
}
